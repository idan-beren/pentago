using pentago.Board;
using static pentago.Configurations;
using pentago.AI;

namespace pentago.Control
{
    public class Controller
    {
        private Grid _grid; // game
        private Computer _computer; // computer

        // Constructor
        public Controller()
        {
            _grid = new Grid();
            _computer = new Computer();
        }
        
        // Update the game about the player's move - insert value and rotate subgrid
        public GameStatus UpdateGame(int cell, int rotation)
        {
            Coordinates coordinates = CellCoordinates(cell);
            _grid.InsertValue(CellStatus.Player1, coordinates.SubgridX, coordinates.SubgridY, coordinates.CellX, coordinates.CellY);
            _grid.RotateSubgrid(RotationsToPositions[rotation].X, RotationsToPositions[rotation].Y, Rotations[rotation].IsClockwise);
            GameStatus status = _grid.CheckStatus();
            if (status == GameStatus.Nothing)
            {
                cell = _computer.RandomCell();
                rotation = _computer.RandomRotation();
                coordinates = CellCoordinates(cell);
                _grid.InsertValue(CellStatus.Player2, coordinates.SubgridX, coordinates.SubgridY, coordinates.CellX, coordinates.CellY);
                _grid.RotateSubgrid(RotationsToPositions[rotation].X, RotationsToPositions[rotation].Y, Rotations[rotation].IsClockwise);
                status = _grid.CheckStatus();
            } 
            return status;
        }

        // Calculate the coordinates of the cell
        public Coordinates CellCoordinates(int cell)
        {
            int subgridX, subgridY, cellX, cellY;
            Position position = CirclesToPositions[cell];
            subgridX = position.X / Subgrid.SubgridSize;
            subgridY = position.Y / Subgrid.SubgridSize;
            cellX = position.X % Subgrid.SubgridSize;
            cellY = position.Y % Subgrid.SubgridSize;
            Coordinates coordinates = new Coordinates(subgridX, subgridY, cellX, cellY);
            return coordinates;
        }
        
        // Getters and Setters
        public Grid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }
        
        public Computer Computer
        {
            get { return _computer; }
            set { _computer = value; }
        }
    }
}