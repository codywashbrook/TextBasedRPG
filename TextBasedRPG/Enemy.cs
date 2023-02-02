using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class Enemy : Character
    {
        public int bounceCount = 1;
        public static bool IsDead;        //enemy death

        public void SpawnEnemy(int direction)// 1 = left and right
        {

            Console.CursorVisible = false;

            if (IsDead == false)
            {
                Console.SetCursorPosition(EnemyX, EnemyY);

                Console.WriteLine("E");
                //enemy AI
                if (direction == 1)
                {

                    if (map[EnemyY, EnemyX] == "|")
                    {
                        //if enemy hits this part of the area the count will be 1
                        bounceCount = bounceCount + 1;

                    }
                    if (map[EnemyY, EnemyX] == "#")
                    {
                        //or if it hits this
                        bounceCount = bounceCount + 1;

                    }
                    if (bounceCount == 1)
                    {
                        //if the count is 1 the enemy will change position
                        EnemyX = EnemyX + 1;
                    }
                    else if (bounceCount <= 2)
                    {
                        //if count is twice, the count goes to 0 and start heading first direction
                        //infinite loop
                        bounceCount = 0;
                        EnemyX = EnemyX - 1;
                    }
                }
                if (direction == 2)                                                              // 2 = up and down
                {
                    //same AI but if direction changes, enemy will move on ceiling and floor instead of wall
                    //different directions for enemy
                    if (map[EnemyY, EnemyX] == "—")
                    {
                        bounceCount = bounceCount + 1;

                    }
                    if (map[EnemyY, EnemyX] == "#")
                    {

                        bounceCount = bounceCount + 1;

                    }
                    if (bounceCount == 1)
                    {
                        EnemyY = EnemyY + 1;
                    }
                    else if (bounceCount <= 2)
                    {
                        bounceCount = 0;
                        EnemyY = EnemyY - 1;
                    }
                }
            }
            //if enemy dies
            if (IsDead == true)
            {
                Console.SetCursorPosition(EnemyX, EnemyY);
                Console.WriteLine("X");
                IsDead = false;
            }

        }

    }
}
