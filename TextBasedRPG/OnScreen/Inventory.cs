using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Inventory
    {
        public Item[] slots = new Item[inventorySize];

        //keeps track of inventory

        public int filledInventorySlots = 0;
        public bool inventoryIsOpen = false;
        public bool inventoryIsFull = false;
        private static int inventorySize = 10;

        public void Update(Player player, ItemManager itemManager)
        {
            if (inventoryIsOpen == true) { OpenInventory(player, itemManager); }
        }
        public void addItemToInventory(Item item)
        {
            if (filledInventorySlots < inventorySize)
            {
                inventoryIsFull = false;
                for (int i = 0; i < inventorySize; i++)
                {
                    if (slots[i] == null)
                    {
                        slots[i] = item;
                        filledInventorySlots = filledInventorySlots + 1;
                        return;
                    }
                }
            }
            else
            {
                inventoryIsFull = true;
                return;
            }
        }

        public void removeItemFromInventory(int itemSlot)
        {
            slots[itemSlot] = null;
            filledInventorySlots = filledInventorySlots - 1;
        }

        public void OpenInventory(Player player, ItemManager itemManager)
        {
            Console.Clear();
            for (int i = 0; i < inventorySize; i++)
            {
                if (slots[i] == null)
                {
                    Console.WriteLine("SLOT " + (i + 1) + ": ");
                }
                else
                {
                    Console.WriteLine("SLOT " + (i + 1) + ": " + slots[i].itemType);
                }

            }
            Console.WriteLine();
            Console.WriteLine("B + ENTER: RESUME GAME....");
            Console.WriteLine();
            Console.WriteLine("i + ENTER: UNEQUIP");
            Console.WriteLine();
            Console.WriteLine("# OF SLOT + ENTER: SELECT ITEM");

            string input = Console.ReadLine();
            if (input == "U")
            {
                //error check if no weapon
                if (player.weaponInHand.itemType == Item.ItemType.Fist) { Console.WriteLine("You Have Nothing to Drop!"); }
                else
                {
                    //if inventory slot is available, puts previous weapon in inventory
                    if (filledInventorySlots < inventorySize)
                    {
                        if (player.weaponInHand.itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckandSwitchWeap('W', Item.ItemType.BrassKnuckles, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.BaseballBat) { itemManager.CheckandSwitchWeap('W', Item.ItemType.BaseballBat, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.Knife) { itemManager.CheckandSwitchWeap('W', Item.ItemType.Knife, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.Axe) { itemManager.CheckandSwitchWeap('W', Item.ItemType.Axe, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.Chainsaw) { itemManager.CheckandSwitchWeap('W', Item.ItemType.Chainsaw, this); }
                    }
                    else
                    {
                        //if inventory is full you just drop you weapon that you are unarming
                        if (player.weaponInHand.itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckDropItem('W', Item.ItemType.BrassKnuckles); }
                        if (player.weaponInHand.itemType == Item.ItemType.BaseballBat) { itemManager.CheckDropItem('W', Item.ItemType.BaseballBat); }
                        if (player.weaponInHand.itemType == Item.ItemType.Knife) { itemManager.CheckDropItem('W', Item.ItemType.Knife); }
                        if (player.weaponInHand.itemType == Item.ItemType.Axe) { itemManager.CheckDropItem('W', Item.ItemType.Axe); }
                        if (player.weaponInHand.itemType == Item.ItemType.Chainsaw) { itemManager.CheckDropItem('W', Item.ItemType.Chainsaw); }
                    }
                }
                player.BecomeUnarmed();
            }
            for (int i = 0; i < inventorySize; i++)
            {
                if (input == (i + 1).ToString())
                {
                    Console.Clear();
                    Console.WriteLine("USE? OR DROP?");
                    Console.WriteLine();
                    Console.WriteLine("D + ENTER: DROP  " + "  E + ENTER / USE/EQUIP");
                    string action = Console.ReadLine();
                    //if you want to drop and item, it  contacts the item manager to see what it item you are trying to drop and drop it
                    if (action == "D")
                    {
                        if (slots[i] == null) { return; }
                        else if (slots[i].itemType == Item.ItemType.Armor) { itemManager.CheckDropItem('S', Item.ItemType.Armor); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.FirstAid) { itemManager.CheckDropItem('+', Item.ItemType.FirstAid); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckDropItem('W', Item.ItemType.BrassKnuckles); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.BaseballBat) { itemManager.CheckDropItem('W', Item.ItemType.BaseballBat); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Knife) { itemManager.CheckDropItem('W', Item.ItemType.Knife); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Axe) { itemManager.CheckDropItem('W', Item.ItemType.Axe); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Chainsaw) { itemManager.CheckDropItem('W', Item.ItemType.Chainsaw); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                    }
                    //if you want to use an item it contacts item manager to be use an item and uses it.....
                    if (action == "E")
                    {
                        if (slots[i] == null) { return; }
                        else if (slots[i].itemType == Item.ItemType.Armor) { itemManager.CheckToUseItem('S', Item.ItemType.Armor); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.FirstAid) { itemManager.CheckToUseItem('+', Item.ItemType.FirstAid); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckToUseItem('W', Item.ItemType.BrassKnuckles); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.BaseballBat) { itemManager.CheckToUseItem('W', Item.ItemType.BaseballBat); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Knife) { itemManager.CheckToUseItem('W', Item.ItemType.Knife); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Axe) { itemManager.CheckToUseItem('W', Item.ItemType.Axe); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Chainsaw) { itemManager.CheckToUseItem('W', Item.ItemType.Chainsaw); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                    }
                }
            }
            if (input == "B") { inventoryIsOpen = false; }
        }
        //check inventory to see if full
        public bool IsInventorySlotAvailable()
        {
            if (filledInventorySlots < inventorySize)
            {
                inventoryIsFull = false;
                return true;
            }
            else
            {
                inventoryIsFull = true;
                return false;
            }

        }
    }
}
