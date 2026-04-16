using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Game
{
    private int width = 20;
    private int height = 10;

    private string direction = "RIGHT";
    private Random rand;
    private List<(int x, int y)> snake;
    private (int x, int y) food;

    public Game()
    {
        rand = new Random();

        snake = new List<(int, int)>
        {
            (5, 5),
            (4, 5),
            (3, 5)
        };

        food = Helpers.SpawnFood(rand, width, height, snake);
    }

    public void Run()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
       
        
        bool gameOver = false;

        while (!gameOver)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Score: {snake.Count - 3}");
            Console.ResetColor();

            GameRenderer.DrawBoard(width, height, snake, food);

            direction = Helpers.ReadInput(direction);

            MoveSnake();

            if (CheckCollision())
            {
                gameOver = true;
                break;
            }

            if (CheckFood())
            {
                GrowSnake();
                food = Helpers.SpawnFood(rand, width, height, snake);
            }

            Thread.Sleep(200);
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        int finalScore = snake.Count - 3;
        Console.WriteLine($"Final score: {finalScore}");
        

        HighscoreService.TryAddScore(finalScore);
        HighscoreService.ShowTopScores();
    }

    private void MoveSnake()
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

    private bool CheckCollision()
    {
        (int x, int y) head = snake[0];

        if (head.x < 0 || head.x >= width || head.y < 0 || head.y >= height)
            return true;

        return snake.Skip(1).Any(part => part.x == head.x && part.y == head.y);
    }

    private bool CheckFood()
    {
        return snake[0].x == food.x && snake[0].y == food.y;
    }

    private void GrowSnake()
    {
        snake.Add(snake.Last());
    }
}