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
            //Console.SetCursorPosition(Console.WindowLeft + camera.windowWidth - 18, Console.WindowTop +1);
            inventoryCoordX = Console.CursorLeft;
            inventoryCoordY = Console.CursorTop;
            //Console.Write("Money: " + money);
            //Console.SetCursorPosition(Console.WindowLeft + camera.windowWidth - 18, Console.WindowTop + 2);
            //Console.Write("Player Inventory:");
            int i = 2;
            foreach (Item item in PlayerInventory)
            {
                //Console.SetCursorPosition(Console.WindowLeft + camera.windowWidth - 18, Console.WindowTop + i);
                //Console.Write(item.name);
                i++;
            }
        }
    }
}
