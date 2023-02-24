using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG.ItemPickups
{
    class Armor : Item
    {
        //adds armor
        public Armor(int X, int Y)
        {
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = 'A';
            itemType = ItemType.Armor;
        }
        public override void Update(Map map, Player player, Inventory inventory, MvmtCamera camera, ItemManager itemManager)
        {
            if (pickedUp == true)
            {
                inventory.addItemToInventory(this);
                infoMessage = "You found Armor!";
                base.Update(map, player, inventory, camera, itemManager);
                xLoc = 0;
                yLoc = 0;
                dropped = false;
                pickedUp = false;
            }
            if (dropped == true)
            {

                xLoc = player.xLoc;
                yLoc = player.yLoc;
                pickedUp = false;
                dropped = false;
            }
            if (used == true)
            {
                player.RegenArmor(100);
                pickedUp = false;
                used = false;
                itemTile.tileCharacter = ' ';
            }
        }

    }
}
