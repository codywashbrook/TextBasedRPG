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
                itemTile.tileCharacter = Global.weaponAppearance;
                itemTile.tileColour = Global.weaponColour;
                if (itemType == ItemType.BrassKnuckles) { name = ItemType.BrassKnuckles.ToString(); }
                else if (itemType == ItemType.BaseballBat) { name = ItemType.BaseballBat.ToString(); }
                else if (itemType == ItemType.Knife) { name = ItemType.Knife.ToString(); }
                else if (itemType == ItemType.Axe) { name = ItemType.Axe.ToString(); }
                else if (itemType == ItemType.Chainsaw) { name = ItemType.Chainsaw.ToString(); }
                Random rand = new Random();
            }
            public override void Update(Map map, Player player, Inventory inventory, MvmtCamera camera, ItemManager itemManager)
            {
                if (pickedUp == true)
                {
                    xLoc = 0;
                    yLoc = 0;
                    if (itemType == ItemType.BrassKnuckles) { inventory.addItemToInventory(this); infoMessage = "You've found a " + name +"!"; base.Update(map, player, inventory, camera, itemManager); }
                    if (itemType == ItemType.BaseballBat) { inventory.addItemToInventory(this); infoMessage = "You've found a " + name + "!"; base.Update(map, player, inventory, camera, itemManager); }
                    if (itemType == ItemType.Knife) { inventory.addItemToInventory(this); infoMessage = "You've found a " + name + "!"; base.Update(map, player, inventory, camera, itemManager); }
                    if (itemType == ItemType.Axe) { inventory.addItemToInventory(this); infoMessage = "You've found a " + name + "!"; base.Update(map, player, inventory, camera, itemManager); }
                    if (itemType == ItemType.Chainsaw) { inventory.addItemToInventory(this); infoMessage = "You've found a " + name + "!"; base.Update(map, player, inventory, camera, itemManager); }
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
                case ItemType.Fist:
                    player.weaponInHand.itemType = ItemType.Fist;
                    player.attackDamage = Global.fistDamage;
                    break;
                case ItemType.BrassKnuckles:
                    player.weaponInHand.itemType = ItemType.BrassKnuckles;
                    player.attackDamage = Global.BKDamage;
                    break;
                case ItemType.BaseballBat:
                    player.weaponInHand.itemType = ItemType.BaseballBat;
                    player.attackDamage = Global.BBBDamage;
                    break;
                case ItemType.Knife:
                    player.weaponInHand.itemType = ItemType.Knife;
                    player.attackDamage = Global.knifeDamage;
                    break;
                case ItemType.Axe:
                    player.weaponInHand.itemType = ItemType.Axe;
                    player.attackDamage = Global.axeDamage;
                    break;
                case ItemType.Chainsaw:
                    player.weaponInHand.itemType = ItemType.Chainsaw;
                    player.attackDamage = Global.chainsawDamage;
                    break;
            }
        }
    }
}

