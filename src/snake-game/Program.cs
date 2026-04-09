using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

int width = 20;
int height = 10;

// snake body (head first)
List<(int x, int y)> snake = new List<(int, int)>
{
    (5, 5),
    (4, 5),
    (3, 5)
};

while (true)
{
    Console.Clear();

    // draw field
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            if (snake.Any(p => p.x == x && p.y == y))
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

    // movement (right)
    var head = snake[0];
    var newHead = (head.x + 1, head.y);

    // add new head
    snake.Insert(0, newHead);

    // remove tail
    snake.RemoveAt(snake.Count - 1);

    Thread.Sleep(200);
}