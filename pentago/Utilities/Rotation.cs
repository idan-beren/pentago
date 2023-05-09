namespace pentago.Utilities
{
    // Size class
    public class Rotation
    {
        private bool _isClockwise; // isClockwise - true if the rotation is clockwise, false if the rotation is counterclockwise
        private int _subgridIndex; // subgridIndex - the index of the subgrid that is being rotated

        // Constructor
        public Rotation(bool isClockwise, int subgridIndex)
        {
            _isClockwise = isClockwise;
            _subgridIndex = subgridIndex;
        }
        
        // Getter and Setter for isClockwise
        public bool IsClockwise
        {
            get { return _isClockwise; }
            set { _isClockwise = value; }
        }
        
        // Getter and Setter for subgridIndex
        public int SubgridIndex
        {
            get { return _subgridIndex; }
            set { _subgridIndex = value; }
        }
    }
}