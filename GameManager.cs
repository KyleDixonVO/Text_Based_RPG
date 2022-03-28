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
            map.GetMapData();
            enemyManager = new EnemyManager();
            enemyManager.CreateEnemies();
            itemManager = new ItemManager();
            itemManager.CreateItems();
            player = new Player();
            door = new Door();
            inventory = new Inventory();
            inventory.ShowInventory(camera);
            map.Update(player, enemyManager, itemManager, door, camera, inventory.inventoryCoordX, inventory.inventoryCoordY);
            Console.CursorVisible = false;
        }

        public void GameLoop(Player player, Map map, EnemyManager enemyManager, HUD hud, ItemManager itemManager, Door door, Camera camera, Inventory inventory)
        {
            //Game Loop
            while (player.dead == false)
            {

                map.Update(player, enemyManager, itemManager, door, camera, inventory.inventoryCoordX, inventory.inventoryCoordY);
                hud.ShowPlayerStats(ref player, map, camera);
                camera.Update(player);
                inventory.ShowInventory(camera);
                if (inventory.money == 25)
                {
                    Console.ReadKey(true);
                    WinGame();
                }
                player.CalculateMovement(map, enemyManager, hud, door, camera);
                door.Update(player, enemyManager, (Key)itemManager.items[0], inventory);
                enemyManager.Update(map, player, enemyManager, hud, door, camera);
                itemManager.Update(player, (Key)itemManager.items[0], inventory);

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
            GameLoop(player, map, enemyManager, hud, itemManager, door, camera, inventory);
            EndGame();
        }
    }
}


