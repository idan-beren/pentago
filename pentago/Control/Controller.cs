using pentago.BitBoard;
using static pentago.Configurations;
using pentago.AI;

namespace pentago.Control
{
    // The controller of the game - it is the bridge between the View and the Model
    public class Controller
    {
        private Grid _grid; // game
        private Computer _computer; // computer

        // Constructor
        public Controller()
        {
            _grid = new Grid();
            _computer = new Computer(_grid);
        }
        
        /// <summary>
        /// Update the grid about the user's cell decision and check the game status
        /// </summary>
        /// <param name="cell"> the cell that the user wants to place </param>
        /// <returns> the status of the game </returns>
        public GameStatus UserCellMove(int cell)
        {
            _grid.UpdateStatus(CellStatus.Player1, cell);
            GameStatus status = _grid.CheckGameStatus();
            return status;
        }
        
        /// <summary>
        /// Update the grid about the user's rotation decision and check the game status
        /// </summary>
        /// <param name="rotation"> the rotation that the user wants to perform </param>
        /// <returns> the status of the game </returns>
        public GameStatus UserRotationMove(int rotation)
        {
            _grid.RotateSubgrid(Rotations[rotation].SubgridIndex, Rotations[rotation].IsClockwise);
            GameStatus status = _grid.CheckGameStatus();
            return status;
        }
        
        // Calculate the computer's move 
        public void ComputerMove()
        {
            _computer.CalculateMove();
        }
        
        /// <summary>
        /// Update the grid about the computer's cell decision and check the game status
        /// </summary>
        /// <returns> the status of the game </returns>
        public GameStatus ComputerCellMove()
        {
            int cell = _computer.Cell;
            _grid.UpdateStatus(CellStatus.Player2, cell);
            GameStatus status = _grid.CheckGameStatus();
            return status;
        }
        
        /// <summary>
        /// Update the grid about the computer's rotation decision and check the game status
        /// </summary>
        /// <returns> the status of the game </returns>
        public GameStatus ComputerRotationMove()
        {
            int rotation = _computer.Rotation;
            _grid.RotateSubgrid(Rotations[rotation].SubgridIndex, Rotations[rotation].IsClockwise);
            GameStatus status = _grid.CheckGameStatus();
            return status;
        }
        
        // Reset the game
        public void ResetGame()
        {
            _grid = new Grid();
            _computer = new Computer(_grid);
        }

        // Getters and Setters for the computer
        public Computer Computer
        {
            get { return _computer; }
            set { _computer = value; }
        }
    }
}
