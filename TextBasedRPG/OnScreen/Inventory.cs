using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Inventory
    {
        public Item[] slots = new Item[Global.playerInventorySlotAmount];

        //keeps track of inventory

        public int filledInventorySlots = 0;
        public bool inventoryIsOpen = false;
        public bool inventoryIsFull = false;
        public bool settingUpInventory;

        public Inventory(ItemManager itemManager)
        {
            settingUpInventory = true;
            for (int i = 0; i <= Global.playerInventorySlotAmount - 1; i++)
            {
                if (Global.playerInventoryData[i] == Item.ItemType.FirstAid.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.FirstAid);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.Armor.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.Armor);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.BrassKnuckles.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.BrassKnuckles);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.BaseballBat.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.BaseballBat);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.Knife.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.Knife);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.Axe.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.Axe);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.Chainsaw.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.Chainsaw);
                }
            }
            settingUpInventory = false;
        }

                public void Update(Player player, ItemManager itemManager)
        {
            if (filledInventorySlots >= 9)
                if(filledInventorySlots + 1 <= (Global.playerInventorySlotAmount) -1)
                    Global.playerInventorySlotAmount = filledInventorySlots + 1;
            else
                    Global.playerInventorySlotAmount = 10;
            if (inventoryIsOpen == true) { OpenInventory(player, itemManager); }
        }
        public void setInventorySlot(int slotNumber, ItemManager itemManager, Item.ItemType itemName)
        {
            itemManager.CreateItemInInventory(itemName);
            slots[slotNumber] = new Item();
            slots[slotNumber].itemType = itemName;
            filledInventorySlots = filledInventorySlots + 1;
           
        }
        public int InventorySize()
        {
            return Global.playerInventorySlotAmount;
        }
        public Item InventorySlots(int index)
        {
            return slots[index];
        }
        public void addItemToInventory(Item item)
        {
            if (filledInventorySlots < Global.playerInventorySlotAmount)
            {
                inventoryIsFull = false;
                for (int i = 0; i < Global.playerInventorySlotAmount; i++)
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
            for (int i = 0; i < Global.playerInventorySlotAmount; i++)
            {
                if (slots[i] == null)
                {
                    Console.WriteLine("Inventory slot " + (i + 1) + ": ");
                }
                else
                {
                    Console.WriteLine("Inventory slot " + (i + 1) + ": " + slots[i].itemType);
                }
                
            }
            Console.WriteLine();
            Console.WriteLine("b + enter: return to the game....");
            Console.WriteLine();
            Console.WriteLine("u + enter: unequip weapon");
            Console.WriteLine();
            Console.WriteLine("Number of slot + enter: select item");
    
            string input = Console.ReadLine();
            if (input == "u")
            {
                //can't unarm
                if (player.weaponInHand.itemType == Item.ItemType.Fist){Console.WriteLine("You are already unarmed!");}
                else 
                {
                    //if inventory slot is available, puts prev weap in inventory
                    if (filledInventorySlots < Global.playerInventorySlotAmount) 
                    {
                        if (player.weaponInHand.itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckandSwitchWeap('W', Item.ItemType.BrassKnuckles, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.BaseballBat) { itemManager.CheckandSwitchWeap('W', Item.ItemType.BaseballBat, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.Knife) { itemManager.CheckandSwitchWeap('W', Item.ItemType.Knife, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.Axe) { itemManager.CheckandSwitchWeap('W', Item.ItemType.Axe, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.Chainsaw) { itemManager.CheckandSwitchWeap('W', Item.ItemType.Chainsaw, this); }
                    }
                    else
                    {
                        //if inventory is full you drop weapon that you are unarming
                        if (player.weaponInHand.itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckDropItem('W', Item.ItemType.BrassKnuckles); }
                        if (player.weaponInHand.itemType == Item.ItemType.BaseballBat) { itemManager.CheckDropItem('W', Item.ItemType.BaseballBat); }
                        if (player.weaponInHand.itemType == Item.ItemType.Knife) { itemManager.CheckDropItem('W', Item.ItemType.Knife); }
                        if (player.weaponInHand.itemType == Item.ItemType.Axe) { itemManager.CheckDropItem('W', Item.ItemType.Axe); }
                        if (player.weaponInHand.itemType == Item.ItemType.Chainsaw) { itemManager.CheckDropItem('W', Item.ItemType.Chainsaw); }
                    }
                }
                player.weaponInHand.SwitchWeap(Item.ItemType.Fist, player);
            }
            for (int i = 0; i < Global.playerInventorySlotAmount; i++)
            {
                if (input == (i + 1).ToString())
                {
                    Console.Clear();
                    Console.WriteLine("What would you like to with this item?");
                    Console.WriteLine();
                    Console.WriteLine("d + enter: drop item  " + "  e + enter to use / equip item");
                    string action = Console.ReadLine();
                    //if you want to drop item, it  contacts the item manager to see what it item you are trying to drop and drop it
                    if (action == "d")
                    {
                        if (slots[i] == null) { return; }
                        else if (slots[i].itemType == Item.ItemType.Armor) { itemManager.CheckDropItem('S', Item.ItemType.Armor);removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.FirstAid) { itemManager.CheckDropItem('+', Item.ItemType.FirstAid); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckDropItem('W', Item.ItemType.BrassKnuckles); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.BaseballBat) { itemManager.CheckDropItem('W', Item.ItemType.BaseballBat); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Knife) { itemManager.CheckDropItem('W', Item.ItemType.Knife); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Axe) { itemManager.CheckDropItem('W', Item.ItemType.Axe); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Chainsaw) { itemManager.CheckDropItem('W', Item.ItemType.Chainsaw); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                    }
                    //if you want to use an item it contacts item manager to be use an item and uses it.....
                    if (action == "e")
                    {
                        if (slots[i] == null) { return; }
                        else if (slots[i].itemType == Item.ItemType.Armor) { itemManager.CheckToUseItem('S', Item.ItemType.Armor); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.FirstAid) { itemManager.CheckToUseItem('+', Item.ItemType.FirstAid); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear();}
                        else if (slots[i].itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckToUseItem('W', Item.ItemType.BrassKnuckles); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.BaseballBat) { itemManager.CheckToUseItem('W', Item.ItemType.BaseballBat); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Knife) { itemManager.CheckToUseItem('W', Item.ItemType.Knife); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Axe) { itemManager.CheckToUseItem('W', Item.ItemType.Axe); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Chainsaw) { itemManager.CheckToUseItem('W', Item.ItemType.Chainsaw); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                    }
                    //else { return; }
                }
                //else { return; }
            }
            if (input == "b"){inventoryIsOpen = false;}
        }
        //see if inventory full before they pick up item
        public bool IsInventorySlotAvailable()
        {
            if (filledInventorySlots < Global.playerInventorySlotAmount)
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
