using static pentago.Configurations;

namespace pentago.BitBoard
{
    // The grid of the game. The grid is represented by a bitboard.
    public class Grid
    {
        private long _status1; // status of the first player
        private long _status2; // status of the second player
        private long _bitBoard; // bitboard = status1 | status2
        private static long[] _rowsMasks; // rows masks - options to win in a row
        private static long[] _columnsMasks; // columns masks - options to win in a column
        private static long[] _diagonalsMasks; // diagonals masks - options to win in a diagonal
        private static long[][] _masks; // masks - options to win
        private static long[] _subgridsMasks; // subgrids masks
        public static MasksIterator MasksIterator; // masks iterator
        public static SubgridsIterator SubgridsIterator; // subgrids masks iterator
        private static readonly byte[] Indices1 = { 2, 5, 8, 1, 4, 7, 0, 3, 6 }; // the correlation between the cell indexes to rotate clockwise
        private static readonly byte[] Indices2 = { 6, 3, 0, 7, 4, 1, 8, 5, 2 }; // the correlation between the cell indexes to rotate counterclockwise
        
        // Constructor
        public Grid()
        {
            _status1 = EmptyStatus;
            _status2 = EmptyStatus;
            _bitBoard = EmptyStatus;
            _rowsMasks = new long[NumberOfRowMasks];
            _columnsMasks = new long[NumberOfColumnMasks];
            _diagonalsMasks = new long[NumberOfDiagonalMasks];
            _masks = new long[KindOfMasks][];
            _subgridsMasks = new long[NumberOfSubgridMasks];
            InitializeMasks();
            MasksIterator = new MasksIterator();
            SubgridsIterator = new SubgridsIterator();
        }
        
        // Turns on the bit of the cell in the player's status and updates the bitboard
        public void UpdateStatus(CellStatus player, int cellNumber)
        {
            switch (player)
            {
                case CellStatus.Player1:
                    _status1 |= Bit << FirstBit - cellNumber;
                    break;
                case CellStatus.Player2:
                    _status2 |= Bit << FirstBit - cellNumber;
                    break;
            }

            _bitBoard = _status1 | _status2;
        }
        
        // Turns off the bit of the cell in the player's status and updates the bitboard
        public void RemoveStatus(CellStatus player, int cellNumber)
        {
            switch (player)
            {
                case CellStatus.Player1:
                    _status1 &= ~(Bit << FirstBit - cellNumber);
                    break;
                case CellStatus.Player2:
                    _status2 &= ~(Bit << FirstBit - cellNumber);
                    break;
            }

            _bitBoard = _status1 | _status2;
        } 
        
        // Checks if the cell is empty and returns true if it is empty and false otherwise
        public bool IsEmptyCell(int cellNumber)
        {
            return (_bitBoard & (Bit << FirstBit - cellNumber)) == 0;
        }
        
        /// <summary>
        /// Extracts the subgrid from the status using bitwise operations
        /// </summary>
        /// <param name="status"> the status of the player </param>
        /// <param name="subgridNumber"> the number of the subgrid to extract </param>
        /// <returns> the extracted subgrid </returns>
        private static long ExtractSubgrid(long status, int subgridNumber)
        {
            // Shift the status to the right
            status <<= 28;
            if (subgridNumber == 2 || subgridNumber == 3) status <<= 18;
            if (subgridNumber == 1 || subgridNumber == 3) status <<= 3;
                
            // Extract the subgrid using bitwise operations
            long first = status >> 61 & 0b111;
            status <<= 6;
            long second = status >> 61 & 0b111;
            status <<= 6;
            long third = status >> 61 & 0b111;
            long subgrid = first << 6 | second << 3 | third;
            
            return subgrid;
        }
        
        /// <summary>
        /// Inserts the new rotated subgrid into the status using bitwise operations
        /// </summary>
        /// <param name="status"> the status of the player </param>
        /// <param name="subgrid"> the new rotated subgrid </param>
        /// <param name="subgridNumber"> the number of the subgrid to insert </param>
        /// <returns> the new status after inserting the rotated subgrid </returns>
        private static long InsertSubgrid(long status, long subgrid, int subgridNumber)
        {
            // Unpack the subgrid
            long first = subgrid & 0b111;
            long second = subgrid & 0b111000;
            long third = subgrid & 0b111000000;
            long newSubgrid = first | second << 3 | third << 6;
            
            // Shift the status to the right
            if (subgridNumber == 0 || subgridNumber == 1) newSubgrid <<= 18;
            if (subgridNumber == 0 || subgridNumber == 2) newSubgrid <<= 3;
            
            // Insert the subgrid using bitwise operations
            long newStatus= status & ~(_subgridsMasks[subgridNumber]);
            newStatus |= newSubgrid;
            
            return newStatus;
        }

        /// <summary>
        /// Rotates the subgrid clockwise or counterclockwise. the subgrid being extracted from the status,
        /// rotated and inserted back into the status
        /// </summary>
        /// <param name="status"> status of the player  </param>
        /// <param name="subgridNumber"> the number of the subgrid to rotate </param>
        /// <param name="indices"> helps to manege the rotation </param>
        /// <returns> the new rotated status </returns>
        private static long Rotate(long status, int subgridNumber, byte[] indices)
        {
            long subgrid = ExtractSubgrid(status, subgridNumber);
            
            // Extract the bits of the subgrid
            byte[] bitArray = new byte[SubgridLength];
            for (int i = 0; i < SubgridLength; i++)
            {
                // Extract from left to right
                int mask = (int)Bit << SubgridLength - 1 - i;
                bitArray[i] = (byte)((subgrid & mask) >> SubgridLength - 1 - i);
            }
            
            // Perform bitwise rotation on each bit
            byte[] rotatedBitArray = new byte[SubgridLength];
            for (int i = 0; i < SubgridLength; i++)
                rotatedBitArray[indices[i]] = bitArray[i];
            
            // Combine the rotated bits into a new matrix
            long rotatedSubgrid = 0L;
            for (int i = 0; i < SubgridLength; i++)
            {
                rotatedSubgrid <<= 1;
                rotatedSubgrid |= rotatedBitArray[i];
            }
            
            long newStatus = InsertSubgrid(status, rotatedSubgrid, subgridNumber);
            return newStatus;
        }

        // Rotate a subgrid clockwise or counterclockwise and update the bitboard
        public void RotateSubgrid(int subgridNumber, bool isClockwise)
        {
            switch (isClockwise)
            {
                case true: // clockwise
                    _status1 = Rotate(_status1, subgridNumber, Indices1);
                    _status2 = Rotate(_status2, subgridNumber, Indices1);
                    break;
                case false: // counter-clockwise
                    _status1 = Rotate(_status1, subgridNumber, Indices2);
                    _status2 = Rotate(_status2, subgridNumber, Indices2);
                    break;
            }

            _bitBoard = _status1 | _status2;
        }
        
        // Initialize the masks
        private static void InitializeMasks()
        {
            InitializeRowsMasks();
            InitializeColumnsMasks();
            InitializeDiagonalsMasks();
            InitializeSubgridsMasks();
            _masks[0] = _rowsMasks;
            _masks[1] = _columnsMasks;
            _masks[2] = _diagonalsMasks;
        }
        
        // Initialize the subgrids masks
        private static void InitializeSubgridsMasks()
        {
            _subgridsMasks[0] = 0b111000111000111000000000000000000000;
            _subgridsMasks[1] = 0b000111000111000111000000000000000000;
            _subgridsMasks[2] = 0b000000000000000000111000111000111000;
            _subgridsMasks[3] = 0b000000000000000000000111000111000111;
        }

        // Initialize the row masks
        private static void InitializeRowsMasks()
        {
            _rowsMasks[0] = 0b111110000000000000000000000000000000;
            _rowsMasks[1] = 0b011111000000000000000000000000000000;
            _rowsMasks[2] = 0b000000111110000000000000000000000000;
            _rowsMasks[3] = 0b000000011111000000000000000000000000;
            _rowsMasks[4] = 0b000000000000111110000000000000000000;
            _rowsMasks[5] = 0b000000000000011111000000000000000000;
            _rowsMasks[6] = 0b000000000000000000111110000000000000;
            _rowsMasks[7] = 0b000000000000000000011111000000000000;
            _rowsMasks[8] = 0b000000000000000000000000111110000000;
            _rowsMasks[9] = 0b000000000000000000000000011111000000;
            _rowsMasks[10] = 0b000000000000000000000000000000111110;
            _rowsMasks[11] = 0b000000000000000000000000000000011111;
        }
        
        // Initialize the column masks
        private static void InitializeColumnsMasks()
        {
            _columnsMasks[0] = 0b100000100000100000100000100000000000;
            _columnsMasks[1] = 0b000000100000100000100000100000100000;
            _columnsMasks[2] = 0b010000010000010000010000010000000000;
            _columnsMasks[3] = 0b000000010000010000010000010000010000;
            _columnsMasks[4] = 0b001000001000001000001000001000000000;
            _columnsMasks[5] = 0b000000001000001000001000001000001000;
            _columnsMasks[6] = 0b000100000100000100000100000100000000;
            _columnsMasks[7] = 0b000000000100000100000100000100000100;
            _columnsMasks[8] = 0b000010000010000010000010000010000000;
            _columnsMasks[9] = 0b000000000010000010000010000010000010;
            _columnsMasks[10] = 0b000001000001000001000001000001000000;
            _columnsMasks[11] = 0b000000000001000001000001000001000001;
        }
        
        // Initialize the diagonal masks
        private static void InitializeDiagonalsMasks()
        {
            _diagonalsMasks[0] = 0b100000010000001000000100000010000000;
            _diagonalsMasks[1] = 0b000000010000001000000100000010000001;
            _diagonalsMasks[2] = 0b010000001000000100000010000001000000;
            _diagonalsMasks[3] = 0b000000100000010000001000000100000010;
            _diagonalsMasks[4] = 0b000001000010000100001000010000000000;
            _diagonalsMasks[5] = 0b000000000010000100001000010000100000;
            _diagonalsMasks[6] = 0b000010000100001000010000100000000000;
            _diagonalsMasks[7] = 0b000000000001000010000100001000010000;
        }
        
        // Check if a player won by iterating over the winning masks, return true if he won and false otherwise
        public static bool CheckWin(long status)
        {
            foreach (long mask in MasksIterator)
                if ((status & mask) == mask) return true;
            return false;
        }

        // Check if the grid is full, return true if it is and false otherwise
        private bool IsFull()
        {
            return _bitBoard == FullStatus;
        }

        // Check the state of the game: player1 won, player2 won, draw or nothing and return the corresponding GameStatus
        public GameStatus CheckGameStatus()
        {
            bool player1 = CheckWin(_status1);  
            bool player2 = CheckWin(_status2);
            
            // Check if both players won
            if (player1 && player2) return GameStatus.Draw;
                
            // Check if player1 won
            if (player1) return GameStatus.Player1;
            
            // Check if player2 won
            if (player2) return GameStatus.Player2;
            
            // Check if the grid is full
            if (IsFull()) return GameStatus.Draw;
            
            // Nothing happened
            return GameStatus.Nothing;
        }

        // Getter and setter for the bitboard
        public long BitBoard
        {
            get { return _bitBoard; }
            set { _bitBoard = value; }
        }
        
        // Getter and Setter for the status of player 1
        public long Status1
        {
            get { return _status1; }
            set { _status1 = value; }
        }
        
        // Getter and Setter for the status of player 2
        public long Status2
        {
            get { return _status2; }
            set { _status2 = value; }
        }
        
        // Getter and Setter for the masks
        public static long[][] Masks
        {
            get { return _masks; }
            set { _masks = value; }
        }
        
        // Getter and Setter for the subgrids masks
        public static long[] SubGridsMasks
        {
            get { return _subgridsMasks; }
            set { _subgridsMasks = value; }
        }
    }
}