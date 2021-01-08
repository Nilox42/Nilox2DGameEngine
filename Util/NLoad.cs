using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
//
using Nilox2DGameEngine.Map;
using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine.Util
{
    class NLoad
    {
        public static List<Tile> TilesL(string directory0)
        {
            string[] files = Directory.GetFiles(directory0);
            List<Tile> tiles1 = new List<Tile>();

            int index = 0;
            foreach (string s in files)
            {
                Log.Load("[NLoad] - [Tiles] Tile:" + index.ToString() + "From:" + s);
                tiles1.Add(Converts.StringToTile(File.ReadLines(s).Skip(0).Take(1).First()));
                ++index;
            }

            return tiles1;
        }
        public static Tile TileL(string directory0)
        {
            Tile tile = new Tile();

            int index = 0;

            Log.Load("[NLoad] - [Tiles] Tile:" + index.ToString() + "From:" + directory0);
            tile = Converts.StringToTile(File.ReadLines(directory0).Skip(0).Take(1).First());
            ++index;

            return tile;
        }
        //
        //-----------------------------------------------------------------------------------------------------------------------------------
        //
        public static void ImagesfromDirectory(string directory0, List<BaseImage> baseImages)
        {
            string dir = directory0;
            foreach (string s in Directory.GetFiles(dir))
            {
                string ext = Path.GetExtension(s);
                if (ext == ".png")
                {
                    string name0 = Path.GetFileNameWithoutExtension(s);
                    string[] name00 = name0.Split('§');

                    string name = name00[0];

                    string tag = "";
                    if (name00.Length == 2)
                    {
                        tag = name00[1];
                    }

                    Image tmp = Image.FromFile(s);
                    Bitmap sprite = new Bitmap(tmp);

                    BaseImage b = new BaseImage(name, tag, s, sprite);

                    baseImages.Add(b);
                }
                else 
                {
                    Log.Error("[Nload]  -  [IfD]File is not a PNG");
                }
            }
        }
        //
        //-----------------------------------------------------------------------------------------------------------------------------------
        //



    }
}
