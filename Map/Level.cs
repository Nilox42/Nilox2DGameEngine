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
        public string worldname = null;
        string directory = null;
        private Vector2 currentlocation = new Vector2(0,0);

        List<Tile> tiles = new List<Tile>();

        GameMode GM;

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

        public Level(string name0,GameMode DG)
        {
            worldname = name0;
            directory = Application.StartupPath + @"\Levels\" + worldname;

            this.GM = DG;

            tiles = NLoad.TilesL(directory);
            DG.LoadNewTile(tiles.ElementAt(0));
            //DG.LoadNewTile(new Tile(Map));
        }
        #endregion
        //
        //
        //
        #region LevelMovement
        public void moveRight()
        {
            Log.Info("[MOVEMENT] Moving RIGHT | " + currentlocation.X + "-->" + (currentlocation.X + 1).ToString());
            if (currentlocation.X < tiles.Count - 1)
            {
                GM.UnloadCurrentTile();
                GM.spawnPosition = new Vector2(50, 48 * 4);
                currentlocation = new Vector2(currentlocation.X + 1, currentlocation.Y);

                //GM.LoadNewTile(new Tile(Map2,"right"));
                GM.LoadNewTile(tiles.ElementAt((int)currentlocation.X));

            }
            else
            {
                Log.Error("[MOVEMENT] Cant walk RIGHT here | currentlocation.X:" + currentlocation.X);
            }
        }
        public void moveLeft()
        {
            Log.Info("[MOVEMENT] Moving LEFT | " + currentlocation.X + "-->" + (currentlocation.X - 1).ToString());
            if (currentlocation.X > 0)
            {
                GM.UnloadCurrentTile();
                GM.spawnPosition = new Vector2(48 * 13, 48 * 4);
                currentlocation = new Vector2(currentlocation.X - 1, currentlocation.Y);

                //GM.LoadNewTile(new Tile(Map,"left"));
                GM.LoadNewTile(tiles.ElementAt((int)currentlocation.X));
            }
            else
            {
                Log.Error("[MOVEMENT] Cant walk LEFT here | currentlocation.X:" + currentlocation.X);
            }
        }
        #endregion





    }
}
