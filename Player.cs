using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Player: GameCharacter
    {
        private ConsoleKey input;
        private readonly ConsoleKey UP = ConsoleKey.W;
        private readonly ConsoleKey DOWN = ConsoleKey.S;
        private readonly ConsoleKey LEFT = ConsoleKey.A;
        private readonly ConsoleKey RIGHT = ConsoleKey.D;

        public void Move(Map map, Enemy enemy)
        {

            SaveLastPosition();
            input = Console.ReadKey(true).Key;
            if (input == UP || input == ConsoleKey.UpArrow)
            {
                y--;
            }
            else if (input == DOWN || input == ConsoleKey.DownArrow)
            {
                y++;
            }
            else if (input == LEFT || input == ConsoleKey.LeftArrow)
            {
                x--;
            }
            else if (input == RIGHT || input == ConsoleKey.RightArrow)
            {
                x++;
            }

            if (map.IsObjectSolid(x, y) == true)
            {
                Console.Beep(250, 33);
                RecallLastPosition();
            }

            if (IsGameCharacter(this, enemy))
            {
                Console.Beep(400, 33);
                Console.Beep(500, 33);
                enemy.TakeDamage();
                RecallLastPosition();
            }
        }

       
    }
}
