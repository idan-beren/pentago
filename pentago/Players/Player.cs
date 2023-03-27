using pentago.BitBoard;

namespace pentago.Players
{
    public class Player
    {
        private long _status; // status of the player

        // Constructor
        public Player(long status, Grid grid)
        {
            _status = status;
        }
        
        // Get the possible moves
        public long GetPossibleMoves()
        {
            return ~(Grid.BlackPlayer.Status | Grid.WhitePlayer.Status);
        }
        
        // Getter and Setter for the status
        public long Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}