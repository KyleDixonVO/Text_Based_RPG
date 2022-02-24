using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Map
    {
        private int rows;
        private int columns;
        private bool hasMapInitialized = false;
        private char[,] mapTiles = new char[,]
        {
            {'╔','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','╗'},
            {'║','^',' ',' ',' ',' ','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','~','~','~',' ',' ','║'},
            {'║','^',' ',' ',' ','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ','~','~','~',' ',' ',' ',' ','║'},
            {'║',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','║'},
            {'║',' ',' ',' ','~','~','~',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','║'},
            {'║',' ',' ',' ','~','~','~','~','~',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','^',' ',' ',' ',' ',' ',' ','║'},
            {'║',' ',' ','~','~','~','~','~','~','~','~','~','~',' ',' ',' ',' ',' ',' ',' ',' ','^','^','^',' ',' ',' ',' ',' ','║'},
            {'║',' ',' ',' ','~','~','~','~','~','~',' ',' ',' ','~','~','~',' ',' ',' ','^','^','^','^','^','^',' ',' ',' ',' ','║'},
            {'║',' ',' ','*',' ','~','~','~','~',' ',' ',' ',' ',' ',' ',' ',' ',' ','^','^','^','^','^','^','^','^','^',' ',' ','║'},
            {'║',' ',' ',' ',' ',' ',' ','~','~',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','║'},
            {'║',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','║'},
            {'╚','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','╝'},
        };
        public void Update(Player player, ref Enemy enemy)
        {
            DrawMap(player, enemy);
            DrawEntities(player, ref enemy);
        }

        private void DrawEntities(Player player, ref Enemy enemy)
        {
            //drawing player
            Console.SetCursorPosition(player.x, player.y);
            Console.Write(player.avatar);

            //drawing enemy
            if (enemy == null)return;
            
            if (enemy.dead == false)
            {
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(enemy.avatar);
            }
            else
            {
                enemy.avatar = ' ';
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(enemy.avatar);
                enemy = null;
            }
            
        }

        

        private void SetBounds()
        {
            rows = mapTiles.GetUpperBound(0) + 1;
            columns = mapTiles.GetUpperBound(1) + 1;
            Console.SetWindowSize((columns), (columns));
            Console.SetBufferSize((columns), (columns));
        }

        private void DrawMap(Player player, Enemy enemy)
        {
            Console.SetCursorPosition(0, 0);
            if (hasMapInitialized == false)
            {
                SetBounds();
                for (int i = 0; i < rows; i++)
                {
                    Console.Write("\r");
                    for (int j = 0; j < columns; j++)
                    {
                        SetTileColor(i, j);
                        Console.Write(mapTiles[i, j]);
                        Console.ResetColor();
                    }
                }
                Console.Write("\r");
            }
            hasMapInitialized = true;

            Console.SetCursorPosition(player.LastX, player.LastY);
            Console.Write(mapTiles[player.LastY, player.LastX]);
            if (enemy != null)
            {
                Console.SetCursorPosition(enemy.LastX, enemy.LastY);
                Console.Write(mapTiles[enemy.LastY, enemy.LastX]);
            }
        }

        public bool IsObjectSolid(int testX, int testY)
        {
            if (mapTiles[testY, testX] == '^' || mapTiles [testY,testX] == '~' || mapTiles[testY, testX] == '║' || mapTiles[testY,testX] == '═' || mapTiles[testY, testX] == '*')
            {
                return true;
            }
            return false;
        }

        private void SetTileColor(int i, int j)
        {
            if (mapTiles[i,j] == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else if (mapTiles[i,j] == '~')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (mapTiles[i,j] == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
