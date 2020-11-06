using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Map;

namespace Nilox2DGameEngine.Util
{
    public class Converts
    {

        public static string[,] stringToArray(string s0, int tilesize)
        {
            string[,] Map0 = new string[tilesize, tilesize];

            string[] s = s0.Split(':');

            int count = 0;
            for (int i = 0; i < tilesize; i++)
            {
                for (int j = 0; j < tilesize; j++)
                {
                    Map0[i, j] = s[count];
                    ++count;
                }
            }
            return Map0;
        }
        public static string arrayToString(string[,] Map)
        {
            string result = "";
            foreach (string s in Map)
            {
                result = result + s + ":";
            }

            //Removes last :
            result = result.Remove(result.Length - 1 ,1);

            return result;
        }

        public static Tile StringToTile(string s0)
        {
            Tile t = new Tile();
            string[] s = s0.Split('|');

            t.name = s[0];
            t.TileSize = Convert.ToInt32(s[1]);
            t.locationX = Convert.ToInt32(s[2]);
            t.locationY = Convert.ToInt32(s[3]);

            t.Map = Converts.stringToArray(s[4], t.TileSize);

            return t;
        }

        public static string TileToString(Tile t0)
        {
            string result = null;

            result = result + t0.name + "|";
            result = result + t0.TileSize.ToString() + "|";
            result = result + t0.locationX.ToString() + "|";
            result = result + t0.locationY.ToString() + "|";

            result = result + Converts.arrayToString(t0.Map);


            return result;
        }


    }
}
