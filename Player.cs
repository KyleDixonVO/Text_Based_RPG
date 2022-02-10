using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Player
    {
        private ConsoleKey input;
        public int x = 10;
        public int y = 10;
        public char avatar = '@';
        private int health = 100;
        private ConsoleKey UP = ConsoleKey.W;
        private ConsoleKey DOWN = ConsoleKey.S;
        private ConsoleKey LEFT = ConsoleKey.A;
        private ConsoleKey RIGHT = ConsoleKey.D;

        public void Move(Map map)
        {


            input = Console.ReadKey(true).Key;
            if (input == UP)
            {
                y--;
                if (map.isObjectSolid(x-1,y-1) == true)
                {
                    y++;
                }
            }
            if (input == DOWN)
            {
                y++;
                 if (map.isObjectSolid(x-1,y-1) == true)
                 {
                    y--;
                 }
            }
            if (input == LEFT)
            {
                x--;
                 if (map.isObjectSolid(x-1,y-1) == true)
                 {
                    x++;
                 }
            }
            if (input == RIGHT)
            {
                x++;
                 if (map.isObjectSolid(x-1,y-1) == true)
                 {
                    x--;
                 }
            }

        }

        private void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}
