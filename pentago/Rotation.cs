using pentago.Board;

namespace pentago
{
    public class Rotation
    {
        private bool _isClockwise;
        private int _subgridIndex;
        private int _subgridX, _subgridY;
        
        public Rotation(bool isClockwise, int subgridIndex)
        {
            _isClockwise = isClockwise;
            _subgridIndex = subgridIndex;
            _subgridX = subgridIndex / Subgrid.SubgridSize;
            _subgridY = subgridIndex % Subgrid.SubgridSize;
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
    }
}