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
        public Weapon weaponInHand = new Weapon(0, 0, Item.ItemType.Fist);

        private int previousXLoc;
        private int previousYLoc;


        public Player()
        {
            //loads player stats

            SwitchVitalStatus(VitalStatus.Alive);
            characterTile.tileCharacter = Global.playerAppearance;
            characterTile.tileColour = Global.playerColour;
            health = Global.playerHealth;
            armor = Global.playerShield;
            healthCap = Global.playerHealth;
            armorCap = Global.playerShield;
            name = Global.playerName;
            collectedMoney = 0;

            if (Global.playerStartingWeapon == Item.ItemType.Fist.ToString()) { weaponInHand.SwitchWeap(Item.ItemType.Fist, this); }
            if (Global.playerStartingWeapon == Item.ItemType.BrassKnuckles.ToString()) { weaponInHand.SwitchWeap(Item.ItemType.BrassKnuckles, this); }
            if (Global.playerStartingWeapon == Item.ItemType.BaseballBat.ToString()) { weaponInHand.SwitchWeap(Item.ItemType.BaseballBat, this); }
            if (Global.playerStartingWeapon == Item.ItemType.Knife.ToString()) { weaponInHand.SwitchWeap(Item.ItemType.Knife, this); }
            if (Global.playerStartingWeapon == Item.ItemType.Axe.ToString()) { weaponInHand.SwitchWeap(Item.ItemType.Axe, this); }
            if (Global.playerStartingWeapon == Item.ItemType.Chainsaw.ToString()) { weaponInHand.SwitchWeap(Item.ItemType.Chainsaw, this); }
            else if (Global.playerStartingWeapon == null || Global.playerStartingWeapon == "") { weaponInHand.SwitchWeap(Item.ItemType.Fist, this); }

            previousXLoc = xLoc;
            previousYLoc = yLoc;

        }

        //specific to the player

        public void BecomeUnarmed()
        {
            weaponInHand.itemType = Item.ItemType.Fist;
            attackDamage = 5;
        }
        public void CollectMoney()
        {
            collectedMoney++;
        }
        public void InitPlayerWorldLoc(char[,] world, int X, int Y)
        {
            if (world[X, Y] == Global.playerAppearance) { xLoc = X; yLoc = Y; }
        }
        public void Update(Map map, EnemyManager enemyManager, ItemManager itemManager, GameOver gameOver, Inventory inventory)
        {
            Console.CursorVisible = false;
            ConsoleKey keyPressed = Console.ReadKey(true).Key;
            if (vitalStatus == VitalStatus.Alive)
            {
                if (keyPressed == ConsoleKey.W)
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
                    else if (itemExist = itemManager.WhereIsItem(xLoc, yLoc - 1) && inventory.settingUpInventory == false)
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
                        previousXLoc = xLoc;
                        previousYLoc = yLoc;
                        yLoc = yLoc - 1;
                    }
                }
                if (keyPressed == ConsoleKey.A)
                {
                    if (wallExist = map.IsWallAt(xLoc - 1, yLoc))
                    {
                        //do nothing
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
                        previousXLoc = xLoc;
                        previousYLoc = yLoc;
                        xLoc = xLoc - 1;
                    }
                }
                if (keyPressed == ConsoleKey.S)
                {
                    if (wallExist = map.IsWallAt(xLoc, yLoc + 1))
                    {
                        //do nothing
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
                        previousXLoc = xLoc;
                        previousYLoc = yLoc;
                        yLoc = yLoc + 1;
                    }
                }
                if (keyPressed == ConsoleKey.D)
                {
                    if (wallExist = map.IsWallAt(xLoc + 1, yLoc))
                    {
                        //do nothing
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
                        previousXLoc = xLoc;
                        previousYLoc = yLoc;
                        xLoc = xLoc + 1;
                    }
                }
                if (keyPressed == ConsoleKey.I)
                {
                    inventory.inventoryIsOpen = true;
                }
                //determines win
                if (collectedMoney >= itemManager.moneyCount)
                {
                    gameOver.gameOverWin = true;
                }
            }
            else
            {
                SwitchVitalStatus(VitalStatus.Dead);
            }
            //determines loss...
            if (vitalStatus == VitalStatus.Dead)
            {
                gameOver.gameOverDead = true;
            }
        }
        //for others to detect collision with player
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

        public void ReturnToLastPosition()
        {
            xLoc = previousXLoc;
            yLoc = previousYLoc;
        }
    }
}
