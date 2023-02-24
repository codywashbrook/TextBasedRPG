using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Map
    {
        public char[,] map = new char[276, 44]; // size of map
        public string[] mapData;
        public string currMapLine;
        public bool openDoors = false;
        private char mapTile;
        private int x;
        private int y;

        public Tile water = new Tile('~', ConsoleColor.Blue);
        public Tile grass = new Tile('`', ConsoleColor.Green);
        public Tile hill = new Tile('^', ConsoleColor.DarkGray);
        public Tile mountain = new Tile('7', ConsoleColor.DarkGray);
        public Tile floor = new Tile('=', ConsoleColor.DarkGray);
        public Tile path = new Tile('#', ConsoleColor.Yellow);
        public Tile verticalWall = new Tile('-', ConsoleColor.Gray);
        public Tile horizontalWall = new Tile('|', ConsoleColor.Gray);
        public Tile cornerWallLeft = new Tile('<', ConsoleColor.Gray);
        public Tile cornerWallRight = new Tile('>', ConsoleColor.Gray);

        //loads map
        public Map()
        {
            //mapData reads file through lines - Gets Y
            mapData = System.IO.File.ReadAllLines("map.txt");
            for (y = 0; y <= mapData.Length - 1; y = y + 1)
            {
                //string created to be = to 1 / current line of map
                currMapLine = mapData[y];
                for (x = 0; x <= currMapLine.Length - 1; x = x + 1)
                {
                    //map tile is = to map line split by x
                    mapTile = currMapLine[x];
                    //map[x,y] is = to map tile for exact location
                    map[x, y] = mapTile;
                }
            }
        }
        //to colour map
        public void ShowMapColours(char[,] renderer, int x, int y, int offsetX, int offsetY)
        {
            grass.ShowTileColour(renderer, x, y, offsetX, offsetY);
            hill.ShowTileColour(renderer, x, y, offsetX, offsetY);
            mountain.ShowTileColour(renderer, x, y, offsetX, offsetY);
            water.ShowTileColour(renderer, x, y, offsetX, offsetY);
            horizontalWall.ShowTileColour(renderer, x, y, offsetX, offsetY);
            verticalWall.ShowTileColour(renderer, x, y, offsetX, offsetY);
            floor.ShowTileColour(renderer, x, y, offsetX, offsetY);
            cornerWallLeft.ShowTileColour(renderer, x, y, offsetX, offsetY);
            cornerWallRight.ShowTileColour(renderer, x, y, offsetX, offsetY);
            path.ShowTileColour(renderer, x, y, offsetX, offsetY);
        }
        //draws map
        public void DrawToRender(char[,] renderer)
        {
            for (int i = 0; i < mapData.Length; i++)
            {
                for (int d = 0; d < currMapLine.Length; d++)
                {
                    renderer[d, i] = map[d, i];
                }
            }
        }


        //for others to detect walls
        public bool IsWallAt(int x, int y)
        {
            //lets you walk on certain tiles not others, cave for future idea
            if (map[x, y] == '=')
            {
                return false;
            }
            else if (map[x, y] == '#')
            {
                return false;
            }
            else if (map[x, y] == '░')
            {
                return false;
            }
            else if (map[x, y] == '`')
            {
                return false;
            }
            //future idea
            if (openDoors == true)
            {
                if (map[x, y] == '▒')
                {
                    return false;
                }
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
