using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class HUD
    {
        public void ShowPlayerStats(ref Player player, Map map, Camera camera)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(Console.WindowLeft +1, Console.WindowTop + camera.windowHeight - 2);
            //Console.Write(player.avatar + " health: " + player.health + "/" + player.maxHealth + " damage: " + player.damage + " ");
            Console.ResetColor();
        }

        public void ShowEnemyStats(Enemy enemy, Map map, Camera camera)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowLeft +1, Console.WindowTop + camera.windowHeight - 1);
            //Console.Write(enemy.avatar + " health: " + enemy.health + "/" + enemy.maxHealth + " ");
            Console.ResetColor();
        }
    }
}
