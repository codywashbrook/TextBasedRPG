using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            // runs game

            GameManager gameManager = new GameManager();
            gameManager.RunGame();

            Console.ReadKey(true);
        }
    }
}
