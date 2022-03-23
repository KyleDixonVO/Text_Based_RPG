using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class ItemManager
    {
        const int maxItems = 76;
        public Item[] items = new Item[maxItems];
        private Random rd = new Random();
        private int randomType;

        public void CreateItems()
        {
            for (int i = 0; i < maxItems; i++)
            {
                if (i == 0)
                {
                    items[i] = new Key();
                    items[i].name = ("Key" + i.ToString());
                }

                randomType = rd.Next(0, 2);
                if (randomType == 0)
                {
                    items[i] = new Money();
                    items[i].name = ("Money" + i.ToString());
                }
                else if (randomType == 1)
                {
                    items[i] = new Medkit();
                    items[i].name = ("Medkit" + i.ToString());
                }
                else if (randomType == 2)
                {
                    items[i] = new PowerUp();
                    items[i].name = ("PowerUP" + i.ToString());
                }
                Console.WriteLine(items[i].GetName());
            }
            Console.ReadKey(true);
        }
    }
}
