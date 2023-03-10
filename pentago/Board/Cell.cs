using static pentago.Configurations;
namespace pentago.Board
{
    public class Cell
    {
        private CellStatus _value; // value of the cell => 0 = empty, 1 = player 1, 2 = player 2

        // Constructor
        public Cell()
        {
            _value = CellStatus.Empty;
        }
        
        // Getters and Setters
        public CellStatus Value
        {
            get { return _value; }
            set { _value = value; }
        }
        
        // Check if the cell is empty
        public bool IsEmpty()
        {
            return _value == CellStatus.Empty;
        }
    }
}