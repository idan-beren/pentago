namespace pentago
{
    public class Rotation
    {
        private bool _isClockwise;
        private int _subgridIndex;

        public Rotation(bool isClockwise, int subgridIndex)
        {
            _isClockwise = isClockwise;
            _subgridIndex = subgridIndex;
        }
        
        public bool IsClockwise
        {
            get { return _isClockwise; }
            set { _isClockwise = value; }
        }
        
        public int SubgridIndex
        {
            get { return _subgridIndex; }
            set { _subgridIndex = value; }
        }
    }
}