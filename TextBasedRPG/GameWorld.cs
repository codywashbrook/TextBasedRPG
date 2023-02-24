using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class GameWorld
    {
        // map size

        public char[,] world = new char[269, 63];
        public string[] worldData;
        public string currWorldLine;
        private char worldTile;
        private int x;
        private int y;

        public GameWorld()
        {
            //mapData reads file through lines - Gets Y
            worldData = System.IO.File.ReadAllLines("MapWorld.txt");
            for (y = 0; y <= worldData.Length - 1; y = y + 1)
            {
                //string created to be = to 1 / current line of map
                currWorldLine = worldData[y];
                for (x = 0; x <= currWorldLine.Length - 1; x = x + 1)
                {
                    worldTile = currWorldLine[x];

                    world[x, y] = worldTile;
                }
            }
        }
        public void InitAll(EnemyManager enemyManager, ItemManager itemManager, Player player)
        {
            for (int y = 0; y < worldData.Length; y++)
            {
                for (int x = 0; x < currWorldLine.Length; x++)
                {
                    enemyManager.InitEnemyWorldLoc(world, x, y);
                    itemManager.InitItemLoc(world, x, y);
                    player.InitPlayerWorldLoc(world, x, y);
                }
            }
        }
    }
}
