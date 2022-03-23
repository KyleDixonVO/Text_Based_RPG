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
        public void InitializeGame()
        {
            //On game launch
            hud = new HUD();
            map = new Map();
            map.GetMapData();
            enemyManager = new EnemyManager();
            enemyManager.CreateEnemies();
            itemManager = new ItemManager();
            itemManager.CreateItems();
            player = new Player();
            door = new Door();
            player.ShowInventory(map);
            Console.CursorVisible = false;
        }

        public void GameLoop(Player player, Map map, EnemyManager enemyManager, HUD hud, ItemManager itemManager, Door door)
        {
            //Game Loop
            while (player.dead == false)
            {
                map.Update(player, enemyManager, itemManager, door);
                player.ShowInventory(map);
                player.CalculateMovement(map, enemyManager, hud);
                enemyManager.MoveEnemies(map, player, enemyManager, hud);
                //medkit.HealOnContact(player);
                //powerUp.PowerUpOnContact(player);
                //money.PickUpOnContact(player);
                //key.PickUpOnContact(player, key);
                //door.OpenOnContact(player, key);
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

        public void LaunchGame()
        {
            InitializeGame();
            GameLoop(player, map, enemyManager, hud, itemManager, door);
            EndGame();
        }
    }
}


