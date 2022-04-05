using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Inventory
    {

        public List<Item> PlayerInventory;
        public int money;
        public int inventoryCoordX;
        public int inventoryCoordY;

        public Inventory()
        {
            money = 0;
            PlayerInventory = new List<Item>();
        }
        public void ShowInventory(Camera camera)
        {
            Console.SetCursorPosition(Console.WindowLeft + 1, Console.WindowTop + 15);
            inventoryCoordX = Console.CursorLeft;
            inventoryCoordY = Console.CursorTop;
            Console.Write("Money: " + money);
            Console.SetCursorPosition(Console.WindowLeft + 1, Console.WindowTop + 16);
            Console.Write("Player Inventory:");
            int i = 17;
            foreach (Item item in PlayerInventory)
            {
                Console.SetCursorPosition(Console.WindowLeft + 1, Console.WindowTop + 17);
                Console.Write(item.name);
                i++;
            }
        }

        public void Update(Camera camera)
        {
            ShowInventory(camera);
        }
    }
}
