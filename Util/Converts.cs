using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Map;
using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine.Util
{
    public class Converts
    {
        #region MapArrayConverts
        public static string[,] stringToArray(string s0, int tilesize)
        {
            string[,] map0 = new string[tilesize, tilesize];

            string[] s = s0.Split(':');

            int count = 0;
            for (int i = 0; i < tilesize; i++)
            {
                for (int j = 0; j < tilesize; j++)
                {
                   map0[i, j] = s[count];
                   
                    ++count;
                }
            }
            return map0;
        }
        public static string arrayToString(string[,] map)
        {
            string result = "";
            foreach (string s in map)
            {
                result = result + s + ":";
            }

            //Removes last :
            result = result.Remove(result.Length - 1, 1);

            return result;
        }
        #endregion
        //
        //
        //
        #region String Tiel Converts
        public static Tile StringToTile(string s0)
        {
            Tile t = new Tile();
            string[] s = s0.Split('|');
            
            t.name = s[0];                                          //0  Set name
            t.tilesize = Convert.ToInt32(s[1]);                     //1  Set tilesize
            t.locationX = Convert.ToInt32(s[2]);                    //2  Set location x
            t.locationY = Convert.ToInt32(s[3]);                    //3  Set location y
            t.spawnlocation.X = Convert.ToInt32(s[4]);              //4  Set spawnlocation X
            t.spawnlocation.Y = Convert.ToInt32(s[5]);              //5  Set spawnlocation Y
            t.map = Converts.stringToArray(s[6], t.tilesize);       //6  Set Map string

            return t;
        }
        public static string TileToString(Tile t0)
        {
            string result = null;

            result = result + t0.name + "|";                        //0  Add name
            result = result + t0.tilesize.ToString() + "|";         //1  Add tilesize
            result = result + t0.locationX.ToString() + "|";        //2  Add location x
            result = result + t0.locationY.ToString() + "|";        //3  Add location y
            result = result + t0.spawnlocation.X.ToString() + "|";  //4  Add spawnlocation X
            result = result + t0.spawnlocation.Y.ToString() + "|";  //5  Add spawnlocation Y
            result = result + Converts.arrayToString(t0.map);       //6  Add Map string

            return result;
        }
        #endregion
        //
        //
        //
        #region location Converts
        public static Vector2 toScreenLocation(Vector2 gamelocation)
        {
            return gamelocation + Engine.cameraPos;
        }
        public static Vector2 toGameLocation(Vector2 screenLocation)
        {
            return screenLocation - Engine.cameraPos;
        }
        #endregion
    }
}
