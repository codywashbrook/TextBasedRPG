using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextBasedRPG
{
    class Player : Character
    {
        private bool wallExist;
        private bool enemyExist;
        private bool itemExist;
        public int collectedMoney;
        public Item weaponInHand;


        public Player()
        {
            //loads player stats

            SwitchVitalStatus(VitalStatus.Alive);
            characterTile.tileCharacter = '@';
            characterTile.tileColour = ConsoleColor.Cyan;
            health = 100;
            armor = 0;
            collectedMoney = 0;
            name = "DB Cooper";
            weaponInHand = new Item();
            BecomeUnarmed();

        }

        //specific to the player

        public void BecomeUnarmed()
        {
            weaponInHand.itemType = Item.ItemType.Fist;
            attackDamage = 5;
        }
        public void CollectMoney(int money)
        {
            collectedMoney = collectedMoney + money;
        }
        public void InitPlayerWorldLoc(char[,] world, int X, int Y)
        {
            if (world[X, Y] == '@') { xLoc = X; yLoc = Y; }
        }
        public void Update(Map map, EnemyManager enemyManager, ItemManager itemManager, GameOver gameOver, Inventory inventory)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            if (vitalStatus == VitalStatus.Alive)
            {
                if (keyPressed.Key == ConsoleKey.W)
                {
                    //collision
                    if (wallExist = map.IsWallAt(xLoc, yLoc - 1))
                    {
                        //do nothing 
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc, yLoc - 1))
                    {
                        enemyManager.CheckEnemy(xLoc, yLoc - 1, attackDamage);
                    }
                    else if (itemExist = itemManager.WhereIsItem(xLoc, yLoc - 1))
                    {

                        if (inventory.IsInventorySlotAvailable() == true)
                        {
                            itemManager.CheckAndPickupItems(xLoc, yLoc - 1);
                        }
                        else
                        {
                            inventory.inventoryIsFull = true;
                        }
                    }
                    else
                    {
                        yLoc = yLoc - 1;
                    }
                }
                if (keyPressed.Key == ConsoleKey.A)
                {
                    if (wallExist = map.IsWallAt(xLoc - 1, yLoc))
                    {
                        //null
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc - 1, yLoc))
                    {
                        enemyManager.CheckEnemy(xLoc - 1, yLoc, attackDamage);
                    }
                    else if (itemExist = itemManager.WhereIsItem(xLoc - 1, yLoc))
                    {

                        if (inventory.IsInventorySlotAvailable() == true)
                        {
                            itemManager.CheckAndPickupItems(xLoc - 1, yLoc);
                        }
                        else
                        {
                            inventory.inventoryIsFull = true;
                        }
                    }
                    else
                    {
                        xLoc = xLoc - 1;
                    }
                }
                if (keyPressed.Key == ConsoleKey.S)
                {
                    if (wallExist = map.IsWallAt(xLoc, yLoc + 1))
                    {
                        //null
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc, yLoc + 1))
                    {
                        enemyManager.CheckEnemy(xLoc, yLoc + 1, attackDamage);
                    }
                    else if (itemExist = itemManager.WhereIsItem(xLoc, yLoc + 1))
                    {
                        if (inventory.IsInventorySlotAvailable() == true)
                        {
                            itemManager.CheckAndPickupItems(xLoc, yLoc + 1);
                        }
                        else
                        {
                            inventory.inventoryIsFull = true;
                        }
                    }
                    else
                    {
                        yLoc = yLoc + 1;
                    }
                }
                if (keyPressed.Key == ConsoleKey.D)
                {
                    if (wallExist = map.IsWallAt(xLoc + 1, yLoc))
                    {
                        //null
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc + 1, yLoc))
                    {
                        enemyManager.CheckEnemy(xLoc + 1, yLoc, attackDamage);
                    }
                    else if (itemExist = itemManager.WhereIsItem(xLoc + 1, yLoc))
                    {
                        if (inventory.IsInventorySlotAvailable() == true)
                        {
                            itemManager.CheckAndPickupItems(xLoc + 1, yLoc);
                        }
                        else
                        {
                            inventory.inventoryIsFull = true;
                        }
                    }
                    else
                    {
                        xLoc = xLoc + 1;
                    }
                }
                if (keyPressed.Key == ConsoleKey.I)
                {
                    inventory.inventoryIsOpen = true;
                }

                //collect money to win

                if (collectedMoney >= 600)
                {
                    gameOver.gameOverWin = true;
                }
            }
            else
            {
                SwitchVitalStatus(VitalStatus.Dead);
            }
            //if dead, then gameover

            if (vitalStatus == VitalStatus.Dead)
            {
                gameOver.gameOverDead = true;
            }
        }
        //detect collision with player
        public bool isPlayerAt(int x, int y)
        {

            if (x == xLoc)
            {
                if (y == yLoc)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
