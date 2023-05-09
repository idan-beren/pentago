namespace pentago.Utilities
{
    // Size class
    public class Size
    {
        private int _width, _height; // width and height
        
        // Constructor
        public Size(int width, int height)
        {
            _width = width;
            _height = height;
        }
        
        // Getter and Setter for the width
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        
        // Getter and Setter for the height
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
    }
}