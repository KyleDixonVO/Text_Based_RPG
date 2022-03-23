using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class HUD
    {
        public void ShowPlayerStats(Player player)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(1, 13);
            Console.Write(player.avatar + " health: " + player.health + "/" + player.maxHealth + " damage: " + player.damage + " ");
            Console.ResetColor();
        }

        public void ShowEnemyStats(Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, 14);
            Console.Write(enemy.avatar + " health: " + enemy.health + "/" + enemy.maxHealth + " ");
            Console.ResetColor();
        }
    }
}
