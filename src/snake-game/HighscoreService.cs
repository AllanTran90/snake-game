using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class HighscoreEntry
{
    public string Name { get; set; }
    public int Score { get; set; }
}

public static class HighscoreService
{
    private static string filePath = "highscores.txt";

    public static List<HighscoreEntry> GetHighscores()
    {
        if (!File.Exists(filePath))
            return new List<HighscoreEntry>();

        return File.ReadAllLines(filePath)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line =>
            {
                var parts = line.Split(',');

                if (parts.Length < 2)
                    return null;

                if (!int.TryParse(parts[1], out int score))
                    return null;

                return new HighscoreEntry
                {
                    Name = parts[0],
                    Score = score
                };
            })
            .Where(entry => entry != null)
            .OrderByDescending(entry => entry.Score)
            .ToList();
    }

    public static void SaveHighscores(List<HighscoreEntry> scores)
    {
        var lines = scores.Select(s => $"{s.Name},{s.Score}");
        File.WriteAllLines(filePath, lines);
    }

    public static void TryAddScore(int newScore)
    {
        var scores = GetHighscores();

        if (scores.Count < 4 || newScore > scores.Last().Score)
        {
            Console.Write("🎉 New Highscore! Enter your name: ");
            string name = Console.ReadLine() ?? "Unknown";

            scores.Add(new HighscoreEntry
            {
                Name = name,
                Score = newScore
            });

            scores = scores
                .OrderByDescending(x => x.Score)
                .Take(4)
                .ToList();

            SaveHighscores(scores);
        }
    }

    public static void ShowTopScores()
    {
        var scores = GetHighscores();

        Console.WriteLine("\n🏆 Highscores:");

        if (scores.Count == 0)
        {
            Console.WriteLine("No scores yet.");
            return;
        }

        for (int i = 0; i < scores.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scores[i].Name} - {scores[i].Score}");
        }
    }
}