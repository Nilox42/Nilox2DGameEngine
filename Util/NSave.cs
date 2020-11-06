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
        public static void TilesS(List<Tile> tiles0 , string directory0)
        {
            foreach (Tile tile in tiles0)
            {
                if (File.Exists(directory0))
                {
                    StreamWriter writer = new StreamWriter(directory0 + @"\" + tile.name + ".txt");
                    writer.WriteLine(Converts.TileToString(tile));
                }
            }
        }
        //
        //-----------------------------------------------------------------------------------------------------------------------------------
        //
        public static void TileS(Tile tile0, string directory0)
        {
            if (Directory.Exists(directory0))
            {
                Log.Save("[Tile]  - Name:" + tile0.name + "  URL:" + directory0);

                StreamWriter writer = new StreamWriter(directory0 + @"\" + tile0.name + ".txt");
                writer.WriteLine(Converts.TileToString(tile0));
                writer.Dispose();
            }
            else
            {
                Log.Error("[Tile]  :  Directory  {" + directory0 + "}  does not exist!!! Try:{" + directory0 + @"\" + tile0.name + ".txt}");
            }
        }



    }
}
