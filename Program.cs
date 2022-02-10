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
            Map map = new Map();
            Player player = new Player();
            Enemy enemy = new Enemy();

            while(true)
            {
                map.Update(player.x, player.y, enemy.x, enemy.y, player.avatar, enemy.avatar);
                player.Move(map);
                enemy.Move(player.x, player.y, map);
            }
        }
    }
}
