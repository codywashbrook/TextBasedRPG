﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextBasedRPG
{
    class Light : Enemy
    {
        public Light(int X, int Y)
        {
            xLoc = X;
            yLoc = Y;

            //light enemy stats

            SwitchVitalStatus(VitalStatus.Alive);
            characterTile.tileCharacter = Global.lightAppearance;
            characterTile.tileColour = Global.lightColour;
            health = Global.lightHealth;
            healthCap = Global.lightHealth;
            armor = Global.lightShield;
            armorCap = Global.lightShield;
            name = Global.lightName;
            attackDamage = Global.lightAttackDamage;
        }

        public override void Update(Map map, Player player, MvmtCamera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            //specific to light

            if (vitalStatus == VitalStatus.Alive)
            {
                if (player.isPlayerAt(xLoc, yLoc - 1) == true) { player.TakeDamage(attackDamage); Console.Beep(700, 100); }
                else if (player.isPlayerAt(xLoc - 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(700, 100); }
                else if (player.isPlayerAt(xLoc + 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(700, 100); }
                else if (player.isPlayerAt(xLoc, yLoc + 1) == true) { player.TakeDamage(attackDamage); Console.Beep(700, 100); }
                else
                {
                    int pos = rnd.Next(1, 8);
                    if (pos == 2) { Move(Moving.Left); }
                    if ((pos >= 3) && (pos <= 4)) { Move(Moving.Right); }
                    if ((pos >= 5) && (pos <= 6)) { Move(Moving.Up); }
                    if (pos == 7) { Move(Moving.Down); }
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
