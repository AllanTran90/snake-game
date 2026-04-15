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
                if (snake[0].x == x && snake[0].y == y)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("O");
                }
                else if (snake.Any(p => p.x == x && p.y == y))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("o");
                }
                else if (x == food.x && y == food.y)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(".");
                }

                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}