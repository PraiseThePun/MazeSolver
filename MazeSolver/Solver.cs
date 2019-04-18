using System.Collections.Generic;

namespace MazeSolver
{
    class Solver
    {
        private Maze maze;
        private Cell end;

        public Solver(Maze maze, Cell end)
        {
            this.maze = maze;
            this.end = end;
            end.IsFinal = true;
        }
              
        public void Search()
        {            
            var queue = new Queue<Cell>();
            queue.Enqueue(maze.Cells[0, 0]);
            var found = false;

            while (queue.Count > 0 && !found)
            {
                var current = queue.Dequeue();

                if (current.Equals(end))
                    found = true;

                foreach (var neighbour in maze.GetAdjacentWalkableCells(current))
                {
                    queue.Enqueue(neighbour);
                    neighbour.IsChecked = true;
                    neighbour.PreviousCell = current;
                }
            }

            var prev = end;

            while (prev.PreviousCell != null)
            {
                prev.IsPartSolution = true;
                prev = prev.PreviousCell;
            }
        }
    }
}
