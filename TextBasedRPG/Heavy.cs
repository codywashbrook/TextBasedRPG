using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextBasedRPG
{
    class Heavy : Enemy
    {
        //spawns 

        public Heavy(int X, int Y)
        {
            xLoc = X;
            yLoc = Y;

            //heavy stats

            SwitchVitalStatus(VitalStatus.Alive);
            characterTile.tileCharacter = 'E';
            characterTile.tileColour = ConsoleColor.Red;
            health = 100;
            shield = 0;
            name = "Heavy";
            attackDamage = 5;
        }
        //update method with specific behavior, else taken from main enemy class
        public override void Update(Map map, Player player, MvmtCamera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            //alives = mvmt and attack

            if (vitalStatus == VitalStatus.Alive)
            {
                //when attacking player

                if (player.isPlayerAt(xLoc, yLoc - 1) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else if (player.isPlayerAt(xLoc - 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else if (player.isPlayerAt(xLoc + 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else if (player.isPlayerAt(xLoc, yLoc + 1) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else
                {
                    int pos = rnd.Next(1, 4);
                    if (pos == 2) { Move(Moving.Left); }
                    if (pos == 3) { Move(Moving.Right); }
                }
                base.Update(map, player, camera, itemManager, enemyManager);
            }
            //dead

            else
            {
                SwitchVitalStatus(VitalStatus.Dead);
            }
        }
    }
}
