using Cfd.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Cfd.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
       // public MenuItem MenuItem { get; set; }


        public Image Add (string filename)
        {
            Image img = new Image();
            byte[] data = ReadBinaryFile.ReadFile(filename);
            img.ImageData = data;

            return (img);

        }
    }
}
