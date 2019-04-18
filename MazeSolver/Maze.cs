using System.Collections.Generic;
using System.Linq;

namespace MazeSolver
{
    class Maze
    {
        public Maze()
        {
            Initialize();
        }

        public Cell[,] Cells { get; private set; }

        private void Initialize()
        {
            var fullMaze = Properties.Resources.Map;
            fullMaze = fullMaze.Replace("\r", "");
            var slices = fullMaze.Split('\n');

            if (slices[0].Length > 0)
                Cells = new Cell[slices.Length, slices[0].Length];

            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    var isWalkable = (slices[i].ElementAt(j) == 'o');
                    Cells[i, j] = new Cell(i, j, isWalkable);

                    if (isWalkable && i == 0 && j == 0)
                    {
                        Cells[i, j].IsFirstCell = true;
                        Cells[i, j].IsChecked = true;
                    }
                }
            }
        }

        private void AddIfWalkable(Cell nextCell, ref List<Cell> cells)
        {
            if (ShouldCheck(nextCell))
                cells.Add(nextCell);
        }

        public List<Cell> GetAdjacentWalkableCells(Cell cell)
        {
            List<Cell> cells = new List<Cell>();

            if (cell.X > 0)
            {
                AddIfWalkable(Cells[cell.X - 1, cell.Y], ref cells);
            }

            if (cell.X < Cells.GetLength(0) - 1)
            {
                AddIfWalkable(Cells[cell.X + 1, cell.Y], ref cells);
            }

            if (cell.Y > 0)
            {
                AddIfWalkable(Cells[cell.X, cell.Y - 1], ref cells);
            }

            if (cell.Y < Cells.GetLength(1) - 1)
            {
                AddIfWalkable(Cells[cell.X, cell.Y + 1], ref cells);
            }

            return cells;
        }

        private bool ShouldCheck(Cell cell)
        {
            return cell.IsWalkable && !cell.IsChecked;
        }

        public override string ToString()
        {
            const string LETTERS = "\tA  B  C  D  E  F  G  H";
            const string BLOCK = "###";

            var border = "  | " + new string('#', 30);
            var line = "  +" + new string('-', 30);

            var strMaze = LETTERS + "\n" + line + "\n" + border + "\n";

            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                strMaze += " " + (i + 1) + "| " + BLOCK;

                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    strMaze += Cells[i, j].ToString();
                }

                strMaze += BLOCK + "\n";
            }

            return strMaze + border;
        }
    }
}
