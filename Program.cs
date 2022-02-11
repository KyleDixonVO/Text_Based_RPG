using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            //On game launch
            Map map = new Map();
            Player player = new Player();
            Enemy enemy = new Enemy();
            enemy.Initialize(3, 10, 5, 'E');
            player.ShowStats();
            enemy.ShowStats();
            Console.CursorVisible = false;


            //Game Loop
            while (player.dead == false)
            {
                map.Update(player, ref enemy);
                player.Move(map, enemy);
                if (enemy != null)
                {
                    enemy.ShowStats();
                }

                map.Update(player, ref enemy);
                if (enemy != null)
                {
                    enemy.Move(map, player);
                }
                player.ShowStats();
            }


            //Game end
            Console.Clear();
            Console.SetCursorPosition(5, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You Died! Game Over");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
}
