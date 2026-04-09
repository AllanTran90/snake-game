using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

int width = 20;
int height = 10;

//direction
string direction = "RIGHT";

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

    //input
    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                direction = "UP";
                break;
            case ConsoleKey.DownArrow:
                direction = "DOWN";
                break;
            case ConsoleKey.LeftArrow:
                direction = "LEFT";
                break;
            case ConsoleKey.RightArrow:
                direction = "RIGHT";
                break;
        }
    }

    var head = snake[0];

    (int x, int y) newHead = direction switch
    {
        "UP" => (head.x, head.y - 1),
        "DOWN" => (head.x, head.y + 1),
        "LEFT" => (head.x - 1, head.y),
        _ => (head.x + 1, head.y)
    };

    // lägg till nytt huvud
    snake.Insert(0, newHead);

    // ta bort svans
    snake.RemoveAt(snake.Count - 1);

    Thread.Sleep(150);
}