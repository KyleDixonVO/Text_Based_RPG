using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class HUD
    {
        public void ShowPlayerStats(Player player, Map map)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(1, map.rows + 2);
            Console.Write(player.avatar + " health: " + player.health + "/" + player.maxHealth + " damage: " + player.damage + " ");
            Console.ResetColor();
        }

        public void ShowEnemyStats(Enemy enemy, Map map)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, map.rows + 3);
            Console.Write(enemy.avatar + " health: " + enemy.health + "/" + enemy.maxHealth + " ");
            Console.ResetColor();
        }
    }
}
