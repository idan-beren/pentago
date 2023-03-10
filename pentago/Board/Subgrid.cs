using static pentago.Configurations;
namespace pentago.Board
{
    public class Subgrid
    {
        public const int SubgridSize = 3; // size of the subgrid
        private Cell[,] _cells; // cells of the subgrid
        
        // Constructor
        public Subgrid()
        {
            _cells = new Cell[SubgridSize, SubgridSize];
            for (int i = 0; i < SubgridSize; i++)
                for (int j = 0; j < SubgridSize; j++)
                    _cells[i, j] = new Cell();
        }

        // Rotate the subgrid clockwise
        public void RotateClockwise()
        {
            Cell[,] temp = new Cell[SubgridSize, SubgridSize];
            for (int i = 0; i < SubgridSize; i++)
                for (int j = 0; j < SubgridSize; j++)
                    temp[i, j] = _cells[i, j];
            for (int i = 0; i < SubgridSize; i++)
                for (int j = 0; j < SubgridSize; j++)
                    _cells[i, j] = temp[SubgridSize - j - 1, i];
        }
        
        // Rotate the subgrid counter-clockwise
        public void RotateCounterClockwise()
        {
            Cell[,] temp = new Cell[SubgridSize, SubgridSize];
            for (int i = 0; i < SubgridSize; i++)
                for (int j = 0; j < SubgridSize; j++)
                    temp[i, j] = _cells[i, j];
            for (int i = 0; i < SubgridSize; i++)
                for (int j = 0; j < SubgridSize; j++)
                    _cells[i, j] = temp[j, SubgridSize - i - 1];
        }
        
        // Check if the subgrid is full
        public bool IsFull()
        {
            for (int i = 0; i < SubgridSize; i++)
                for (int j = 0; j < SubgridSize; j++)
                    if (_cells[i, j].Value == CellStatus.Empty)
                        return false;
            return true;
        }
        
        // Getters and Setters for the cells
        public Cell[,] Cells
        {
            get { return _cells; }
            set { _cells = value; }
        }
    }
}