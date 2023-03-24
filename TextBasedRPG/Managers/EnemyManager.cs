using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class EnemyManager
    {
        //count of enemy
        public static int enemyCap = 100;
        public Enemy[] enemies = new Enemy[enemyCap];
        public int enemyCount = 0;

        public void InitEnemyWorldLoc(char[,] world, int X, int Y)
        {
            if (enemyCount > enemyCap - 1) { return; }
            else if (world[X, Y] == Global.heavyAppearance) { enemies[enemyCount] = new Heavy(X, Y); enemyCount = enemyCount + 1; }
            else if (world[X, Y] == Global.lightAppearance) { enemies[enemyCount] = new Light(X, Y); enemyCount = enemyCount + 1; }
            else if (world[X, Y] == Global.bossAppearance) { enemies[enemyCount] = new Boss(X, Y); enemyCount = enemyCount + 1; }
        }
        //updates each enemy
        public void UpdateEnemies(Map map, Player player, MvmtCamera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                enemies[i].Update(map, player, camera, itemManager, enemyManager);
            }
        }
        public void SetEnemyColour(char[,] renderer, int x, int y, int offsetX, int offsetY)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                enemies[i].characterTile.ShowTileColour(renderer, x, y, offsetX, offsetY);
            }
        }
        //draws enemies
        public void DrawEnemies(MvmtCamera camera)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                enemies[i].Draw(camera);
            }
        }

        //checks the enemy so the player can see which one it's attacking
        public void CheckEnemy(int x, int y, int playerAttackDamage)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                if (x == enemies[i].xLoc)
                {
                    if (y == enemies[i].yLoc)
                    {
                        enemies[i].TakeDamage(playerAttackDamage);
                    }
                }
            }
        }

        //collision detect
        public bool IsEnemyAt(int x, int y)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                if (x == enemies[i].xLoc)
                {
                    if (y == enemies[i].yLoc)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void AddHeavEnemy(int x, int y)
        {
            if (enemyCount > enemyCap - 1) { return; }
            enemies[enemyCount] = new Heavy(x, y);
            enemyCount += 1;
        }
    }
}
