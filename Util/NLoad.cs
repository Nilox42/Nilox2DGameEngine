﻿using System;
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
        public static List<Tile> tilesL(string directory0, GameMode gm)
        {
            string[] files = Directory.GetFiles(directory0);
            List<Tile> tiles1 = new List<Tile>();

           

            int index = 0;
            foreach (string s in files)
            {
                Log.load("[NLoad] - [Tiles] Tile:" + index.ToString() + "From:" + s);

                string enemies = string.Empty;
                Tile buffer;

                //Load enemie spawnlist (Decoded in Tile)
                enemies = readLine(directory0,2);

                //Load Sprites (Map)
                buffer = Converts.StringToTile(readLine(directory0, 1));
                ++index;
            }

            return tiles1;
        }
        public static Tile tileL(string directory0)
        {
            Tile tile;
            int index = 0;

            Log.load("[NLoad] - [Tiles] Tile:" + index.ToString() + "From:" + directory0);
            tile = Converts.StringToTile(readLine(directory0, 1));
            ++index;

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
            return File.ReadLines(directory).Skip(line - 1).Take(1).First();
        }
        #endregion


    }
}
