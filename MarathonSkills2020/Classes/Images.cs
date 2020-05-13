using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkills2020.Classes
{
    class Images
    {
        public byte[] ConvertImageToByte(string path)
        {
            Bitmap image = new Bitmap(path);
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}