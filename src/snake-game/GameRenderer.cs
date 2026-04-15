using System;
using System.Collections.Generic;
using System.Linq;

public static class GameRenderer
{
    public static void DrawBoard(int width, int height, List<(int x, int y)> snake, (int x, int y) food)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (snake.Any(p => p.x == x && p.y == y))
                {
                    Console.Write("O");
                }
                else if (x == food.x && y == food.y)
                {
                    Console.Write("X");
                }
                else
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();
        }
    }
}