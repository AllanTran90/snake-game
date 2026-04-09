using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

int width = 20;
int height = 10;

// restart loop
bool restart = true;

while (restart)
{
    // direction
    string direction = "RIGHT";

    // random food
    Random rand = new Random();
    (int x, int y) food = (rand.Next(width), rand.Next(height));

    // snake body
    List<(int x, int y)> snake = new List<(int, int)>
    {
        (5, 5),
        (4, 5),
        (3, 5)
    };

    while (true)
    {
        Console.Clear();

        Console.WriteLine($"Score: {snake.Count}");

        // draw field
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

        // input
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

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

        // 💀 wall collision
        if (newHead.x < 0 || newHead.x >= width || newHead.y < 0 || newHead.y >= height)
        {
            Console.Clear();
            Console.WriteLine("GAME OVER!");
            Console.WriteLine($"Score: {snake.Count}");
            Console.WriteLine("Press any key to restart...");
            Console.ReadKey(true);
            break; // go back to restart loop
        }

        // 💀 self collision
        if (snake.Any(p => p.x == newHead.x && p.y == newHead.y))
        {
            Console.Clear();
            Console.WriteLine("GAME OVER!");
            Console.WriteLine($"Score: {snake.Count}");
            Console.WriteLine("Press any key to restart...");
            Console.ReadKey(true);
            break;
        }

        // check if we ate food
        bool ateFood = newHead.x == food.x && newHead.y == food.y;

        // add new head
        snake.Insert(0, newHead);

        if (ateFood)
        {
            food = (rand.Next(width), rand.Next(height));
        }
        else
        {
            snake.RemoveAt(snake.Count - 1);
        }

        Thread.Sleep(150);
    }
}