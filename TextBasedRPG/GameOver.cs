using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class GameOver : Character
    {
        public void GameOverScreen()
        {
            //display if you win
            if (Gameover == false)
            {
                Console.Clear();
                string GameWin;
                GameWin = System.IO.File.ReadAllText("GameWinScreen.txt");
                Console.Write(GameWin);
                Console.WriteLine();

                Console.WriteLine("B - Quit Game");
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.B)
                {
                    System.Environment.Exit(1);
                }
                Console.ReadKey(true);
            }
            //display if you lose
            if (Gameover == true)
            {
                Console.Clear();
                string GameOver;
                GameOver = System.IO.File.ReadAllText("GameOverScreen.txt");
                Console.Write(GameOver);
                Console.WriteLine();

                Console.WriteLine("B - Quit Game");
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.B)
                {
                    System.Environment.Exit(1);
                }
                Console.ReadKey(true);
            }
        }
    }
}
