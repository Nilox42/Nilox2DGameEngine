using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Map
{
    public class Tile 
    {
        public string name = null;
        public int tilesize = 20;

        public int locationX = 0;
        public int locationY = 0;

        #region mapreferences
        public string[,] mapref =
        {
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
            {"w","s","s","s","s","s","s","s","s","s","s","s","s","s","w"},
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
        public string[,] newmap =
        {
                {"o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14"}, // 1
                {"o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14"},// 2
                {"o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14"},// 3
                {"o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14"},// 4
                {"o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14","o_tile14"},// 5
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},                                                                                                                  // 6
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 7
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 8
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 9
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 10
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 11
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 12
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 13
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 14
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 15
        };

        public string[,] newmap2 =
        {
            //1            2        3        4        5        6        7        8        9        10       11       12       13       14       15       16       17       18       19       20       21       22       23       24       25       26       27
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 1
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 2
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 3
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 4
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 5
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 6
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 7
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 8
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 9
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 10
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 11
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 12
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 13
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 14
            {"tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10","tile10"},// 15
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 16
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 17
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 18
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 19
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 20
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 21
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 22
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 23
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 24
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 25
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."},// 26
            {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","."}// 27
        };
        #endregion
        public string[,] map;

        public Tile()
        {

        }
        public Tile(bool b, string name0 , int tilesize0)
        {
            map = newmap2;
            name = name0;
            tilesize = tilesize0;
        }
        public Tile(string string0 , int size)
        {
            map = Converts.stringToArray(string0, size);
        }
        public Tile(string[,] Map)
        {
            this.map = Map;
        }
        public Tile(string[,] map0,string name0)
        {
            this.map = map0;
            this.name = name0;
        }


    }
}