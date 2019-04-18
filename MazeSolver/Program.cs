using System;
using System.Linq;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var usrInput = "";

            do
            {
                Console.Clear();
                Maze maze = new Maze();

                Print(maze.ToString(), false);
                var userInputValid = false;
                Cell end = null;

                do
                {
                    Print("\nEnter the destiny cell (A#): ", false);
                    usrInput = Console.ReadLine().ToUpper();

                    if (IsValidInput(usrInput))
                    {
                        var firstLetter = usrInput.ElementAt(0);
                        var x = Convert.ToInt32(usrInput.Substring(1, 1)) - 1;
                        var y = (int)firstLetter - 65;
                        end = maze.Cells[x, y];

                        if (end.IsWalkable)
                            userInputValid = true;
                        else
                            Print("ERROR: The cell you enetred represents a wall. Please try again: ", true);
                    }
                    else
                    {
                        Print("ERROR: The expected format is one letter and one number. Please try again: ", true);
                    }

                } while (!userInputValid);

                Solver solver = new Solver(maze, end);
                solver.Search();

                Console.Clear();

                Print(maze.ToString(), false);
                Print("\nThis is the fastest way to that point.", false);
                Print("\nDo you want to restart? (y/n): ", false);

                usrInput = Console.ReadLine();
            } while (usrInput.ToLower() != "n");
        }

        protected static void Print(string str, bool isError)
        {
            if (isError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(str);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.WriteLine(str);
            }
        }

        protected static bool IsValidInput(string str)
        {
            if (str.Length == 2)
            {
                if (char.IsNumber(str.ElementAt(1)))
                {
                    var letter = (int)str.ElementAt(0);

                    if (letter >= 65 && letter <= 90)
                        return true;
                }
            }

            return false;
        }
    }
}
