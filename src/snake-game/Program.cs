using System;

bool restart = true;

while (restart)
{
    Game game = new Game();
    game.Run();

    Console.WriteLine("Play again? (y/n)");
    string answer = Console.ReadLine()?.ToLower() ?? "n";
    restart = answer == "y";
}