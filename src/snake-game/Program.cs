using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

int width = 20;
int height = 10;

//direction
string direction = "RIGHT";

// highscore
int highScore = 0;

// random food
Random rand = new Random();
(int x, int y) food = (10, 5);

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
    
    // SCORE
    Console.WriteLine($"Score: {snake.Count}");
    Console.WriteLine($"Highscore: {highScore}");

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

    //input
    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey(true).Key;
        
        //empty input-buffer
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

    //movement
    var head = snake[0];

    (int x, int y) newHead = direction switch
    {
        "UP" => (head.x, head.y - 1),
        "DOWN" => (head.x, head.y + 1),
        "LEFT" => (head.x - 1, head.y),
        _ => (head.x + 1, head.y)
    };

// 💀 WALL COLLISION
    if (newHead.x < 0 || newHead.x >= width || newHead.y < 0 || newHead.y >= height)
    {
        Console.Clear();

        if (snake.Count > highScore)
        {
            highScore = snake.Count;
        }

        Console.WriteLine("GAME OVER!");
        Console.WriteLine($"Score: {snake.Count}");
        Console.WriteLine($"Highscore: {highScore}");
        break;
    }

    //  self collision
    if (snake.Any(p => p.x == newHead.x && p.y == newHead.y))
    {
        Console.Clear();

        if (snake.Count > highScore)
        {
            highScore = snake.Count;
        }

        Console.WriteLine("GAME OVER!");
        Console.WriteLine($"Score: {snake.Count}");
        Console.WriteLine($"Highscore: {highScore}");
        break;
    }

    //  food
    bool ateFood = newHead.x == food.x && newHead.y == food.y;

    // add head
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