using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Program
    {
        public static int LeftRight = 1;
        public static int UpDown = 2;
        static void Main(string[] args)
        {

           MainMenu mainMenu;
           mainMenu = new MainMenu();
           mainMenu.DisplayMainMenu();

            Console.ReadKey(true);
        }
        public static void GameEngine()
        {
            //Instantiation and declaration

            GameOver gameOver = new GameOver();
            Player player1 = new Player();
            Enemy enemy1 = new Enemy();
            Map map = new Map();

            while (true)   //game Loop
            {
                Console.Clear();
                map.displayMap(); // map display
                player1.HealthMech(); //health stats
                player1.Stats(); //shows stats
                player1.Controls(); //controls for player
                enemy1.SpawnEnemy(UpDown); //enemy spawn
                Console.SetCursorPosition(player1.PlayerX, player1.PlayerY);//player control
                player1.SpawnCharater();  //player spawn
                if (player1.health == 0) //game lost
                {
                    gameOver.Gameover = true;
                    break;
                }
                //game win
                if (Enemy.IsDead == true)
                {
                    gameOver.Gameover = false;
                    break;
                }

            }
            //gameover
            gameOver.GameOverScreen();
            Console.ReadKey(true);
        }

    }
}
