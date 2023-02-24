using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class GameOver
    {
        public bool gameOverDead;
        public bool gameOverWin;

        //self explan

        public void GameOverDeadScreen()
        {
            string deadScreen = System.IO.File.ReadAllText("GameOverDead.txt");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(deadScreen);
            Console.WriteLine();
            Console.WriteLine("PRESS ANY BUTTON TO EXIT....");
            Console.ReadKey(true);
        }
        public void GameOverWinScreen()
        {
            string winScreen = System.IO.File.ReadAllText("GameOverWin.txt");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(winScreen);
            Console.WriteLine();
            Console.WriteLine("PRESS ANY BUTTON TO EXIT....");
            Console.ReadKey(true);
        }
    }
}
