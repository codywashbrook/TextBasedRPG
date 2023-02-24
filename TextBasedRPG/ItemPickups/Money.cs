using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Money : Item
    {
        public Money(int X, int Y)
        {
            //money stats


            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = '$';
            itemType = ItemType.Money;
        }
        public override void Update(Map map, Player player, Inventory inventory, MvmtCamera camera, ItemManager itemManager)
        {
            if (pickedUp == true)
            {
                player.CollectMoney(100);
                itemTile.tileCharacter = ' ';
                xLoc = 0;
                yLoc = 0;
                pickedUp = false;
            }

        }
    }
}
