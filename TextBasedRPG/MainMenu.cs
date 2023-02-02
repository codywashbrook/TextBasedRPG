using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class MainMenu : Program
    {
        public void DisplayMainMenu()
        {
            Console.Clear();
            string Title;
            Title = System.IO.File.ReadAllText("MainTitle.txt");
            Console.Write(Title);
            Console.WriteLine();
            Console.WriteLine("A - Start Game"); //start game
            Console.WriteLine("B - Quit Game");             //quit game
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.A)
            {
                GameEngine();
            }
            if (keyPressed.Key == ConsoleKey.B)
            {
                System.Environment.Exit(1);
            }
            Console.ReadKey(true);
        }
    }
}
