using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Global
    {
        //general
        static string[] data;
        static string[] dataLineSections;
        static string[] ColourNames = new string[16];

        //player var's first
        public static int playerHealth;
        public static int playerShield;
        public static char playerAppearance;
        public static string playerName;
        public static int playerInventorySlotAmount;
        public static string[] playerInventoryData;
        public static string playerStartingWeapon;
        public static int playerStartMoney;
        public static ConsoleColor playerColour;

        //map
        public static int mapWidth;
        public static int mapHeight;
        public static char[] mapTileIDs = new char[13];
        public static ConsoleColor[] mapTileColours = new ConsoleColor[13];

        //light enemy
        public static int lightHealth;
        public static int lightShield;
        public static char lightAppearance;
        public static string lightName;
        public static int lightAttackDamage;
        public static ConsoleColor lightColour;

        //heavy
        public static int heavyHealth;
        public static int heavyShield;
        public static char heavyAppearance;
        public static string heavyName;
        public static int heavyAttackDamage;
        public static ConsoleColor heavyColour;

        //boss
        public static int bossHealth;
        public static int bossShield;
        public static char bossAppearance;
        public static string bossName;
        public static int bossAttackDamage;
        public static ConsoleColor bossColour;

        //items
        public static char firstAidAppearance;
        public static int firstAidHP;
        public static ConsoleColor firstAidColour;
        public static char armorAppearance;
        public static int ShieldSP;
        public static ConsoleColor armorColour;
        public static char moneyAppearance;
        public static ConsoleColor moneyColour;
        public static char weaponAppearance;
        public static int fistDamage;
        public static int BKDamage;
        public static int BBBDamage;
        public static int knifeDamage;
        public static int axeDamage;
        public static int chainsawDamage;
        public static ConsoleColor weaponColour;

        //pub
        public Global()
        {
            SetAvailableColours();
            SetMapStats();
            SetPlayerStats();
            SetLightStats();
            SetHeavyStats();
            SetBossStats();
            SetItemStats();
        }

        private void SetAvailableColours()
        {
            ColourNames[0] = "Black";
            ColourNames[1] = "DarkBlue";
            ColourNames[2] = "DarkGreen";
            ColourNames[3] = "DarkCyan";
            ColourNames[4] = "DarkRed";
            ColourNames[5] = "DarkMagenta";
            ColourNames[6] = "DarkYellow";
            ColourNames[7] = "Gray";
            ColourNames[8] = "DarkGray";
            ColourNames[9] = "Blue";
            ColourNames[10] = "Green";
            ColourNames[11] = "Cyan";
            ColourNames[12] = "Red";
            ColourNames[13] = "Magenta";
            ColourNames[14] = "Yellow";
            ColourNames[15] = "White";
        }

        //items r/w
        private void SetItemStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/ItemStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "FirstAidAppearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { firstAidAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "FirstAidHP".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { firstAidHP = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "FirstAidColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { firstAidColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "ShieldAppearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { armorAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "ShieldSP".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { ShieldSP = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "ShieldColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { armorColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "MoneyAppearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { moneyAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "MoneyColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { moneyColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "WeaponAppearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { weaponAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "WeaponColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { weaponColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "FistDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { fistDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "BrassKnucklesDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { BKDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "BaseBallBatDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { BBBDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "KnifeDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { knifeDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "AxeDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { axeDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "ChainsawDamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { chainsawDamage = int.Parse(dataLineSections[l + 1]); } }
                    }
                }
            }
        }

        //boss r/w
        private void SetBossStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "bossappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { bossAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "bossshield".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { bossShield = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "bosshealth".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { bossHealth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "bossname".ToLower()) { bossName = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "bossattackdamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { bossAttackDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "BossColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { bossColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                    }
                }
            }
        }

        //heavy r/w
        private void SetHeavyStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "heavyappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { heavyAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "heavyshield".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { heavyShield = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "heavyhealth".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { heavyHealth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "heavyname".ToLower()) { heavyName = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "heavyattackdamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { heavyAttackDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "HeavyColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { heavyColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                    }
                }
            }
        }

        //light r/w
        private void SetLightStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/EnemyStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "lightappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { lightAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "lightshield".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { lightShield = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "lighthealth".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { lightHealth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "lightname".ToLower()) { lightName = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "lightattackdamage".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { lightAttackDamage = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "LightColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { lightColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                    }
                }
            }
        }

        //map r/w
        private void SetMapStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/MapStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split(';');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "width".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { mapWidth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "height".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { mapHeight = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "WaterID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[0] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "WaterColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[0] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "GrassID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[1] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "GrassColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[1] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "HillID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[2] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "HillColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[2] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "mountainID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[3] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "mountainColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[3] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "VertWallID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[4] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "VertWallColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[4] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "HorizWallID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[5] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "HorizWallColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[5] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "RightCornerWallID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[6] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "RightCornerWallColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[6] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "LeftCornerWallID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[7] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "LeftCornerWallColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[7] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "floorID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[8] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "floorColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[8] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "PathID".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { mapTileIDs[9] = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "PathColour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { mapTileColours[9] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                    }
                }
            }
        }

        //player r/w
        private void SetPlayerStats()
        {
            data = System.IO.File.ReadAllLines("DataStats/PlayerStats.txt");
            for (int i = 0; i <= data.Length - 1; i = i + 1)
            {
                dataLineSections = data[i].Split('=');
                for (int l = 0; l <= dataLineSections.Length - 1; l = l + 1)
                {
                    for (int c = 0; c <= ColourNames.Length - 1; c++)
                    {
                        if (dataLineSections[l].ToLower() == "pmoney".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { playerStartMoney = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "pappearance".ToLower()) { if (isOneCharacter(dataLineSections[l + 1])) { playerAppearance = char.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "pshield".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { playerShield = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "phealth".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { playerHealth = int.Parse(dataLineSections[l + 1]); } }
                        if (dataLineSections[l].ToLower() == "pname".ToLower()) { playerName = dataLineSections[l + 1]; }
                        if (dataLineSections[l].ToLower() == "Colour".ToLower()) { if (dataLineSections[l + 1] == ColourNames[c]) { playerColour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), dataLineSections[l + 1], true); } }
                        if (dataLineSections[l].ToLower() == "invenslotamount".ToLower()) { if (isNumeric(dataLineSections[l + 1])) { playerInventorySlotAmount = int.Parse(dataLineSections[l + 1]); playerInventoryData = new string[playerInventorySlotAmount]; } }
                        if (dataLineSections[l].ToLower() == "startweapon".ToLower())
                        {
                            if (dataLineSections[l + 1] == Item.ItemType.Fist.ToString()) { playerStartingWeapon = Item.ItemType.Fist.ToString(); }
                            if (dataLineSections[l + 1] == Item.ItemType.BrassKnuckles.ToString()) { playerStartingWeapon = Item.ItemType.BrassKnuckles.ToString(); }
                            if (dataLineSections[l + 1] == Item.ItemType.BaseballBat.ToString()) { playerStartingWeapon = Item.ItemType.BaseballBat.ToString(); }
                            if (dataLineSections[l + 1] == Item.ItemType.Knife.ToString()) { playerStartingWeapon = Item.ItemType.Knife.ToString(); }
                            if (dataLineSections[l + 1] == Item.ItemType.Axe.ToString()) { playerStartingWeapon = Item.ItemType.Axe.ToString(); }
                            if (dataLineSections[l + 1] == Item.ItemType.Chainsaw.ToString()) { playerStartingWeapon = Item.ItemType.Chainsaw.ToString(); }
                        }
                        for (int s = 0; s <= playerInventorySlotAmount; s = s + 1)
                        {
                            if (dataLineSections[l].ToLower() == "slot" + s)
                            {
                                if (dataLineSections[l + 1] == Item.ItemType.FirstAid.ToString()) { playerInventoryData[s - 1] = Item.ItemType.FirstAid.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.Armor.ToString()) { playerInventoryData[s - 1] = Item.ItemType.Armor.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.BrassKnuckles.ToString()) { playerInventoryData[s - 1] = Item.ItemType.BrassKnuckles.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.BaseballBat.ToString()) { playerInventoryData[s - 1] = Item.ItemType.BaseballBat.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.Knife.ToString()) { playerInventoryData[s - 1] = Item.ItemType.Knife.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.Axe.ToString()) { playerInventoryData[s - 1] = Item.ItemType.Axe.ToString(); }
                                if (dataLineSections[l + 1] == Item.ItemType.Chainsaw.ToString()) { playerInventoryData[s - 1] = Item.ItemType.Chainsaw.ToString(); }
                            }
                        }
                    }
                }
            }


        }
        //numeral check
        public static bool isNumeric(String stringToCheck)
        {
            int intValue;

            if (stringToCheck == null || stringToCheck.Equals(""))
            {
                return false;
            }

            try
            {
                intValue = int.Parse(stringToCheck);
                return true;
            }
            catch (FormatException)
            {

            }
            return false;
        }

        //1 character check
        public static bool isOneCharacter(string stringToCheck)
        {
            if (stringToCheck.Length <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
