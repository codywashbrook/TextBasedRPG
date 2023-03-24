using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Item
    {
        public enum ItemType
        {
            FirstAid,
            Armor,
            Money,
            Fist,
            BrassKnuckles,
            BaseballBat,
            Knife,
            Axe,
            Chainsaw
        }

        public ItemType itemType;
        public Tile itemTile = new Tile(' ', ConsoleColor.White);

        //picked up or not

        public bool pickedUp;
        public bool dropped;
        public bool used;
        public string infoMessage;
        protected string name;

        //local

        public int xLoc;
        public int yLoc;

        //shown as

        public virtual void Update(Map map, Player player, Inventory inventory, MvmtCamera camera, ItemManager itemManager)
        {
            Console.SetCursorPosition(1, 1);
            Console.WriteLine(infoMessage);
        }
        //draw method
        public void Draw(MvmtCamera camera)
        {
            camera.DrawToRenderer(itemTile.tileCharacter, xLoc, yLoc);

        }

    }
}
