/*
 *  This class is inspired by Mark Rouse, improved by SpiderX
 *  http://www.codeproject.com/dotnet/comparingimages.asp
 */

using System.Drawing;
using System.Security.Cryptography;

namespace AVNC.Classes // this is specific to AVNC - do not use for other image libraries. (why not?)
{
    public class CompareImages
    {
        public enum CompareResult
        {
            ciCompareOk,
            ciPixelMismatch,
            ciSizeMismatch
        };

        public static CompareResult Compare(Bitmap bmp1, Bitmap bmp2)
        {
            CompareResult cr = CompareResult.ciCompareOk;
            // removed the size test - all images compared will be the same size! (32-bit x height x width)

            //Convert each image to a byte array
            System.Drawing.ImageConverter ic =
                   new System.Drawing.ImageConverter();
            byte[] btImage1 = new byte[1];
            btImage1 = (byte[])ic.ConvertTo(bmp1, btImage1.GetType());
            byte[] btImage2 = new byte[1];
            btImage2 = (byte[])ic.ConvertTo(bmp2, btImage2.GetType());

            //Compute a hash for each image
            //Pointless to use SHA256 when MD5 is good enough. Speed advantage is worth it here.
            MD5 shaM = new MD5CryptoServiceProvider();
            byte[] hash1 = shaM.ComputeHash(btImage1);
            byte[] hash2 = shaM.ComputeHash(btImage2);

            //Compare the hash values
            for (int i = 0; i < hash1.Length && i < hash2.Length && cr == CompareResult.ciCompareOk; i++)
            {
                if (hash1[i] != hash2[i])
                    cr = CompareResult.ciPixelMismatch;
            }

            return cr;
        } // end function
    } // end class
} // end namespace