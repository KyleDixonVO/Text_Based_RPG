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
        private int playerX;
        private int playerY;
        private int enemyX;
        private int enemyY;
        private char playerAvatar;
        private char enemyAvatar;
        private bool hasMapInitialized = false;
        public char[,] mapTiles = new char[,]
        {
            {'^','^','^','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'^','^','\'','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','~','~','\'','\'','\''},
            {'^','^','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\''},
            {'^','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','~','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','^','^','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','~','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','^','^','\'','\'','\''},
            {'\'','\'','\'','\'','\'','\'','\'','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            //{'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''}, //extra row for testing
        };
        public void Update()
        {
            DrawMap();
            DrawEntities(playerX,playerY,enemyX,enemyY,playerAvatar,enemyAvatar);
        }

        private void DrawEntities(int playerX, int playerY, int enemyX, int enemyY, char playerAvatar, char enemyAvatar)
        {
            //drawing player
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(playerAvatar);
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write(enemyAvatar);
        }

        

        private void SetBounds()
        {
            rows = mapTiles.GetUpperBound(0) + 1;
            columns = mapTiles.GetUpperBound(1) + 1;
            Console.SetBufferSize((columns + 2), (rows * 3));
            Console.SetBufferSize((columns + 2), (rows * 3));
        }

        private void DrawMap()
        {
            
            if (hasMapInitialized == false)
            {
                SetBounds();

                DrawBorderH();
                for (int i = 0; i < rows; i++)
                {
                    Console.Write("\r\n");
                    DrawBorderV();
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(mapTiles[i, j]);
                    }
                    DrawBorderV();
                }
                Console.Write("\r\n");
                DrawBorderH();
            }
        }

        private void DrawBorderH()
        {
            for (int i = 0; i < columns; i++)
            {
                Console.Write('═');
            }
        }

        private void DrawBorderV()
        {
            Console.Write('║');
        }
    }
}
