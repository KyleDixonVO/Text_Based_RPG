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
        private int nextX;
        private int nextY;

        public void CheckContact(Player player, Key key, Inventory inventory)
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i].OnContact(player, key, inventory);
            }
        }

        public void CreateItems(Renderer renderer, Map map)
        {
            items[0] = new Key(3, 26);
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
                        IsSpawnValid(1, 50, 20, 22, renderer, map);
                        items[i] = new Medkit(nextX, nextY);
                        items[i].name = ("Medkit" + i.ToString());
                    }
                    else if (randomType == 1)
                    {
                        IsSpawnValid(50, 70, 10, 15, renderer, map);
                        items[i] = new PowerUp(nextX, nextY);
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
        {   if (items[0].obtained == false)
            {
                renderer.SetItemColor(this, 0);
                renderer.Draw(items[0].x, items[0].y, items[0].avatar, camera);
            }
            else
            {
                renderer.Draw(items[0].x, items[0].y, '\0', camera);
            }


            for (int i = 1; i < items.Length; i++)
            {
                if (items[i].used == false)
                {
                    renderer.SetItemColor(this, i);
                    renderer.Draw(items[i].x, items[i].y, items[i].avatar, camera);
                    Console.ResetColor();
                }
                else
                {
                    renderer.Draw(items[i].x, items[i].y, '\0', camera);
                }

            }
        }

        public void IsSpawnValid(int MinX, int MaxX, int MinY, int MaxY, Renderer renderer, Map map)
        {
            int valueX = rd.Next(MinX, MaxX);
            int valueY = rd.Next(MinY, MaxY);
            if (renderer.IsObjectSolid(valueX, valueY, map) == true)
            {
                IsSpawnValid(MinX, MaxX, MinY, MaxY, renderer, map);
            }
            else
            {
                nextX = valueX;
                nextY = valueY;
            }
        }
    }
}
