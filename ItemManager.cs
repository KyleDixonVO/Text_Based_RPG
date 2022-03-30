using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class ItemManager
    {
        const int maxItems = 40;
        public Item[] items = new Item[maxItems];
        private Random rd = new Random();
        private int randomType;

        public void CheckContact(Player player, Key key, Inventory inventory)
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i].OnContact(player, key, inventory);
            }
        }

        public void CreateItems()
        {
            items[0] = new Key();
            items[0].name = ("Key" + 0.ToString());
            Console.WriteLine(items[0].GetName());
            for (int i = 1; i < maxItems; i++)
            {
                if (i < 26)
                {
                    items[i] = new Money();
                    items[i].name = ("Money" + i.ToString());
                }
                else
                {
                    randomType = rd.Next(0, 2);
                    if (randomType == 0)
                    {
                        items[i] = new Medkit(rd.Next(1, 50), rd.Next(20, 22));
                        items[i].name = ("Medkit" + i.ToString());
                    }
                    else if (randomType == 1)
                    {
                        items[i] = new PowerUp(rd.Next(50, 70), rd.Next(10, 15));
                        items[i].name = ("PowerUP" + i.ToString());
                    }
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

        public void Update(Player player, Key key, Inventory inventory)
        {
            CheckIfUsed();
            CheckContact(player, key, inventory);
        }

        public void Draw(Renderer renderer, Camera camera)
        {
            for (int i = 0; i < items.Length; i++)
            {
                renderer.SetItemColor(this, i);
                renderer.Draw(items[i].x, items[i].y, items[i].avatar, camera);
                Console.ResetColor();
            }
        }
    }
}
