using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class MainMenu
    {
        //game start//self explan
        public void StartMainMenu()
        {
            string titleScreen = System.IO.File.ReadAllText("MainMenu.txt");
            Console.WriteLine(titleScreen);
            Console.WriteLine();
            Console.WriteLine("Press any button - New Game");
            Console.WriteLine("Z - Quit");
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            if (keyPressed.Key == ConsoleKey.Z)
            {
                System.Environment.Exit(1);
            }
            Console.ReadKey(true);
            Console.Beep(2200, 100);
            return;
        }
        //Exposition
        public void ShowExpoScreen()
        {
            Console.SetCursorPosition(0, 0);
            string beginningInfo = System.IO.File.ReadAllText("ExpoScreen.txt");
            Console.WriteLine(beginningInfo);
            Console.WriteLine();
            Console.WriteLine("START?");
            Console.ReadKey(true);
            Console.Beep(2200, 100);
            return;
        }
    }
}
