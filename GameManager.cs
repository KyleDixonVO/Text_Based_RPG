using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class GameManager
    {
        public bool gameOver = false;
        public Player player;
        public Renderer renderer;
        public Map map;
        public EnemyManager enemyManager;
        public ItemManager itemManager;
        public Door door;
        public HUD hud;
        public Camera camera;
        public Inventory inventory;
        public Settings settings;
        public void InitializeGame()
        {
            //On game launch
            settings = new Settings();
            hud = new HUD();
            camera = new Camera();
            map = new Map();
            renderer = new Renderer();
            map.GetMapData(settings);
            enemyManager = new EnemyManager();
            enemyManager.CreateEnemies(map, renderer);
            itemManager = new ItemManager();
            itemManager.CreateItems(renderer, map);
            player = new Player();
            door = new Door();
            inventory = new Inventory();
            inventory.ShowInventory(camera);
            Console.CursorVisible = false;
        }

        public void GameLoop(Player player, Renderer renderer, Map map, EnemyManager enemyManager, HUD hud, ItemManager itemManager, Door door, Camera camera, Inventory inventory)
        {
            //Game Loop
            while (!InLoseState())
            {
                player.CalculateMovement(renderer, map, enemyManager, hud, door, camera);
                camera.Update(player, map);
                map.Draw(renderer, camera);
                door.Update(player, enemyManager, (Key)itemManager.items[0], inventory);
                enemyManager.Update(renderer, map, player, enemyManager, hud, door, camera);
                enemyManager.Draw(renderer, camera);
                itemManager.Update(player, (Key)itemManager.items[0], inventory);
                itemManager.Draw(renderer, camera);
                door.Draw(renderer, camera);
                player.Draw(renderer, camera);
                hud.Update(player);
                inventory.Update(camera);
                OnWinGame();
            }
            GameOver();
        }

        public void GameOver()
        {
            if (player.dead != true) return;
            Console.Clear();
            Console.SetCursorPosition(5, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You Died! Game Over");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        public void OnWinGame()
        {
            if (inventory.money < 20) return;
            //Game Win
            Console.ReadKey(true);
            Console.Clear();
            Console.SetCursorPosition(5, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulations! You won the game!");
            Console.ResetColor();
            Console.ReadKey(true);
            System.Environment.Exit(0);
        }

        public bool InLoseState()
        {
            if (player.dead == true)
            {
                return true;
            }
            return false;
        }

        public void LaunchGame()
        {
            InitializeGame();
            GameLoop(player, renderer, map, enemyManager, hud, itemManager, door, camera, inventory);
            GameOver();
        }
    }
}


