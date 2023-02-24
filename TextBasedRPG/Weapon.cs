using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Weapon : Item
    {

            //integer for weapon pickup

            public Weapon(int X, int Y, ItemType weaponPickUp)
            {
                itemType = weaponPickUp;
                pickedUp = false;
                xLoc = X;
                yLoc = Y;
                itemTile.tileCharacter = 'W';
            }
            public override void Update(Map map, Player player, Inventory inventory, MvmtCamera camera, ItemManager itemManager)
            {
                if (pickedUp == true)
                {
                    xLoc = 0;
                    yLoc = 0;
                    if (itemType == ItemType.BrassKnuckles) { inventory.addItemToInventory(this); infoMessage = "You've picked up Brass Knuckles"; base.Update(map, player, inventory, camera, itemManager); }
                    if (itemType == ItemType.BaseballBat) { inventory.addItemToInventory(this); infoMessage = "You've picked up a Baseball Bat"; base.Update(map, player, inventory, camera, itemManager); }
                    if (itemType == ItemType.Knife) { inventory.addItemToInventory(this); infoMessage = "You've picked up a Knife"; base.Update(map, player, inventory, camera, itemManager); }
                    if (itemType == ItemType.Axe) { inventory.addItemToInventory(this); infoMessage = "You've picked up an Axe"; base.Update(map, player, inventory, camera, itemManager); }
                    if (itemType == ItemType.Chainsaw) { inventory.addItemToInventory(this); infoMessage = "You've picked up a Chainsaw!"; base.Update(map, player, inventory, camera, itemManager); }
                    pickedUp = false;
                }

                if (dropped == true)
                {

                    xLoc = player.xLoc;
                    yLoc = player.yLoc;
                    dropped = false;
                }
                if (used == true)
                {
                    if (player.weaponInHand.itemType == ItemType.Fist)
                    {

                    }

                    else if (player.weaponInHand.itemType == ItemType.BrassKnuckles) { itemManager.CheckandSwitchWeap('W', ItemType.BrassKnuckles, inventory); }
                    else if (player.weaponInHand.itemType == ItemType.BaseballBat) { itemManager.CheckandSwitchWeap('W', ItemType.BrassKnuckles, inventory); }
                    else if (player.weaponInHand.itemType == ItemType.Knife) { itemManager.CheckandSwitchWeap('W', ItemType.Knife, inventory); }
                    else if (player.weaponInHand.itemType == ItemType.Axe) { itemManager.CheckandSwitchWeap('W', ItemType.Axe, inventory); }
                    else if (player.weaponInHand.itemType == ItemType.Chainsaw) { itemManager.CheckandSwitchWeap('W', ItemType.Chainsaw, inventory); }

                    if (itemType == ItemType.BrassKnuckles) { SwitchWeap(ItemType.BrassKnuckles, player); }
                    if (itemType == ItemType.BaseballBat) { SwitchWeap(ItemType.BaseballBat, player); }
                    if (itemType == ItemType.Knife) { SwitchWeap(ItemType.Knife, player); }
                    if (itemType == ItemType.Axe) { SwitchWeap(ItemType.Axe, player); }
                    if (itemType == ItemType.Chainsaw) { SwitchWeap(ItemType.Chainsaw, player); }
                    pickedUp = false;
                    used = false;
                }


            }
            public void SwitchWeap(ItemType newWeapon, Player player)
            {
                //weapon damage and display to user

                itemType = newWeapon;
                switch (itemType)
                {
                    case ItemType.BrassKnuckles:
                        player.weaponInHand.itemType = ItemType.BrassKnuckles;
                        player.attackDamage = 10;
                        break;
                    case ItemType.BaseballBat:
                        player.weaponInHand.itemType = ItemType.BaseballBat;
                        player.attackDamage = 25;
                        break;
                    case ItemType.Knife:
                        player.weaponInHand.itemType = ItemType.Knife;
                        player.attackDamage = 50;
                        break;
                    case ItemType.Axe:
                        player.weaponInHand.itemType = ItemType.Axe;
                        player.attackDamage = 75;
                        break;
                    case ItemType.Chainsaw:
                        player.weaponInHand.itemType = ItemType.Chainsaw;
                        player.attackDamage = 100;
                        break;

                }
            }

    }
}

