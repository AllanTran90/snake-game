using System;

int width = 20;
int height = 10;

int snakeX = 5;
int snakeY = 5;

for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        if (x == snakeX && y == snakeY)
        {
            Console.Write("O");
        }
        else
        {
            Console.Write(".");
        }
    }
    Console.WriteLine();
}