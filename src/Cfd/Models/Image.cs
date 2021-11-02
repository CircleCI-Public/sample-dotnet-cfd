using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cfd.Helpers;
using Cfd.Models;

namespace Cfd.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public virtual MenuItem Menu { get; set; }


        public Image Add (string filename)
        {
            Image img = new Image();
            byte[] data = ReadBinaryFile.ReadFile(filename);
            img.ImageData = data;

            return (img);

        }
    }
}
