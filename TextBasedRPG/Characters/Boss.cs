﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    // Big Fella // lots of damage, lots of health // best to avoid
    class Boss : Enemy
    {
        public Boss(int X, int Y)
        {
            xLoc = X;
            yLoc = Y;
            SwitchVitalStatus(VitalStatus.Alive);
            characterTile.tileCharacter = Global.bossAppearance;
            characterTile.tileColour = Global.bossColour;
            //hard to kill
            health = Global.bossHealth;
            healthCap = Global.bossHealth;
            armor = Global.bossShield;
            armorCap = Global.bossShield;
            name = Global.bossName;
            //can kill you easily
            attackDamage = Global.bossAttackDamage;
        }
        //specific AI
        public override void Update(Map map, Player player, MvmtCamera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            if (vitalStatus == VitalStatus.Alive)
            {
                if (player.isPlayerAt(xLoc, yLoc - 1) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc - 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc + 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc, yLoc + 1) == true) { player.TakeDamage(attackDamage); Console.Beep(50, 500); }

                //else if (player.isPlayerNear(xLoc, yLoc - 5) == true) { SwitchDirection(Moving.Up, normal); }
                //else if (player.isPlayerNear(xLoc - 5, yLoc) == true) { SwitchDirection(Moving.Left, normal); }
                //else if (player.isPlayerNear(xLoc + 5, yLoc) == true) { SwitchDirection(Moving.Right, normal); }
                //else if (player.isPlayerNear(xLoc, yLoc + 5) == true) { SwitchDirection(Moving.Down, normal); }

                else
                {
                    int pos = rnd.Next(1, 6);
                    if (pos == 2) { Move(Moving.Left); }
                    if (pos == 3) { Move(Moving.Right); }
                    if (pos == 4) { Move(Moving.Down); }
                    if (pos == 5) { Move(Moving.Up); }
                }

                base.Update(map, player, camera, itemManager, enemyManager);
            }
        }
    }
}
