using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextBasedRPG.ItemPickups
{
    class FirstAid : Item
    {
        //adds health on pickup
        public FirstAid(int X, int Y)
        {
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = Global.firstAidAppearance;
            itemTile.tileColour = Global.firstAidColour;
            itemType = ItemType.FirstAid;
            name = ItemType.FirstAid.ToString();
            Random rand = new Random();
        }
        public override void Update(Map map, Player player, Inventory inventory, MvmtCamera camera, ItemManager itemManager)
        {
            if (pickedUp == true)
            {
                //player.Heal(10);
                inventory.addItemToInventory(this);
                infoMessage = "You have found a " + name +"!";
                base.Update(map, player, inventory, camera, itemManager);
                itemTile.tileCharacter = '+';
                xLoc = 0;
                yLoc = 0;
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
                player.Heal(Global.firstAidHP);
                pickedUp = false;
                used = false;
                itemTile.tileCharacter = ' ';
            }
        }
    }
}
