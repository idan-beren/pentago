using pentago.Board;
using static pentago.Configurations;

namespace pentago.Players
{
    public abstract class Player
    {
        protected int _currentCell; // current cell
        protected int _currentRotation; // current rotation
        
        // Calculate the coordinates of the cell
        public Coordinates CellCoordinates()
        {
            int subgridX, subgridY, cellX, cellY;
            subgridX = _currentCell / Subgrid.SubgridSize;
            subgridY = _currentCell % Subgrid.SubgridSize;
            cellX = _currentRotation / Subgrid.SubgridSize;
            cellY = _currentRotation % Subgrid.SubgridSize;
            Coordinates coordinates = new Coordinates(subgridX, subgridY, cellX, cellY);
            return coordinates;
        }
        
        // Calculate the rotation of the subgrid
        public Rotation Rotation()
        {
            return Rotations[_currentRotation];
        }

        // Getters and Setters
        public int CurrentCell
        {
            get { return _currentCell; }
            set { _currentCell = value; }
        }
        
        public int CurrentRotation
        {
            get { return _currentRotation; }
            set { _currentRotation = value; }
        }
    }
}