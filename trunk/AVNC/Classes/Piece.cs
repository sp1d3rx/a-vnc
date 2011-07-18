using System;
using System.Drawing;
using System.Security.Cryptography;

namespace AVNC.Classes
{
    internal class Piece
    {
        private int number;
        private Bitmap img;
        private string checksum;

        public Piece(int number, Bitmap img)
        {
            this.number = number;
            this.img = img;
            System.Drawing.ImageConverter ic = new System.Drawing.ImageConverter();
            byte[] tempimg = new byte[1];
            tempimg = (byte[])ic.ConvertTo(img, tempimg.GetType());
            MD5 shaM = new MD5CryptoServiceProvider();
            this.checksum = Convert.ToBase64String(shaM.ComputeHash(tempimg)).Replace('/', 'x');
        }

        public int getNumber()
        {
            return number;
        }

        public string getCheckSum()
        {
            return checksum;
        }

        public Bitmap getImg(int compressionlevel)
        {
            if (compressionlevel == 2)
            {
                OctreeQuantizer quantizer = new OctreeQuantizer(255, 8); // 255 colors, 8 bits...
                return quantizer.Quantize(img);
            }
            else if (compressionlevel == 3)
            {
                OctreeQuantizer quantizer = new OctreeQuantizer(63, 6); // 63 colors, 6 bits...
                return quantizer.Quantize(img);
            }
            else if (compressionlevel == 4)
            {
                OctreeQuantizer quantizer = new OctreeQuantizer(15, 4); // 15 colors, 4 bits (very low quality)...
                return quantizer.Quantize4bpp(img);
            }
            else
                return img;
        }
    }
}