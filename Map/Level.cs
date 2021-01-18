using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Map
{
    public class Level 
    {
        #region Init
        GameMode gm;

        public string worldname = null;
        string directory = null;
        public Vector2 currentlocation = new Vector2(0,0);

        public List<Tile> tiles = new List<Tile>();

        bool hasendet = false;

        /*
        public string[,] Map =
        {
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","dr"},
            {"g","g","g","g","g","g","g","g","g","g","g","g","g","g","g"},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
        };
        public string[,] Map2 =
        {
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"dl","s","s","s","s","s","s","s","s","s","s","s","s","s","dr"},
            {"g","g","g","g","g","g","g","g","g","g","g","g","g","g","g"},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},
        };
        */

        public Level(string name0,GameMode gm0)
        {
            worldname = name0;
            directory = Application.StartupPath + @"\Levels\" + worldname;
            gm = gm0;

            tiles = NLoad.tilesL(directory);
            foreach (Tile t in tiles)
            {
                t.level = this;
                t.gm = gm;
            }

            gm.currentLevel = this;
            gm.loadNewTile(tiles.ElementAt(0));
        }
        #endregion
        //
        //
        //
        #region LevelMovement
        public void moveRight()
        {
            if (currentlocation.X < tiles.Count - 1)
            {
                Log.info("[MOVEMENT] Moving RIGHT | " + currentlocation.X + "-->" + (currentlocation.X + 1).ToString());

                gm.canmoveon = false;
                gm.ismoving = true;

                gm.unloadCurrentTile();
                gm.spawnPosition = new Vector2(50, 48 * 4);
                currentlocation = new Vector2(currentlocation.X + 1, currentlocation.Y);

                //GM.LoadNewTile(new Tile(Map2,"right"));
                gm.loadNewTile(tiles.ElementAt(Convert.ToInt32(currentlocation.X)));
            }
            else
            {
                Log.error("[MOVEMENT] Cant walk RIGHT here | currentlocation.X:" + currentlocation.X);
                gm.endGame();
            }
        }
        public void moveLeft()
        {
            if (currentlocation.X > 0)
            {
                Log.info("[MOVEMENT] Moving LEFT | " + currentlocation.X + "-->" + (currentlocation.X - 1).ToString());

                gm.canmoveback = false;
                gm.ismoving = true;

                gm.unloadCurrentTile();
                gm.spawnPosition = new Vector2(48 * 13, 48 * 4);
                currentlocation = new Vector2(currentlocation.X - 1, currentlocation.Y);

                //GM.LoadNewTile(new Tile(Map,"left"));
                gm.loadNewTile(tiles.ElementAt(Convert.ToInt32(currentlocation.X)));
            }
            else
            {
                Log.error("[MOVEMENT] Cant walk LEFT here | currentlocation.X:" + currentlocation.X);
                gm.endGame();
            }
        }
        #endregion
    }
}
