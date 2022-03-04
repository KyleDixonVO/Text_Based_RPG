using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class GameManager
    {
        public Player player;
        public Map map;
        //public EnemyManager enemyManager;
        public Tracker tracker;
        public Spaz spaz;
        public Sentinel sentinel;
        public Medkit medkit;
        public PowerUp powerUp;
        public Money money;
        public Key key;
        public Door door;
        public void InitializeGame()
        {
            //On game launch
            map = new Map();
            map.GetMapData();
            //enemyManager = new EnemyManager();
            //enemyManager.CreateEnemies();
            player = new Player();
            tracker = new Tracker();
            //tracker.Initialize(3, 10, 5, tracker.avatar);
            spaz = new Spaz();
            sentinel = new Sentinel();
            medkit = new Medkit();
            powerUp = new PowerUp();
            money = new Money();
            key = new Key();
            door = new Door();
            
            player.ShowStats();
            player.ShowInventory(map);
            Console.CursorVisible = false;
        }

        public void GameLoop(Player player, ref Tracker tracker, ref Spaz spaz, ref Sentinel sentinel, Map map, Medkit medkit, PowerUp powerUp, Money money, Key key, Door door)
        {
            //Game Loop
            while (player.dead == false)
            {
                player.ShowStats();
                player.ShowInventory(map);
                map.Update(player, ref tracker, ref spaz, ref sentinel, medkit, powerUp, money, key, door);
                player.CalculateMovement(map, ref tracker,  ref spaz, ref sentinel);
                medkit.HealOnContact(player);
                powerUp.PowerUpOnContact(player);
                money.PickUpOnContact(player);
                key.PickUpOnContact(player, key);
                door.OpenOnContact(player, key);

                player.ShowStats();
                player.ShowInventory(map);

                map.Update(player, ref tracker, ref spaz, ref sentinel, medkit, powerUp, money, key, door);
                if (tracker != null)
                {
                    tracker.CalculateMovement(map, player, spaz, sentinel);
                }

                if (spaz != null)
                {
                    spaz.CalculateMovement(map, player, tracker, sentinel);
                }
                
                if (sentinel != null)
                {
                    sentinel.CalculateMovement(map, player, tracker, sentinel);
                }
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
            GameLoop(player, ref tracker, ref spaz, ref sentinel, map, medkit, powerUp, money, key, door);
            EndGame();
        }
    }
}


