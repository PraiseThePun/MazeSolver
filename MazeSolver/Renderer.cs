namespace MazeSolver
{
    class Renderer
    {
        private Maze maze;

        public Renderer(Maze maze)
        {
            this.maze = maze;
        }

        public string Paint()
        {
            const string LETTERS = "\tA  B  C  D  E  F  G  H";
            const string BLOCK = "###";

            var border = "  | " + new string('#', 30);
            var line = "  +" + new string('-', 30);

            var strMaze = LETTERS + "\n" + line + "\n" + border + "\n";

            for (int i = 0; i < maze.Cells.GetLength(0); i++)
            {
                strMaze += " " + (i + 1) + "| " + BLOCK;

                for (int j = 0; j < maze.Cells.GetLength(1); j++)
                {
                    strMaze += maze.Cells[i, j].ToString();
                }

                strMaze += BLOCK + "\n";
            }
            
            return strMaze + border;
        }
    }
}
