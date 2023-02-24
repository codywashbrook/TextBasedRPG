using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class MvmtCamera
    {
        // equal to map
        public char[,] renderer = new char[276, 44];
        public int endViewY;
        public int endViewX;
        public int offsetX;
        public int offsetY;
        private int startViewX = 0;
        private int startViewY = 0;

        public MvmtCamera()
        {
            //can set size of camera
            endViewY = 10;
            endViewX = 35;
        }

        //locking to player
        public void Update(Map map, Player player)
        {
            //always center the player in camera but only if X and Y start is 0
            offsetX = player.xLoc - endViewX / 2;
            offsetY = player.yLoc - endViewY / 2;

            //draws the renderer every update to prevent trails...
            map.DrawToRender(renderer);
        }
        public void Draw(Player player, EnemyManager enemyManager, Map map, ItemManager itemManager)
        {
            //locks camera to top left

            Console.SetCursorPosition(0, 0);

            //white border around cam
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("+");
            for (int t = startViewX; t < endViewX; t++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine();
            for (int y = startViewY; y < endViewY; y++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                for (int x = startViewX; x < endViewX; x++)
                {
                    try
                    {
                        SetColours(x, y, player, enemyManager, map, itemManager);
                        Console.Write(renderer[x + offsetX, y + offsetY]);
                    }
                    catch
                    {
                        Console.Write(" ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("+");
            for (int b = startViewX; b < endViewX; b++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("-");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("+");
            Console.WriteLine();
        }
        public void DrawToRenderer(char character, int x, int y)
        {
            //draawing items to the renderer
            renderer[x, y] = character;
        }
        public void SetColours(int x, int y, Player player, EnemyManager enemyManager, Map map, ItemManager itemManager)
        {
            Console.ForegroundColor = ConsoleColor.White;
            player.characterTile.ShowTileColour(renderer, x, y, offsetX, offsetY);
            enemyManager.SetEnemyColour(renderer, x, y, offsetX, offsetY);
            map.ShowMapColours(renderer, x, y, offsetX, offsetY);
            itemManager.SetItemColour(renderer, x, y, offsetX, offsetY);
        }
    }
}
