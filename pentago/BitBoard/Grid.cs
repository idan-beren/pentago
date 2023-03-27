using System.Collections.Generic;
using static pentago.Configurations;
using pentago.Players;

namespace pentago.BitBoard
{
    public class Grid
    {
        private static int _numberOfOptions = 32; // options to win
        private static List<Option> _options; // list of options to win
        private static long[] _masks; // masks
        private static BidirectionalMap<int, (int, int)> _bitMap; // map of bits
        private static Player _whitePlayer; // white player
        private static Computer _blackPlayer; // black player
        private bool _isRunning; // is the game running?
        
        // Constructor
        public Grid()
        {
            InitializeOptions();
            InitializeMasks();
            InitializeBitsMap();
            InitializePlayers();
            _isRunning = true;
        }
        
        // Initialize the options
        private static void InitializeOptions()
        {
            _options = new List<Option>
            {
                // -------------------------------- Lines---------------------------------------------------------------
                new Option(0x607L, 3),
                new Option(0xE06L, 3),
                new Option(0x3038L,3),
                new Option(0x7030L,3),
                new Option(0x181C0L,3),
                new Option(0x38180L,3),
                new Option(0x181C0000L,0),
                new Option(0x38180000L,0),
                new Option(0xC0E00000L,0),
                new Option(0x1C0C00000L,0),
                new Option(0x607000000L,1),
                new Option(0xE06000000L,1),
                // -------------------------------- Columns-------------------------------------------------------------
                new Option(0x240049L,1),
                new Option(0x1240048L,1),
                new Option(0x480092L,1),
                new Option(0x2480090L,1),
                new Option(0x900124L,1),
                new Option(0x4900120L,1),
                new Option(0x48009200L,2),
                new Option(0x248009000L,2),
                new Option(0x90012400L,2),
                new Option(0x490012000L,2),
                new Option(0x120024800L,0),
                new Option(0x920024000L,0),
                // -------------------------------- Diagonals-----------------------------------------------------------
                // Secondary:
                new Option(0x110008022L,2),
                new Option(0x440100088L,1),
                new Option(0x281500L,3),
                new Option(0xa814000L,0),
                // Main:
                new Option(0x88000111L,1),
                new Option(0x888000110L,1),
                new Option(0x50A800L,3),
                new Option(0x150A000L,3)
            };
        }
        
        // Initialize the masks
        private static void InitializeMasks()
        {
            _masks = new long[NumberOfSubgrids];
            _masks[0] = 0x01FFL;
            _masks[1] = 0x0003FE00L;
            _masks[2] = 0x07FC0000L;
            _masks[3] = 0x000FF8000000L;
        }
        
        // Initialize the bits map
        private static void InitializeBitsMap()
        {
            _bitMap = new BidirectionalMap<int, (int, int)>();
            for (int i = 0; i < 9; i++)
                _bitMap.Add(i, (i / 3, i % 3));
        }
        
        // Initialize the players
        public void InitializePlayers()
        {
            _whitePlayer = new Player(0L, this);
            _blackPlayer = new Computer(0L, this);
        }
        
        // Rotate a subgrid clockwise
        public void RotateSubgridClockwise(int index)
        {   
            long oldStateB = _masks[index] & _blackPlayer.Status;
            long oldStateW = _masks[index] & _whitePlayer.Status;
            oldStateB >>= (index * 9);
            oldStateW >>= (index * 9);
            long newStateB = 0, newStateW = 0;
            for (int i = 0; i < 9; i++) 
            {
                long bitMaskB = oldStateB & (1L << i);
                long bitMaskW = oldStateW & (1L << i);
                int x = (i + 2 * (i + 1) - i / 3) % 9;
                newStateB |= bitMaskB >> i << x;
                newStateW |= bitMaskW >> i << x;
            }
            newStateB <<= index * 9;
            newStateW <<= index * 9;
            _blackPlayer.Status &= ~_masks[index];
            _blackPlayer.Status |= newStateB;
            _whitePlayer.Status = newStateW | (_whitePlayer.Status & ~_masks[index]);
        }
        
        // Rotate a subgrid counter-clockwise
        public void RotateSubgridCounterClockwise(int index)
        {
            long oldStateB = _masks[index] & _blackPlayer.Status;
            long oldStateW = _masks[index] & _whitePlayer.Status;
            oldStateB >>= (index * 9);
            oldStateW >>= (index * 9);
            long newStateB = 0, newStateW = 0;
            for (int i = 0; i < 9; i++) {
                long bitMaskB = (oldStateB >> i) & 1;
                long bitMaskW = (oldStateW >> i) & 1;
                int x = ((i * 2) + 1 + (i / 3)) % 9;
                newStateB |= bitMaskB << x;
                newStateW |= bitMaskW << x;
            }
            newStateB <<= index * 9;
            newStateW <<= index * 9;
            _blackPlayer.Status &= ~_masks[index];
            _blackPlayer.Status |= newStateB;
            _whitePlayer.Status = (_whitePlayer.Status & ~_masks[index]) | newStateW;
        }
        
        // Getters and setter for the players
        public static Player WhitePlayer
        {
            get { return _whitePlayer; }
            set { _whitePlayer = value; }
        }
        
        public static Computer BlackPlayer
        {
            get { return _blackPlayer; }
            set { _blackPlayer = value; }
        }
        
        // Getter for thr number of options
        public static int NumberOfOptions
        {
            get { return _options.Count; }
        }
        
        // Getter and Setter for the options
        public static List<Option> Options
        {
            get { return _options; }
            set { _options = value; }
        }
    }
}