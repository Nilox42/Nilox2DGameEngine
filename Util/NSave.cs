using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using Nilox2DGameEngine.Map;
using Nilox2DGameEngine.Core;
using System.Threading;

namespace Nilox2DGameEngine.Util
{
    class NSave
    {
        public static void tilesS(List<Tile> tiles0 , string directory0)
        {
            foreach (Tile tile in tiles0)
            {
                if (File.Exists(directory0))
                {
                    StreamWriter writer = new StreamWriter(directory0 + @"\" + tile.name + ".txt");
                    writer.WriteLine(Converts.TileToString(tile));
                    writer.WriteLine(tile.enemies);
                    writer.Dispose();
                }
            }
        }
        //
        //-----------------------------------------------------------------------------------------------------------------------------------
        //
        public static void tileS(Tile tile0, string directory0)
        {
            if (Directory.Exists(directory0))
            {
                Log.save("[Tile]  -  Name:" + tile0.name + "  -  URL:" + directory0 + @"\" + tile0.name + ".txt");

                StreamWriter writer = new StreamWriter(directory0 + @"\" + tile0.name + ".txt");
                writer.WriteLine(Converts.TileToString(tile0));
                writer.WriteLine(tile0.enemies);
                writer.Dispose();
            }
            else
            {
                Log.error("[Tile]  :  Directory  {" + directory0 + @"\" + tile0.name + ".txt }  does not exist!!!");
            }
        }



    }
}
