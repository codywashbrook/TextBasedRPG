using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    class GameManager
    {
        public void RunGame()
        {
            //self explan
            MainMenu mainMenu = new MainMenu();
            mainMenu.StartMainMenu();
            Console.Clear();
            mainMenu.ShowInfoScreen();
            Console.Clear();

            //intant and declar

            Map map = new Map();
            World world = new World();
            GameOver gameOver = new GameOver();
            Player player = new Player();
            EnemyManager enemyManager = new EnemyManager();
            ItemManager itemManager = new ItemManager();
            HUD Hud = new HUD();
            MvmtCamera camera = new MvmtCamera();
            Inventory inventory = new Inventory();
            world.InitEntities(enemyManager, itemManager, player);

            //the game loop
            while (true)
            {
                //updates that occur
                itemManager.UpdateItems(map, player, inventory, camera);
                enemyManager.UpdateEnemies(map, player, camera, itemManager, enemyManager);
                player.Update(map, enemyManager, itemManager, gameOver, inventory);
                camera.Update(map, player);
                inventory.Update(player, itemManager);

                //draw + polish

                itemManager.DrawItems(camera);
                enemyManager.DrawEnemies(camera);
                player.Draw(camera);
                Hud.DisplayHUD(player, enemyManager, camera, inventory);
                camera.Draw(player, enemyManager, map, itemManager);

                //if game ends in any way, break out of the game loop

                if (gameOver.gameOverWin == true) { break; }
                if (gameOver.gameOverLoss == true) { break; }
            }
            if (gameOver.gameOverWin == true) { Console.Clear(); gameOver.GameOverWinScreen(); }
            if (gameOver.gameOverLoss == true) { Console.Clear(); gameOver.GameOverLossScreen(); }
        }
    }
}
