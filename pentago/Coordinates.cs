namespace pentago
{
    public class Coordinates
    {
        private int _subgridX, _subgridY, _cellX, _cellY; // coordinates of the cell
        
        // Constructor1.0 - 4 parameters (uses for the cell coordinates)
        public Coordinates(int subgridX, int subgridY, int cellX, int cellY)
        {
            _subgridX = subgridX;
            _subgridY = subgridY;
            _cellX = cellX;
            _cellY = cellY;
        }
        
        // Constructor2.0 - 2 parameters (uses for the subgrid coordinates)
        public Coordinates(int subgridX, int subgridY)
        {
            _subgridX = subgridX;
            _subgridY = subgridY;
        }
        
        // Getters and Setters
        public int SubgridX
        {
            get { return _subgridX; }
            set { _subgridX = value; }
        }
        
        public int SubgridY
        {
            get { return _subgridY; }
            set { _subgridY = value; }
        }
        
        public int CellX
        {
            get { return _cellX; }
            set { _cellX = value; }
        }
        
        public int CellY
        {
            get { return _cellY; }
            set { _cellY = value; }
        }
    }
}