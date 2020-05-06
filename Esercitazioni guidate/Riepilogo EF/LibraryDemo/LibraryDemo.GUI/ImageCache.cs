using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDemo.GUI
{
    class ImageCache
    {
        const string COVERS = "../../COVER/";
        
        static Dictionary<string, Image> imagesCache = new Dictionary<string, Image>();
        public static Image Get(string key, byte[] buffer = null)
        {
            if (!imagesCache.TryGetValue(key, out Image img))
            {
                if (buffer == null)
                {
                    var b = Image.FromFile(COVERS+key);
                    img = new Bitmap(b);
                    b.Dispose();
                }
                else
                {
                    var ms = new MemoryStream(buffer);
                    img = new Bitmap(ms);
                }
                imagesCache.Add(key, img);
            }
            return img;
        }
    }
}
