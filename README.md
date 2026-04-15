#  Snake Game (C# Console)

A classic Snake game built in C# using the console.

##  Features

- Snake movement using arrow keys
- Collision detection (walls & self)
- Food system with score tracking
- Highscore system with name input
- Persistent highscores saved to file
- Colored UI for better gameplay experience
- Modular code structure (multiple files)

---

##  Project Structure

- `Program.cs` – Entry point, handles game restart
- `Game.cs` – Core game logic (movement, collision, scoring)
- `GameRenderer.cs` – Responsible for drawing the game
- `Helpers.cs` – Input handling and utility functions
- `HighscoreService.cs` – Highscore logic and file handling

---

##  Controls

- ⬆️ Up Arrow – Move up  
- ⬇️ Down Arrow – Move down  
- ⬅️ Left Arrow – Move left  
- ➡️ Right Arrow – Move right  

---

##  Highscore System

- Top scores are saved to a file (`highscores.txt`)
- If you reach top 4, you can enter your name
- Highscores persist between game sessions

---

##  How to Run

1. Navigate to the project folder:
   ```bash
   cd src/snake-game

2. Run the game
3. ```bash
   dotnet run
   
---

## What I learned
- Structuring a project into multiple files
- Separation of concerns (logic vs rendering vs data)
- Working with loops and game state
- Handling user input in console apps
- File handling in C# (saving highscores)

   
   
