namespace pentago.Utilities
{
    // Move - a class that represents a move that will be played in the game
    public class Move
    {
        private int _cell; // cell - the cell that the computer will play
        private bool _rotation; // rotation - the rotation that the computer will play
        private int _subgrid; // subgrid - the subgrid that the computer will play
        
        // Constructor
        public Move(int cell, bool rotation, int subgrid)
        {
            _cell = cell;
            _rotation = rotation;
            _subgrid = subgrid;
        }
        
        // Empty constructor
        public Move()
        {
            _cell = 0;
            _rotation = true;
            _subgrid = 0;
        }
        
        // Getter and Setter for the cell
        public int Cell
        {
            get { return _cell; }
            set { _cell = value; }
        }
        
        // Getter and Setter for the rotation
        public bool Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
        
        // Getter and Setter for the subgrid
        public int Subgrid
        {
            get { return _subgrid; }
            set { _subgrid = value; }
        }
    }
}