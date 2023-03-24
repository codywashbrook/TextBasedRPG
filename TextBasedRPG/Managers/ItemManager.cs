using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPG.ItemPickups;

namespace TextBasedRPG
{
    class ItemManager
    {
        //makes array

        public Item[] items = new Item[itemCap];
        public int itemCount;
        public int moneyCount;
        //# of enemies

        private static int itemCap = 100;
        public void InitItemLoc(char[,] world, int X, int Y)
        {
            if (itemCount > itemCap - 1) { return; }
            if (world[X, Y] == Global.firstAidAppearance) { items[itemCount] = new FirstAid(X, Y); itemCount = itemCount + 1; }
            if (world[X, Y] == Global.armorAppearance) { items[itemCount] = new Armor(X, Y); itemCount = itemCount + 1; }
            if (world[X, Y] == Global.moneyAppearance) { items[itemCount] = new Money(X, Y); itemCount = itemCount + 1; moneyCount++; }
            if (world[X, Y] == '1') { items[itemCount] = new Weapon(X, Y, Item.ItemType.BrassKnuckles); itemCount = itemCount + 1; }
            if (world[X, Y] == '2') { items[itemCount] = new Weapon(X, Y, Item.ItemType.BaseballBat); itemCount = itemCount + 1; }
            if (world[X, Y] == '3') { items[itemCount] = new Weapon(X, Y, Item.ItemType.Knife); itemCount = itemCount + 1; }
            if (world[X, Y] == '4') { items[itemCount] = new Weapon(X, Y, Item.ItemType.Axe); itemCount = itemCount + 1; }
            if (world[X, Y] == '5') { items[itemCount] = new Weapon(X, Y, Item.ItemType.Chainsaw); itemCount = itemCount + 1; }
        }

        public void CreateItemInInventory(Item.ItemType itemType)
        {
            if (itemCount > itemCap - 1) { return; }
            if (itemType == Item.ItemType.FirstAid) { items[itemCount] = new FirstAid(0, 0); itemCount = itemCount + 1; }
            if (itemType == Item.ItemType.Armor) { items[itemCount] = new Armor(0, 0); itemCount = itemCount + 1; }
            if (itemType == Item.ItemType.BrassKnuckles) { items[itemCount] = new Weapon(0, 0, itemType); itemCount = itemCount + 1; }
            if (itemType == Item.ItemType.BaseballBat) { items[itemCount] = new Weapon(0, 0, itemType); itemCount = itemCount + 1; }
            if (itemType == Item.ItemType.Knife) { items[itemCount] = new Weapon(0, 0, itemType); itemCount = itemCount + 1; }
            if (itemType == Item.ItemType.Axe) { items[itemCount] = new Weapon(0, 0, itemType); itemCount = itemCount + 1; }
            if (itemType == Item.ItemType.Chainsaw) { items[itemCount] = new Weapon(0, 0, itemType); itemCount = itemCount + 1; }
        }

        //cycles through items and updates each one
        public void UpdateItems(Map map, Player player, Inventory inventory, MvmtCamera camera)
        {
            for (int i = 0; i < itemCount; i++)
            {
                items[i].Update(map, player, inventory, camera, this);
            }
        }
        //cycles through items and draws each one
        public void DrawItems(MvmtCamera camera)
        {
            for (int i = 0; i < itemCount; i++)
            {
                items[i].Draw(camera);
            }
        }
        public void SetItemColour(char[,] renderer, int x, int y, int offsetX, int offsetY)
        {
            for (int i = 0; i < itemCount; i++)
            {
                items[i].itemTile.ShowTileColour(renderer, x, y, offsetX, offsetY);
            }
        }
        //used to define which item is being picked up
        public void CheckAndPickupItems(int x, int y)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (x == items[i].xLoc)
                {
                    if (y == items[i].yLoc)
                    {
                        items[i].pickedUp = true;
                        return;
                    }
                }
            }
        }
        public void CheckDropItem(char icon, Item.ItemType weapontype)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (items[i].xLoc == 0)
                {
                    if (items[i].yLoc == 0)
                    {
                        if ((items[i].itemTile.tileCharacter == icon) && (items[i].itemType == weapontype))
                        {
                            items[i].dropped = true;
                            return;
                        }
                    }
                }
            }
        }
        public void CheckandSwitchWeap(char icon, Item.ItemType weapontype, Inventory inventory)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (items[i].xLoc == 0)
                {
                    if (items[i].yLoc == 0)
                    {
                        if ((items[i].itemTile.tileCharacter == icon) && (items[i].itemType == weapontype))
                        {
                            inventory.addItemToInventory(items[i]);
                            return;
                        }
                    }
                }
            }
        }
        public void CheckToUseItem(char icon, Item.ItemType weapontype)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (items[i].xLoc == 0)
                {
                    if (items[i].yLoc == 0)
                    {
                        if ((items[i].itemTile.tileCharacter == icon) && (items[i].itemType == weapontype))
                        {
                            items[i].used = true;
                            return;
                        }
                    }
                }
            }
        }
        //bool to detect collision with each items
        public bool WhereIsItem(int x, int y)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (x == items[i].xLoc)
                {
                    if (y == items[i].yLoc)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
