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

        public string[,] MapREF =
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
        public string[,] NewMAP =
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

        public string[,] Map;

        public Tile()
        {

        }
        public Tile (bool b, string name0 , int tilesize0)
        {
            Map = NewMAP;
            name = name0;
            tilesize = tilesize0;
        }

        public Tile(string string0 , int size)
        {
            Map = Converts.stringToArray(string0, size);
        }

        public Tile(string[,] Map)
        {
            this.Map = Map;
        }

        public Tile(string[,] Map,string name0)
        {
            this.Map = Map;
            this.name = name0;
        }

        






    }
}