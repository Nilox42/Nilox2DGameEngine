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
        #region Tiles
        public static List<Tile> tilesL( string directory0)
        {
            string[] files = Directory.GetFiles(directory0);
            List<Tile> tiles1 = new List<Tile>();

            foreach (string s in files)
            {
                //Load Tiles
                tiles1.Add(tileL(s));
            }

            Log.load($"[NLoad] - [Tiles]  loaded {tiles1.Count} Tiles");
            return tiles1;
        }
        public static Tile tileL(string directory0)
        {
            //Load Tile a
            Tile tile = Converts.stringToTile(readLine(directory0, 0));
            //Loadenemies
            tile.enemies = readLine(directory0, 1);

            Log.load("[NLoad]  -  Tile:" + tile.name + "From:" + directory0);
            return tile;
        }
        #endregion
        //
        //-----------------------------------------------------------------------------------------------------------------------------------
        //
        #region Images
        public static void imagesfromDirectory(string directory0, List<BaseImage> baseImages)
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
                    Log.error("[Nload]  -  [IfD]File is not a PNG");
                }
            }
        }
        #endregion
        //
        //-----------------------------------------------------------------------------------------------------------------------------------
        //
        #region functions
        public static string readLine(string directory, int line)
        {
            return File.ReadLines(directory).Skip(line).Take(1).First();
        }
        #endregion


    }
}
