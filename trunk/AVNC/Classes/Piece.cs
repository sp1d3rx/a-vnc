using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AVNC.Classes
{
    class Piece
    {
        private int number;
        private Bitmap img;

        public Piece(int number, Bitmap img)
        {
            this.number = number;
            this.img = img;
        }

        public int getNumber()
        {
            return number;
        }

        public Bitmap getImg(int compressionlevel)
        {
            if (compressionlevel <= 1)
                return img; // dont quant jpeg or 24-bit png...
            else if (compressionlevel == 2)
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
                return img; // DSW - t'would bitch about not always returning a bitmap were this not here.
        }
    }
}
