namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        public static void Main()
        {
            const int MaxFieldsWithoutMines = 35;

            int row = 0;
            int col = 0;
            int pointsCounter = 0;
            string command = string.Empty;
            char[,] playfield = CreatePlayfield();
            char[,] mines = SetMines();
            bool isGameAtStart = true;
            bool isSteppedOnMine = false;
            bool isGameWon = false;
            List<ScoreInfo> highscores = new List<ScoreInfo>(6);

            do
            {
                if (isGameAtStart)
                {
                    Console.WriteLine("Let's play 'Minesweeper'. Try to step only on the fields without mines." +
                    " Command 'top' shows the highscores, 'restart' starts a new game, 'exit' quits the game!");
                    PrintPlayfield(playfield);
                    isGameAtStart = false;
                }

                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= playfield.GetLength(0) && col <= playfield.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintHighscores(highscores);
                        break;
                    case "restart":
                        playfield = CreatePlayfield();
                        mines = SetMines();
                        PrintPlayfield(playfield);
                        isSteppedOnMine = false;
                        isGameAtStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                GetFieldValue(playfield, mines, row, col);
                                pointsCounter++;
                            }

                            if (MaxFieldsWithoutMines == pointsCounter)
                            {
                                isGameWon = true;
                            }
                            else
                            {
                                PrintPlayfield(playfield);
                            }
                        }
                        else
                        {
                            isSteppedOnMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("{0}Invalid command!{0}");
                        Console.WriteLine("Please enter a valid command (e.g 'top', 'restart', 'exit', 'turn'){0}", Environment.NewLine);
                        break;
                }

                if (isSteppedOnMine)
                {
                    PrintPlayfield(mines);
                    Console.Write(Environment.NewLine + "Game over! Your scores: {0}. Enter your nickname: ", pointsCounter);
                    string nickname = Console.ReadLine();
                    ScoreInfo playerScores = new ScoreInfo(nickname, pointsCounter);

                    if (highscores.Count < 5)
                    {
                        highscores.Add(playerScores);
                    }
                    else
                    {
                        for (int i = 0; i < highscores.Count; i++)
                        {
                            if (highscores[i].PlayerPoints < playerScores.PlayerPoints)
                            {
                                highscores.Insert(i, playerScores);
                                highscores.RemoveAt(highscores.Count - 1);
                                break;
                            }
                        }
                    }

                    highscores.Sort((ScoreInfo r1, ScoreInfo r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    highscores.Sort((ScoreInfo r1, ScoreInfo r2) => r2.PlayerPoints.CompareTo(r1.PlayerPoints));
                    PrintHighscores(highscores);

                    playfield = CreatePlayfield();
                    mines = SetMines();
                    pointsCounter = 0;
                    isSteppedOnMine = false;
                    isGameAtStart = true;
                }

                if (isGameWon)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintPlayfield(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    ScoreInfo to4kii = new ScoreInfo(imeee, pointsCounter);
                    highscores.Add(to4kii);
                    PrintHighscores(highscores);
                    playfield = CreatePlayfield();
                    mines = SetMines();
                    pointsCounter = 0;
                    isGameWon = false;
                    isGameAtStart = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Press Enter to exit");
            Console.Read();
        }

        private static void PrintHighscores(List<ScoreInfo> highscores)
        {
            Console.WriteLine(Environment.NewLine + "HIGHSCORES:");
            if (highscores.Count > 0)
            {
                for (int i = 0; i < highscores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} opened fields", i + 1, highscores[i].PlayerName, highscores[i].PlayerPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranking!" + Environment.NewLine);
            }
        }

        private static void GetFieldValue(char[,] playfield, char[,] mines, int row, int col)
        {
            char minesCount = CountMines(mines, row, col);
            mines[row, col] = minesCount;
            playfield[row, col] = minesCount;
        }

        private static void PrintPlayfield(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayfield()
        {
            int rows = 5;
            int cols = 10;
            char[,] playfield = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playfield[i, j] = '?';
                }
            }

            return playfield;
        }

        private static char[,] SetMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playfield = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playfield[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!mines.Contains(randomNumber))
                {
                    mines.Add(randomNumber);
                }
            }

            foreach (int mine in mines)
            {
                int col = mine / cols;
                int row = mine % cols;
                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playfield[col, row - 1] = '*';
            }

            return playfield;
        }

        private static void CalculateFieldValue(char[,] playfield)
        {
            int col = playfield.GetLength(0);
            int row = playfield.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (playfield[i, j] != '*')
                    {
                        char numberOfmines = CountMines(playfield, i, j);
                        playfield[i, j] = numberOfmines;
                    }
                }
            }
        }

        private static char CountMines(char[,] playfield, int row, int col)
        {
            int count = 0;
            int rows = playfield.GetLength(0);
            int cols = playfield.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playfield[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (playfield[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (playfield[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (playfield[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (playfield[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (playfield[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (playfield[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (playfield[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
