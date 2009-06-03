using System;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace AVNC.Classes
{
    class HTMLWrapper
    {
        private static string title;

        private static void send(string str, Socket s, bool close)
        {
            send(Encoding.ASCII.GetBytes(str), s, close);
        }

        private static void send(byte[] data, Socket s, bool close)
        {
            try
            {
                s.Send(data);

                if (close)
                    s.Close();
            }
            catch (Exception)
            {}
        }

        public static void sendTEXT(string str, Socket s, int code)
        {
            string header = "";
            switch (code)
            {
                case 200:
                    header = "HTTP/1.0 200 OK\nContent-Type: text/plain\n\n";
                    break;
                case 500:
                    header = "HTTP/1.0 500 ERROR\nContent-Type: text/plain\n\n";
                    break;
                default:
                    header = "HTTP/1.0 200 OK\nContent-Type: text/plain\n\n";
                    break;

            }
            send(header, s, false);
            send(str, s, true);
        }

        public static void sendPAGE(string str, Socket s)
        {
            str = "<html>\n"
                +"<head><title>" + title + "</title><meta http-equiv=\"imagetoolbar\" content=\"no\" /></head>\n"
                +"<body><div style='position: absolute; top: 0; left: 0; width:" + System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width + ";'>\n"
                +str+"\n"
                +"</div>\n"
                +"</body>\n"
                +"</html>";
            string header = "HTTP/1.0 200 OK\nContent-Type: text/html\n\n";
            send(header, s, false);
            send(str, s, true);
        }

        public static void sendImage(Piece img, Socket s, int compression)
        {
            MemoryStream ms = new MemoryStream();
            string contentType = "";

            if (compression == 0)
            {
                img.getImg(0).Save(ms, ImageFormat.Jpeg);
                contentType = "image/jpeg";
            }
            else
            {
                img.getImg(compression).Save(ms, ImageFormat.Png);
                contentType = "image/png";
            }

            string header = "HTTP/1.0 200 OK\nContent-Type: " + contentType + "\nAccept-Ranges: none\nExpires: -1\nPragma: no-cache\nCache-Control: no-cache\n\n";
            send(header, s, false);
            send(ms.ToArray(), s, true); // send image and close...
        }

        public static void setTitle(string t)
        {
            title = t;
        }
    }
}