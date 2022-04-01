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
        public void InitializeGame()
        {
            //On game launch
            hud = new HUD();
            camera = new Camera();
            map = new Map();
            renderer = new Renderer();
            map.GetMapData();
            enemyManager = new EnemyManager();
            enemyManager.CreateEnemies();
            itemManager = new ItemManager();
            itemManager.CreateItems();
            player = new Player();
            door = new Door();
            inventory = new Inventory();
            inventory.ShowInventory(camera);
            //renderer.Update(player, enemyManager, itemManager, door, camera, inventory.inventoryCoordX, inventory.inventoryCoordY, map);
            Console.CursorVisible = false;
        }

        public void GameLoop(Player player, Renderer renderer, Map map, EnemyManager enemyManager, HUD hud, ItemManager itemManager, Door door, Camera camera, Inventory inventory)
        {
            //Game Loop
            while (player.dead == false)
            {
                player.CalculateMovement(renderer, map, enemyManager, hud, door, camera);
                camera.Update(player);
                map.Draw(renderer, camera);
                door.Update(player, enemyManager, (Key)itemManager.items[0], inventory);
                enemyManager.Update(renderer, map, player, enemyManager, hud, door, camera);
                enemyManager.Draw(renderer, camera);
                itemManager.Update(player, (Key)itemManager.items[0], inventory);
                itemManager.Draw(renderer, camera);
                door.Draw(renderer, camera);
                player.Draw(renderer, camera);
                hud.ShowPlayerStats(ref player);
                inventory.ShowInventory(camera);
            }
        }

        public void EndGame()
        {
            //Game end
            Console.Clear();
            Console.SetCursorPosition(5, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You Died! Game Over");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        public void WinGame()
        {
            //Game Win
            Console.Clear();
            Console.SetCursorPosition(5, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulations! You won the game!");
            Console.ResetColor();
            Console.ReadKey(true);
            System.Environment.Exit(0);
        }

        public void LaunchGame()
        {
            InitializeGame();
            GameLoop(player, renderer, map, enemyManager, hud, itemManager, door, camera, inventory);
            EndGame();
        }
    }
}


