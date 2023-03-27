using pentago.BitBoard;
using System.Collections.Generic;

namespace pentago.Players
{
    public class Computer : Player
    {
        private static int _depth = 2; // depth of the tree
        private long _possibleMoves; // possible moves
        private int _counterOfRecursion; // counter of recursion    
        private bool _isOpening; // is opening
        private List<Option> _whiteOptions; // white options
        private List<Option> _blackOptions; // black options
        private List<Option> _streaksOfFour; // streaks of four

        // Constructor
        public Computer(long status, Grid grid) : base(status, grid)
        {
            InitializeStreaksOfFour();
            _streaksOfFour.Sort((o1, o2) => o2.Index.CompareTo(o1.Index));
            _blackOptions = InitializeOptions();
            _whiteOptions = InitializeOptions();
            _isOpening = true;
            _counterOfRecursion = 0;
        }

        // Initialize the streaks of four
        private void InitializeStreaksOfFour()
        {
            _streaksOfFour = new List<Option>
            {
                // First Streak:
                new Option(0x207L, 32), // Left
                new Option(0x606L, 30), // Middle
                new Option(0xE04L, 32), // Right

                // Second Streak:
                new Option(0x1038L, 34), // Left
                new Option(0x3030L, 38), // Middle
                new Option(0x7020L, 34), // Right

                // Third Streak:
                new Option(0x81C0L, 33), // Left
                new Option(0x18180L, 31), // Middle
                new Option(0x38100L, 33), // Right

                // Fourth Streak:
                new Option(0x81C0000L, 33), // Left
                new Option(0x18180000L, 31), // Middle
                new Option(0x381000000L, 33), // Right

                // Fifth Streak:
                new Option(0x60E00000L, 34), // Left
                new Option(0xC0C00000L, 38), // Middle
                new Option(0x1C0800000L, 34), // Right

                // Sixth Streak:
                new Option(0x207000000L, 32), // Left
                new Option(0x606000000L, 30), // Middle
                new Option(0xE04000000L, 32), // Right
            };
        }

        // Initialize the options
        private static List<Option> InitializeOptions()
        {
            List<Option> options = new List<Option>
            {
                // -------------------------------- Lines---------------------------------------------------------------
                new Option(0x607L, 3),
                new Option(0xE06L, 3),
                new Option(0x3038L, 3),
                new Option(0x7030L, 3),
                new Option(0x181C0L, 3),
                new Option(0x38180L, 3),
                new Option(0x181C0000L, 0),
                new Option(0x38180000L, 0),
                new Option(0xC0E00000L, 0),
                new Option(0x1C0C00000L, 0),
                new Option(0x607000000L, 1),
                new Option(0xE06000000L, 1),
                // -------------------------------- Columns-------------------------------------------------------------
                new Option(0x240049L, 1),
                new Option(0x1240048L, 1),
                new Option(0x480092L, 1),
                new Option(0x2480090L, 1),
                new Option(0x900124L, 1),
                new Option(0x4900120L, 1),
                new Option(0x48009200L, 2),
                new Option(0x248009000L, 2),
                new Option(0x90012400L, 2),
                new Option(0x490012000L, 2),
                new Option(0x120024800L, 0),
                new Option(0x920024000L, 0),
                // -------------------------------- Diagonals-----------------------------------------------------------
                // Secondary:
                new Option(0x110008022L, 2),
                new Option(0x440100088L, 1),
                new Option(0x281500L, 3),
                new Option(0xa814000L, 0),
                // Main:
                new Option(0x88000111L, 1),
                new Option(0x888000110L, 1),
                new Option(0x50A800L, 3),
                new Option(0x150A000L, 3)
            };
            return options;
        }

        // If there is a streak of four, return the option of the streak
        private Option NextMoveWin()
        {
            for (int i = 0; i < Grid.NumberOfOptions; i++)
            {
                if (NumberOfBitsOn(_possibleMoves & Grid.Options[i].Mask) == 1)
                {
                    return new Option((_possibleMoves & Grid.Options[i].Mask), Grid.Options[i].Index);
                }
            }

            return new Option(0L, 0);
        }

        // Number of bits on in the status
        private static int NumberOfBitsOn(long status)
        {
            long count = 0;
            while (status > 0)
            {
                count += status & 1;
                status >>= 1;
            }

            return (int)count;
        }

        // The evaluation function of the computer player
        private int Evaluation(Grid grid)
        {
            int rankW = 0;
            int rankB = 0;

            for (int i = 0; i < Grid.NumberOfOptions; i++)
            {
                rankW += Ranking(Grid.WhitePlayer.Status & Grid.Options[i].Mask);
                rankB += Ranking(Grid.BlackPlayer.Status & Grid.Options[i].Mask);
            }

            return rankB - rankW;
        }

        // Ranking the options according to the number of bits on in the status of the player and the option mask
        private static int Ranking(long status)
        {
            int rank = 0;
            int temp = NumberOfBitsOn(status);
            switch (temp)
            {
                case 5:
                    rank = 100000;
                    break;
                case 4:
                    rank += temp * 4;
                    break;
                case 3:
                    rank += temp * 3;
                    break;
            }

            return rank;
        }
    }
}