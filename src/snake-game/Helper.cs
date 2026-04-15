using System;
using System.Collections.Generic;
using System.Linq;

public static class Helpers
{
    public static string ReadInput(string currentDirection)
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

    public static (int x, int y) SpawnFood(Random rand, int width, int height, List<(int x, int y)> snake)
    {
        (int x, int y) foodPosition;

        do
        {
            foodPosition = (rand.Next(width), rand.Next(height));
        }
        while (snake.Any(p => p.x == foodPosition.x && p.y == foodPosition.y));

        return foodPosition;
    }
}