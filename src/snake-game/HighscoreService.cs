using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class HighscoreService
{
    private static string filePath = "highscores.txt";

    public static void SaveScore(int score)
    {
        File.AppendAllText(filePath, score + Environment.NewLine);
    }

    public static List<int> GetHighscores()
    {
        if (!File.Exists(filePath))
            return new List<int>();

        return File.ReadAllLines(filePath)
            .Select(line => int.Parse(line))
            .OrderByDescending(score => score)
            .ToList();
    }

    public static void ShowTopScores(int count = 5)
    {
        var scores = GetHighscores().Take(count).ToList();

        Console.WriteLine("\n🏆 Highscores:");

        if (scores.Count == 0)
        {
            Console.WriteLine("No scores yet.");
            return;
        }

        for (int i = 0; i < scores.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scores[i]}");
        }
    }
}