using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class HUD
    {
        private string clear = "                                                                                                     ";
        public void DisplayHUD(Player player, EnemyManager enemyManager, MvmtCamera camera, Inventory inventory)
        {
            //HUD stats

            //prevent overlap

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, camera.endViewY + 2);
            Console.WriteLine(clear);
            Console.Write(player.name + " health: " + player.health + "             " + player.xLoc + ", " + player.yLoc);
            Console.WriteLine(clear);
            Console.Write(player.name + " armor: " + player.armor);
            Console.WriteLine(clear);
            Console.Write(player.name + " weapon in hand: " + player.weaponInHand.itemType);
            Console.WriteLine(clear);
            Console.Write("stolen moneybags recovered: " + player.collectedMoney + "/7");
            Console.WriteLine(clear);
            Console.Write("hit 'i' to open inventory");
            if (inventory.inventoryIsFull == true)
            {
                Console.WriteLine(clear);
                Console.Write("INVENTORY FULL");
            }
            Console.WriteLine();

            //display close enemy stats
            for (int i = 0; i < enemyManager.enemyCount; i++)
            {
                if ((player.xLoc <= enemyManager.enemies[i].xLoc + 5) && (player.xLoc >= enemyManager.enemies[i].xLoc - 5) && (player.yLoc <= enemyManager.enemies[i].yLoc + 5) && (player.yLoc >= enemyManager.enemies[i].yLoc - 5))
                {
                    Console.WriteLine(clear);
                    Console.Write(enemyManager.enemies[i].name + " enemy number " + i + "'s health: " + enemyManager.enemies[i].health);
                }
            }
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
        }
    }
}
