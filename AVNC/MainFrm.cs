using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using AVNC.Classes;
using Microsoft.Win32;

namespace AVNC
{
    public partial class MainFrm : Form
    {
        private TcpListener server;
        private delegate void onAddLog(string title, string value);
        private ArrayList pieces, logs;
        private string imagesToSend = "IMGS";
        private int refreshRate = 3;
        private int imageCompression = 1;
        private int imageSize = 1;
        private int sliceWidth = Screen.PrimaryScreen.Bounds.Width, sliceHeight = Screen.PrimaryScreen.Bounds.Height;
        private Thread listeningThread;
        private string clientIP = "None"; //store IP for last client, to be used in addLog(string, string)
        private string loginPasswordSalt = "";

        public MainFrm()
        {
            InitializeComponent();

            // Handling errors
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(LastChanceHandler);

            // Loading values
            getRegistryValues();

            //create a new salt if one doesn't exist
            if (loginPasswordSalt.Length == 0)
            {
                Random random = new Random();
                loginPasswordSalt = random.Next(1, 99999999).ToString();
            }

            // Applying settings
            if (startListeningCB.Checked) button1_Click(null, null);
            if (minimizeWindowCB.Checked) this.WindowState = FormWindowState.Minimized;
        }

        private void LastChanceHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Invoke(new onAddLog(addLog), "Error", "Unhandled Exception: " + e.Message);
        }

        //TODO: restructure this method
        //this function is a mess.. needs a new structure
        private void startListening()
        {
            Socket mySocket;

            while (true)
            {
                try
                {
                    mySocket = server.AcceptSocket();
                }
                catch (Exception)
                {
                    mySocket = null;
                }

                if ((mySocket != null) && (mySocket.Connected))
                {
                    mySocket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true); // speeds up tcp ...
                    Byte[] bReceive = new Byte[1024];
                    string sBuffer;

                    clientIP = ((IPEndPoint)mySocket.RemoteEndPoint).Address.ToString();
                    // DSW 12/12/2007 thats how (see above)... clientIP = clientIP.Split(':')[0]; //get rid of local port. what's a better way to do this?

                    try
                    {
                        mySocket.Receive(bReceive, bReceive.Length, 0);
                        sBuffer = Encoding.ASCII.GetString(bReceive);

                        if (sBuffer.Length > 0)
                        {
                            if (sBuffer.Split(' ')[1] != "Get /favicon.ico")
                                Invoke(new onAddLog(addLog), "Req: " + sBuffer.Split(' ')[1], sBuffer);
                            else
                                sBuffer = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        Invoke(new onAddLog(addLog), "Error", "startListening: " + Environment.NewLine + ex.ToString());
                        sBuffer = "";
                    }

                    //we must validate authentication on each request, not on each "GET /AVNC"
                    if ((!sBuffer.StartsWith("GET / ")) && (!validate(sBuffer)))
                    {
                        HTMLWrapper.sendPAGE("Wrong password...", mySocket);
                        Invoke(new onAddLog(addLog), "Error (WP)", String.Format("Wrong Password:{0}{1}", Environment.NewLine, sBuffer));
                        sBuffer = "";
                    }

                    if ((sBuffer.StartsWith("GET /sendClick")) && (viewOnlyCB.Checked == false))
                    {
                        doMouseClick(sBuffer);
                        Thread.Sleep(250); //give UI a chance to update after mouse click
                        generateSnapshot();

                        //mySocket.Send(Encoding.ASCII.GetBytes(imagesToSend));
                        HTMLWrapper.sendTEXT(imagesToSend, mySocket, 200);
                        mySocket.Close();

                        imagesToSend = "IMGS";
                    }
                    else if ((sBuffer.StartsWith("GET /sendDrag")) && (viewOnlyCB.Checked == false)) // added drag mouse event...
                    {
                        doMouseDrag(sBuffer);
                        Thread.Sleep(250); //give UI a chance to update after mouse drag
                        generateSnapshot();

                        //mySocket.Send(Encoding.ASCII.GetBytes(imagesToSend));
                        HTMLWrapper.sendTEXT(imagesToSend, mySocket, 200);
                        mySocket.Close();

                        imagesToSend = "IMGS";
                    }
                    else if ((sBuffer.StartsWith("GET /sendStroke")) && (viewOnlyCB.Checked == false))
                    {
                        doStroke(sBuffer);
                        Thread.Sleep(100); //give UI a chance to update after keystroke
                        generateSnapshot();

                        //mySocket.Send(Encoding.ASCII.GetBytes(imagesToSend));
                        HTMLWrapper.sendTEXT(imagesToSend, mySocket, 200);
                        mySocket.Close();

                        imagesToSend = "IMGS";
                    }
                    else if (sBuffer.StartsWith("GET /whatsNew"))
                    {
                        generateSnapshot();

                        //mySocket.Send(Encoding.ASCII.GetBytes(imagesToSend));
                        HTMLWrapper.sendTEXT(imagesToSend, mySocket, 200);
                        mySocket.Close();

                        imagesToSend = "IMGS";
                    }
                    else if (sBuffer.StartsWith("GET / "))
                    {
                        //mySocket.Send(Encoding.ASCII.GetBytes(loginPage()));
                        HTMLWrapper.sendPAGE(loginPage(), mySocket);
                        mySocket.Close();
                    }
                    else if (sBuffer.StartsWith("GET /AVNC"))
                    {
                        pieces.RemoveRange(0, pieces.Count - 1); //remove all old images

                        generateSnapshot();
                        HTMLWrapper.sendPAGE(mainPage(), mySocket);
                    }
                    else if (sBuffer.StartsWith("GET /image"))
                    {
                        try
                        {
                            HTMLWrapper.sendImage((Piece)pieces[extractImageNumber(sBuffer)], mySocket, imageCompression);
                        }
                        catch
                        {
                            //TODO: send error image
                            HTMLWrapper.sendTEXT("Error, try again", mySocket, 500);
                        }
                    }
                    else
                    {
                        HTMLWrapper.sendPAGE("Unknown request...", mySocket);
                    }
                }
            }
        }

        private void doMouseClick(string str)
        {
            int x;
            int y;
            int button;

            str = str.Split(' ')[1];
            str = str.Replace("%20", " ");
            str = str.Trim();

            x = Convert.ToInt32(str.Split(' ')[1]);
            y = Convert.ToInt32(str.Split(' ')[2]);
            button = Convert.ToInt32(str.Split(' ')[3]);

            if (button == 1)
                SendMK.sendMouseL(x, y); // dont put any offsets, fix in javascript, not here. 12/12/2007 DSW
            else
                SendMK.sendMouseR(x, y); // note the subtle difference, Left vs Right button... DSW
        }

        private void doMouseDrag(string str)
        {
            int startX;
            int endX;
            int startY;
            int endY;
            int button;

            str = str.Split(' ')[1]; // removes the "GET"
            str = str.Replace("%20", " ");
            str = str.Trim();

            startX = (Convert.ToInt32(str.Split(' ')[1])); // this ignores the "/sendDrag" ([0]) and gets the first number after that...
            endX = (Convert.ToInt32(str.Split(' ')[2]));
            startY = (Convert.ToInt32(str.Split(' ')[3]));
            endY = (Convert.ToInt32(str.Split(' ')[4]));
            button = Convert.ToInt32(str.Split(' ')[5]);

            if (startX < System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
                && startY < System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
                SendMK.sendDrag(startX, endX, startY, endY, button); // gotta rule out the out-of-bounds clicks.
        }

        private void doStroke(string str) // process keystroke(s)
        {
            //string key;
            str = str.Split(' ')[1];
            str = str.Trim().Substring(14); // cause its GET[0] /sendStroke[1]{x}{x}... [2]http accept
            str = HttpUtility.UrlDecode(str);
            try
            {
                SendMK.sendKeystroke(str.ToString());
            }
            catch (Exception)
            {
                str = "";
            }
        }

        private int extractImageNumber(string data)
        {
            string[] lines = data.Split(' ');

            return Convert.ToInt32(lines[1].Substring(6, 3));
        }

        private string loginPage()
        {
            string str = "";
            try
            {
                str = File.ReadAllText(@"login.htm");
                str = str.Replace("A-VNCloginPasswordSalt", loginPasswordSalt); //replace placeholder in login file with the salt
            }
            catch (FileNotFoundException ex)
            {
                Invoke(new onAddLog(addLog), "Error", "File Missing: login.htm" + Environment.NewLine + ex.ToString());
            }

            return str;
        }

        private bool validate(string str)
        {
            int i;
            string[] newStr = str.Split('\n');

            for (i = 0; i < newStr.Length; i++)
                if (newStr[i].StartsWith("Cookie"))
                    break;

            try
            {
                str = newStr[i].Substring(newStr[i].IndexOf('=') + 1, newStr[i].Length - newStr[i].IndexOf('=') - 1);
                newStr = str.Split(':');
            }
            catch
            {
                newStr = new string[] { "", "0", "0", "0" };
            }

            if (newStr[0] != hashPassword(loginPasswordTB.Text))
                return false;

            imageCompression = Convert.ToInt32(newStr[1]);
            imageSize = Convert.ToInt32(newStr[3]);
            refreshRate = Convert.ToInt32(newStr[2]);

            setImgSize(); //update sliceHeight and sliceWidth according to imageSize

            return true;
        }

        private string hashPassword(string pass)
        {
            SHA1Managed sha1 = new SHA1Managed();
            StringBuilder hPass = new StringBuilder();

            //convert to acsii byte array and pass to sha1
            byte[] result = sha1.ComputeHash(Encoding.ASCII.GetBytes(pass.ToString() + loginPasswordSalt));
            //take result and make string of hex values
            foreach (byte b in result)
            {
                hPass.Append(b.ToString("x2")); //string as hex as 2 digits
            }
            //send back the salted hash value
            return (hPass.ToString());
        }

        private string mainPage()
        {
            string str = "";

            //loading and writing JS files
            try
            {
                str = String.Format("<script>{0}</script>\n", File.ReadAllText(@"script.js"));
            }
            catch (FileNotFoundException ex)
            {
                Invoke(new onAddLog(addLog), "Error", String.Format("File Missing: script.js{0}{1}", Environment.NewLine, ex));
            }
            //replace refresh interval
            str = str.Replace("$RRATE", refreshRate.ToString());

            //writing image tags
            for (int i = 1; i < pieces.Count; i++)
                str = String.Format("{0}<image src='image{1}' id='image{1}'>", str, String.Format("{0:000}", i));

            return str;
        }

        private void setImgSize()
        {
            if (imageSize == 5)
            {
                sliceWidth = Screen.PrimaryScreen.Bounds.Width;
                sliceHeight = Screen.PrimaryScreen.Bounds.Height;
            }
            else
            {
                sliceWidth = (imageSize + 1) * 128;
                sliceHeight = (imageSize + 1) * 128;
            }
        }

        private void generateSnapshot()
        {
            Bitmap img;
            Bitmap scr = captureScreen();

            int screenWidth = scr.Width;
            int screenHeight = scr.Height;
            int index = 0;
            int currentPieceWidth = sliceWidth, currentPieceHeight = sliceHeight;

            for (int currentRow = 0; currentRow < screenHeight; currentRow += sliceHeight) // loop through Y
            {
                for (int currentColumn = 0; currentColumn < screenWidth; currentColumn += sliceWidth) // loop through X
                {
                    if ((currentColumn + currentPieceWidth) > screenWidth) // tiles smaller than slice width
                        currentPieceWidth = screenWidth - currentColumn;

                    if ((currentRow + currentPieceHeight) > screenHeight) // tiles smaller than slice height
                        currentPieceHeight = screenHeight - currentRow;

                    //number the current image
                    index++;
                    //copy the current slice to the image array
                    img = scr.Clone(new Rectangle(currentColumn, currentRow, currentPieceWidth, currentPieceHeight), scr.PixelFormat);

                    if ((pieces.Count - 1 >= index) && (pieces[index] != null)) // If the number of pieces is greater than the current piece, and the current piece is there...
                    {
                        if (CompareImages.Compare(img, ((Piece)pieces[index]).getImg(0)) != CompareImages.CompareResult.ciCompareOk) // compare them. If not matching... continue...
                        {
                            imagesToSend = imagesToSend + String.Format("\nimage{0:000}", index); // add this image to the list of updated images

                            Piece newPiece = new Piece(index, img); // create a new 'piece' object
                            pieces[index] = newPiece;               // replace the current piece in the array.
                            imagesToSend = imagesToSend + "/" + newPiece.getCheckSum();
                        }
                    }
                    else
                    {
                        Piece newPiece = new Piece(index, img); // it doesnt exist
                        pieces.Add(newPiece);                   // so add it.
                    }
                } // end X loop
                currentPieceWidth = sliceWidth; // reset the piece width back to slice width...
            } // end Y loop
        } // end function

        private Bitmap captureScreen()
        {
            Bitmap bmpPic = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb); // this will hold the data
            Graphics grPic = Graphics.FromImage(bmpPic); // this tells the graphics object to draw to the bmpPic
            grPic.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size); // this copies the screen to the bmpPic
            grPic.Dispose(); // should save some ram...
            return bmpPic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loginPasswordTB.Text == "")
            {
                MessageBox.Show("You must specify a 'Login Password'.", "A-VNC");
                loginPasswordTB.Focus();

                return;
            }
            radioBtnIPv6.Enabled = false;
            radioBtnIPv4.Enabled = false;
            HTMLWrapper.setTitle("A-VNC");

            if (button1.Text == "Start")
            {
                setRegistryValues();

                //<required initialization>
                pieces = new ArrayList();
                logs = new ArrayList();
                //</required initailization>

                logLV.Items.Clear(); // to keep the logLV's index concurrent with logs' index
                try
                {
                    if (radioBtnIPv6.Checked)
                        server = new TcpListener(IPAddress.IPv6Any, Convert.ToInt32(listenPortTB.Value));
                    if (radioBtnIPv4.Checked)
                        server = new TcpListener(IPAddress.Any, Convert.ToInt32(listenPortTB.Value));
                    server.Start();
                }
                catch (Exception ex)
                {
                    addLog("Error", "ServerStop: " + ex.ToString());
                }

                listeningThread = new Thread(new ThreadStart(startListening));
                listeningThread.Start();

                button1.Text = "Stop";

                listenPortTB.Enabled = false;
                loginPasswordTB.Enabled = false;
                trayIconMenu.Items[0].Text = "Stop";

                generateSnapshot(); //still don't know why it will not work sometimes if this is not here
            }
            else
            {
                try
                {
                    server.Stop();
                    listeningThread.Abort();
                    button1.Text = "Start";

                    listenPortTB.Enabled = true;
                    loginPasswordTB.Enabled = true;
                    trayIconMenu.Items[0].Text = "Start";
                }
                catch (Exception ex)
                {
                    addLog("Error", String.Format("ServerStop: {0}", ex));
                }
                radioBtnIPv6.Enabled = true;
                radioBtnIPv4.Enabled = true;
            }
        }

        private void addLog(string title, string value)
        {
            string time;

            //<This> can be done more effeciently, but clear/easily-editable code (to me) is more important than effecient/minimum code
            if (title == "Req: /")
                title = "Index Req.";
            else if (title.StartsWith("Req: /AVNC"))
                title = "New Session";
            else if (title.StartsWith("Req: /whatsNew"))
                title = "Update";
            else if (title.StartsWith("Req: /image"))
                title = "Image Req.";
            else if (title.StartsWith("Req: /sendClick"))
                title = "Mouse Click";
            else if (title.StartsWith("Req: /sendDrag"))
                title = "Mouse Drag";
            else if (title.StartsWith("Req: /sendStroke"))
                title = "Keystroke";

            if ((title == "Index Req.") && (!indexReqCB.Checked))
                return;
            else if ((title == "Update") && (!updateCB.Checked))
                return;
            else if ((title == "Image Req.") && (!imageReqCB.Checked))
                return;
            else if (((title == "Mouse Click") || (title == "Mouse Drag")) && (!mouseActionCB.Checked))
                return;
            else if ((title == "Keystroke") && (!keystrokeCB.Checked))
                return;
            else if ((title == "Error") && (!errorCB.Checked))
                return;
            //</This>

            time = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            ListViewItem lvi = new ListViewItem(new string[] { clientIP, time, title });
            logLV.Items.Add(lvi);

            value = value.Replace(loginPasswordTB.Text, "<PASSWORD>"); // we don't want to show the password in log

            logs.Add(new Log(title, value, time, clientIP));
        }

        private void logLV_DClicked(object sender, MouseEventArgs e)
        {
            try
            {
                Log details = ((Log)logs[logLV.SelectedIndices[0]]);
                new LogViewer(details.getTitle(), details.getTime(), details.getIp(), details.getValue()).Show();
            }
            catch (Exception ex)
            {
                Invoke(new onAddLog(addLog), "Error", "LogLV Selected Index: \n" + ex.ToString());
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Exit menu item
            if (button1.Text == "Stop")
                button1_Click(null, null);

            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Start/Start menu item
            button1_Click(null, null);
        }

        private void nIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((button1.Text == "Stop") && (DialogResult.Cancel == MessageBox.Show("Are you sure you want to exit A-VNC?\n\nPress Ok to exit\nPress Cancel to continue using A-VNC", "A-VNC", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)))
                e.Cancel = true;
            else
                if (button1.Text == "Stop")
                    button1_Click(null, null);
        }

        private void setRegistryValues()
        {
            RegistryKey rk = Registry.LocalMachine;

            //<build> array for Log checkboxes
            char[] logCBsettings = "000000".ToCharArray();
            if (indexReqCB.Checked) logCBsettings[0] = '1';
            if (updateCB.Checked) logCBsettings[1] = '1';
            if (imageReqCB.Checked) logCBsettings[2] = '1';
            if (mouseActionCB.Checked) logCBsettings[3] = '1';
            if (keystrokeCB.Checked) logCBsettings[4] = '1';
            if (errorCB.Checked) logCBsettings[5] = '1';
            //</build>

            //<build> array for settings checkboxes
            char[] generalCBsettings = "000000".ToCharArray();
            if (windowsStartupCB.Checked) generalCBsettings[0] = '1';
            if (startListeningCB.Checked) generalCBsettings[1] = '1';
            if (minimizeWindowCB.Checked) generalCBsettings[2] = '1';
            if (radioBtnIPv4.Checked) generalCBsettings[3] = '1';
            if (radioBtnIPv6.Checked) generalCBsettings[4] = '1';
            if (viewOnlyCB.Checked) generalCBsettings[5] = '1';
            //</build>

            try
            {
                rk = rk.OpenSubKey("SOFTWARE\\", true); //may throw Exception if user lacks rights
                rk = rk.CreateSubKey("AVNC");

                rk.SetValue("port", listenPortTB.Value.ToString());
                rk.SetValue("password", loginPasswordTB.Text);
                rk.SetValue("logSettings", new string(logCBsettings));
                rk.SetValue("generalSettings", new string(generalCBsettings));

                //<Set> or unset windows startup
                //eventually you should probably seperate this into seperate try{} since permisions
                //on this key may differ from permissions above key and handle the failures differently
                rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (windowsStartupCB.Checked)
                    rk.SetValue("A-VNC", String.Format("\"{0}\"", Application.ExecutablePath));
                else
                    rk.DeleteValue("A-VNC", false);
                //</Set> or unset

                rk.Close();
            }
            catch (Exception)
            {
                //user lacks registry permision so grey you options
                listenPortTB.Enabled = false;
                windowsStartupCB.Enabled = false;
                startListeningCB.Enabled = false;
                minimizeWindowCB.Enabled = false;
                radioBtnIPv4.Enabled = false;
                radioBtnIPv6.Enabled = false;
                viewOnlyCB.Enabled = false;
            }
        }

        private void getRegistryValues()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine;
                rk = rk.OpenSubKey("SOFTWARE\\AVNC\\", false); //doesn't need write access

                listenPortTB.Value = Convert.ToDecimal((string)rk.GetValue("port"));
                loginPasswordTB.Text = (string)rk.GetValue("password");

                //load and interpret array for logSettings
                char[] logCBsettings = ((string)rk.GetValue("logSettings")).ToCharArray();
                if (logCBsettings[0] == '0') indexReqCB.Checked = false;
                if (logCBsettings[1] == '0') updateCB.Checked = false;
                if (logCBsettings[2] == '0') imageReqCB.Checked = false;
                if (logCBsettings[3] == '0') mouseActionCB.Checked = false;
                if (logCBsettings[4] == '0') keystrokeCB.Checked = false;
                if (logCBsettings[5] == '0') errorCB.Checked = false;
                //</load>

                //load and interpret array for generalSettings
                char[] generalCBsettings = ((string)rk.GetValue("generalSettings")).ToCharArray();
                if (generalCBsettings[0] == '0') windowsStartupCB.Checked = false;
                if (generalCBsettings[1] == '0') startListeningCB.Checked = false;
                if (generalCBsettings[2] == '0') minimizeWindowCB.Checked = false;
                if (generalCBsettings[3] == '1') radioBtnIPv4.Checked = true;
                if (generalCBsettings[4] == '1') radioBtnIPv6.Checked = true;
                if (generalCBsettings[5] == '0') viewOnlyCB.Checked = false;

                //</load>

                rk.Close();
            }
            catch (Exception)
            {
                //set default settings
                windowsStartupCB.Checked = false;
                startListeningCB.Checked = false;
                minimizeWindowCB.Checked = false;
                radioBtnIPv4.Checked = true;
                radioBtnIPv6.Checked = false;
                viewOnlyCB.Checked = false;

                indexReqCB.Checked = true;
                updateCB.Checked = false;
                imageReqCB.Checked = false;
                mouseActionCB.Checked = false;
                keystrokeCB.Checked = false;
                errorCB.Checked = true;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logLV.Items.Clear();
        }

        private void CBSettings_CheckedChanged(object sender, EventArgs e)
        {
            setRegistryValues();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://code.google.com/p/a-vnc/");
            Process.Start(sInfo);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.opensource.org/licenses/mit-license.php");
            Process.Start(sInfo);
        }
    }
}