namespace MazeSolver
{
    class Cell
    {
        public Cell(int x, int y, bool isWalkable)
        {
            X = x;
            Y = y;
            IsWalkable = isWalkable;
        }

        public bool IsWalkable { get; private set; }
        public bool IsFirstCell { get; set; }
        public bool IsChecked { get; set; }
        public bool IsPartSolution { get; set; }
        public bool IsFinal { get; set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        public Cell PreviousCell { get; set; }

        public override string ToString()
        {
            if (IsFinal)
                return " X ";
            else if (IsPartSolution)
                return " · ";
            else if (IsFirstCell)
                return " o ";
            else if (IsWalkable)
                return "   ";
            else
                return "###";
        }

        public bool Equals(Cell cell)
        {
            if (this.X == cell.X && this.Y == cell.Y)
                return true;
            else
                return false;
        }
    }
}
