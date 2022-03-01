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
        public Tracker tracker;
        public void InitializeGame()
        {
            //On game launch
            map = new Map();
            map.GetMapData();
            player = new Player();
            player.Initialize(15, 10, 10, player.avatar);
            tracker = new Tracker();
            tracker.Initialize(3, 10, 5, tracker.avatar);
            player.ShowStats();
            tracker.ShowStats();
            Console.CursorVisible = false;
        }

        public void GameLoop(Player player, Tracker tracker, Map map)
        {
            //Game Loop
            while (player.dead == false)
            {
                map.Update(player, ref tracker);
                player.CalculateMovement(map, tracker);
                if (tracker != null)
                {
                    tracker.ShowStats();
                }

                map.Update(player, ref tracker);
                if (tracker != null)
                {
                    tracker.CalculateMovement(map, player);
                }
                player.ShowStats();
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
            GameLoop(player, tracker, map);
            EndGame();
        }
    }
}


