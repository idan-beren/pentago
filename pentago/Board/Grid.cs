using static pentago.Configurations;
namespace pentago.Board
{
    public class Grid
    {
        private const int GridSize = 2; // size of the grid
        private Subgrid[,] _subgrids; // subgrids of the grid
        
        // Constructor
        public Grid()
        {
            _subgrids = new Subgrid[GridSize, GridSize];
            for (int i = 0; i < GridSize; i++)
                for (int j = 0; j < GridSize; j++)
                    _subgrids[i, j] = new Subgrid();
        }

        // Check if the grid is full
        private bool IsFull()
        {
            for (int i = 0; i < GridSize; i++)
                for (int j = 0; j < GridSize; j++)
                    if (!_subgrids[i, j].IsFull())
                        return false;
            return true;
        }

        // Insert a value in a cell
        public bool InsertValue(CellStatus value, int subgridX, int subgridY, int cellX, int cellY)
        {
            if (_subgrids[subgridX, subgridY].Cells[cellX, cellY].IsEmpty())
            {
                _subgrids[subgridX, subgridY].Cells[cellX, cellY].Value = value;
                return true;
            }
            return false;
        }

        // Rotate a subgrid
        public void RotateSubgrid(int subgridX, int subgridY, bool clockwise)
        {
            if (clockwise)
                _subgrids[subgridX, subgridY].RotateClockwise();
            else
                _subgrids[subgridX, subgridY].RotateCounterClockwise();
        }
        
        // Checks if a player won in a row
        private bool CheckRows(CellStatus player)
        {
            for (int i = 0; i < GridSize * Subgrid.SubgridSize; i++)
            {
                int streak = 0;
                for (int j = 0; j < GridSize * Subgrid.SubgridSize; j++)
                {
                    if (ExtractCell(i, j).Value == player)
                        streak++;
                    else
                        streak = 0;
                    if (streak == 5)
                        return true;
                }
            }
            
            return false;
        }
        
        // Checks if a player won in a column
        private bool CheckColumns(CellStatus player)
        {
            for (int i = 0; i < GridSize * Subgrid.SubgridSize; i++)
            {
                int streak = 0;
                for (int j = 0; j < GridSize * Subgrid.SubgridSize; j++)
                {
                    if (ExtractCell(j, i).Value == player)
                        streak++;
                    else
                        streak = 0;
                    if (streak == 5)
                        return true;
                }
            }
            
            return false;
        }
        
        // Checks if a player won in a diagonal
        private bool CheckDiagonals(CellStatus player)
        {
            // Check diagonals from top left to bottom right
            for (int i = 0; i < GridSize * Subgrid.SubgridSize; i++)
            {
                int streak = 0;
                for (int j = 0; j < GridSize * Subgrid.SubgridSize - i; j++)
                {
                    if (ExtractCell(j, j + i).Value == player)
                        streak++;
                    else
                        streak = 0;
                    if (streak == 5)
                        return true;
                }
            }
            
            // Check diagonals from top right to bottom left
            for (int i = 0; i < GridSize * Subgrid.SubgridSize; i++)
            {
                int streak = 0;
                for (int j = 0; j < GridSize * Subgrid.SubgridSize - i; j++)
                {
                    if (ExtractCell(j + i, j).Value == player)
                        streak++;
                    else
                        streak = 0;
                    if (streak == 5)
                        return true;
                }
            }
            
            return false;
        }
        
        // Check if a player won
        private bool CheckWin(CellStatus player)
        {
            // Check rows
            if (CheckRows(player)) return true;
            
            // Check columns
            if (CheckColumns(player)) return true;
            
            // Check diagonals
            if (CheckDiagonals(player)) return true;
            
            // No win
            return false;
        }
        
        // Extract the cell at the given coordinates
        private Cell ExtractCell(int x, int y)
        {
            return _subgrids[x / Subgrid.SubgridSize, y / Subgrid.SubgridSize].Cells[x % Subgrid.SubgridSize, y % Subgrid.SubgridSize];
        }

        // Check win, draw, nothing or continue => 1 = player 1 won, 2 = player 2 won, 3 = draw, 0 = nothing
        public GameStatus CheckStatus()
        {
            bool player1 = CheckWin(CellStatus.Player1);  
            bool player2 = CheckWin(CellStatus.Player2);
            
            // Check if both players won
            if (player1 && player2) return GameStatus.Draw;
                
            // Check if player1 won
            if (player1) return GameStatus.Player1;
            
            // Check if player2 won
            if (player2) return GameStatus.Player2;
            
            // Check if the grid is full
            if (IsFull()) return GameStatus.Draw;
            
            // Nothing happened
            return GameStatus.Nothing;
        }
        
        // Getters and Setters for the subgrids
        public Subgrid[,] Subgrids
        {
            get { return _subgrids; }
            set { _subgrids = value; }
        }
    }
}