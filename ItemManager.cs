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

        public void CheckContact(Player player, Key key)
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i].OnContact(player, key);
            }
        }

        public void CreateItems()
        {
            items[0] = new Key();
            items[0].name = ("Key" + 0.ToString());
            Console.WriteLine(items[0].GetName());
            for (int i = 1; i < maxItems; i++)
            {
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
            Console.Clear();
        }
        public void CheckIfUsed()
        {
            for (int i = 0; i < maxItems; i++)
            {
                if (items[i].used == true)
                {
                    NullItem(items[i]);
                }
            }
        }

        public void NullItem(Item item)
        {
            item = null;
        }

        public void Update(Player player, Key key)
        {
            CheckIfUsed();
            CheckContact(player, key);
        }
    }
}
