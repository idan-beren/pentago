namespace pentago.Utilities
{
    // Position class
    public class Position
    {
        private int _x, _y; // x and y coordinates
        
        // Constructor
        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }
        
        // Getter and Setter for x
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        
        // Getter and Setter for y
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}