namespace pentago.BitBoard
{
    public class Option
    {
        private long _mask; // win mask
        private int _index; // index of a subgrid 
        
        // Constructor
        public Option(long mask, int index)
        {
            _mask = mask;
            _index = index;
        }
        
        // Getters and Setters
        public long Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }
        
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
    }
}