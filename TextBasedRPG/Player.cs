using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextBasedRPG
{
    class Player : Character
    {


        public void SpawnCharater()
        {

            Console.WriteLine("P");
            ConsoleKeyInfo keyPressed = Console.ReadKey();

            // mvmt
            if (keyPressed.Key == ConsoleKey.W)
            {
                if (map[PlayerY - 1, PlayerX] == ".")
                {
                    PlayerY = PlayerY - 1;
                }
                else if (map[PlayerY - 1, PlayerX] == "#")
                {
                    PlayerY = PlayerY - 1;
                }
                else
                {


                }
            }
            if (keyPressed.Key == ConsoleKey.A)
            {
                if (map[PlayerY, PlayerX - 1] == ".")
                {
                    PlayerX = PlayerX - 1;
                }
                else if (map[PlayerY, PlayerX - 1] == "#")
                {
                    PlayerX = PlayerX - 1;
                }
                else
                {
                  
                }
            }
            if (keyPressed.Key == ConsoleKey.S)
            {
                if (map[PlayerY + 1, PlayerX] == ".")
                {
                    PlayerY = PlayerY + 1;
                }
                else if (map[PlayerY + 1, PlayerX] == "#")
                {
                    PlayerY = PlayerY + 1;
                }
                else
                {
                   
                }
            }
            if (keyPressed.Key == ConsoleKey.D)
            {
                if (map[PlayerY, PlayerX + 1] == ".")
                {
                    PlayerX = PlayerX + 1;
                }
                else if (map[PlayerY, PlayerX + 1] == "#")
                {
                    PlayerX = PlayerX + 1;
                }
                else
                {

                }
            }


            //if enter is pressed and the player is near enemy, enemy will take damage
            if (keyPressed.Key == ConsoleKey.Enter)
            {
                if (PlayerX == EnemyX - 1)
                {

                    EnemyDeathcount = EnemyDeathcount + 1;
                    if (EnemyDeathcount == 1)
                    {
                        Enemy.IsDead = true;
                    }

                }

            }

            Console.WriteLine("P");
            Console.CursorVisible = false;

        }
        //shows stats
        public void Stats()
        {
            Console.WriteLine("  Health: " + health + " X: " + PlayerX + "," + " Y: " + PlayerY);

        }
        //Controls
        public void Controls()
        {
            Console.WriteLine("WASD to move, Press Enter when near enemy to attack.");
        }
    }

}
