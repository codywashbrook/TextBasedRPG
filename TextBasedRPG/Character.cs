using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    abstract class Character : Map
    {
        //enemy and player have different X and Y to make them similar
        public int PlayerX = 56;
        public int PlayerY = 12;
        public int EnemyX = 97;
        public int EnemyY = 16;
        //player health
        public int health = 50;
        public static int EnemyDeathcount;
        public bool Gameover;

        public void HealthMech()
        {
            //enemy gives 10 damage to player
            if (PlayerX == EnemyX)
            {
                if (PlayerY == EnemyY)
                {
                    health = health - 10;
                    if (health <= 0)
                    {
                        health = 0;
                    }
                }

            }
            //player dies, game ends
            if (health <= 0)
            {
                Gameover = true;
            }


        }
    }
}
