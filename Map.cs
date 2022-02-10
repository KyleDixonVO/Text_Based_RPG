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
        private int PrevEnemyX;
        private int PrevEnemyY;
        private int PrevPlayerX;
        private int PrevPlayerY;
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
        public void Update(int playerX, int playerY, int enemyX, int enemyY, char playerAvatar, char enemyAvatar)
        {
            DrawMap(playerX, playerY, enemyX, enemyY);
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
            Console.SetWindowSize((columns +2), (columns +2));
            Console.SetBufferSize((columns +2), (columns +2));
        }

        private void DrawMap(int playerX, int playerY, int enemyX, int enemyY)
        {
            
            if (hasMapInitialized == false)
            {
                SetBounds();

                DrawBorderH();
                for (int i = 0; i < rows; i++)
                {
                    Console.Write("\r");
                    DrawBorderV();
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(mapTiles[i, j]);
                    }
                    DrawBorderV();
                }
                Console.Write("\r");
                DrawBorderH();
            }
            hasMapInitialized = true;

            Console.SetCursorPosition(PrevPlayerX, PrevPlayerY);
            Console.Write(mapTiles[PrevPlayerY, PrevPlayerX]);
            Console.SetCursorPosition(PrevEnemyX, PrevEnemyY);
            Console.Write(mapTiles[PrevEnemyY, PrevEnemyX]);
            PrevPlayerX = playerX;
            PrevPlayerY = playerY;
            PrevEnemyX = enemyX;
            PrevEnemyY = enemyY;
        }

        private void DrawBorderH()
        {
            for (int i = 0; i < columns +2; i++)
            {
                Console.Write('═');
            }
        }

        private void DrawBorderV()
        {
            Console.Write('║');
        }

        public bool isObjectSolid(int solidX, int solidY)
        {
            if (mapTiles[solidY, solidX] == '^' || mapTiles [solidY,solidX] == '~' || mapTiles[solidY, solidX] == '║' || mapTiles[solidY,solidX] == '═')
            {
                return true;
            }
            return false;
        }
    }
}
