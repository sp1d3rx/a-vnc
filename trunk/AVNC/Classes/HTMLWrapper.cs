using System;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace AVNC.Classes
{
    internal class HTMLWrapper
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
            { }
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
            str = String.Format("<html>\n<head><title>{0}</title><meta http-equiv=\"imagetoolbar\" content=\"no\" /></head>\n<body oncontextmenu=\"return false;\"><div style='position: absolute; top: 0; left: 0; width:{1};'>\n{2}\n</div>\n</body>\n</html>", title, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, str);
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

            string header = String.Format("HTTP/1.0 200 OK\nContent-Type: {0}\nAccept-Ranges: none\nCache-Control: max-age=3600\n\n", contentType);
            send(header, s, false);
            send(ms.ToArray(), s, true); // send image and close...
        }

        public static void setTitle(string t)
        {
            title = t;
        }
    }
}