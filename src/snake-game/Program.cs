using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

// Game board size
int width = 20;
int height = 10;

// Restart loop
bool restart = true;

while (restart)
{
    string direction = "RIGHT";
    Random rand = new Random();

    List<(int x, int y)> snake = new List<(int, int)>
    {
        (5, 5),
        (4, 5),
        (3, 5)
    };

    (int x, int y) food = SpawnFood(rand, width, height, snake);

    bool gameOver = false;

    while (!gameOver)
    {
        Console.Clear();
        Console.WriteLine($"Score: {snake.Count - 3}");

        DrawBoard(width, height, snake, food);

        direction = ReadInput(direction);

        MoveSnake(snake, direction);

        if (CheckCollision(snake, width, height))
        {
            gameOver = true;
            break;
        }

        if (CheckFood(snake, food))
        {
            GrowSnake(snake);
            food = SpawnFood(rand, width, height, snake);
        }

        Thread.Sleep(200);
    }

    Console.Clear();
    Console.WriteLine("Game Over!");
    Console.WriteLine($"Final score: {snake.Count - 3}");
    Console.WriteLine("Play again? (y/n)");

    string answer = Console.ReadLine()?.ToLower() ?? "n";
    restart = answer == "y";
}

void DrawBoard(int width, int height, List<(int x, int y)> snake, (int x, int y) food)
{
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            if (snake[0].x == x && snake[0].y == y)
            {
                Console.Write("O");
            }
            else if (snake.Any(p => p.x == x && p.y == y))
            {
                Console.Write("o");
            }
            else if (food.x == x && food.y == y)
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

string ReadInput(string currentDirection)
{
    if (!Console.KeyAvailable)
        return currentDirection;

    ConsoleKey key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.UpArrow && currentDirection != "DOWN")
        return "UP";

    if (key == ConsoleKey.DownArrow && currentDirection != "UP")
        return "DOWN";

    if (key == ConsoleKey.LeftArrow && currentDirection != "RIGHT")
        return "LEFT";

    if (key == ConsoleKey.RightArrow && currentDirection != "LEFT")
        return "RIGHT";

    return currentDirection;
}

void MoveSnake(List<(int x, int y)> snake, string direction)
{
    (int x, int y) head = snake[0];

    if (direction == "RIGHT")
        head.x++;
    else if (direction == "LEFT")
        head.x--;
    else if (direction == "UP")
        head.y--;
    else if (direction == "DOWN")
        head.y++;

    snake.Insert(0, head);
    snake.RemoveAt(snake.Count - 1);
}

bool CheckCollision(List<(int x, int y)> snake, int width, int height)
{
    (int x, int y) head = snake[0];

    // Wall collision
    if (head.x < 0 || head.x >= width || head.y < 0 || head.y >= height)
        return true;

    // Self collision
    return snake.Skip(1).Any(part => part.x == head.x && part.y == head.y);
}

bool CheckFood(List<(int x, int y)> snake, (int x, int y) food)
{
    return snake[0].x == food.x && snake[0].y == food.y;
}

void GrowSnake(List<(int x, int y)> snake)
{
    snake.Add(snake.Last());
}

(int x, int y) SpawnFood(Random rand, int width, int height, List<(int x, int y)> snake)
{
    (int x, int y) foodPosition;

    do
    {
        foodPosition = (rand.Next(width), rand.Next(height));
    }
    while (snake.Any(p => p.x == foodPosition.x && p.y == foodPosition.y));

    return foodPosition;
}