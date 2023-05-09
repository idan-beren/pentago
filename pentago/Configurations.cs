using pentago.Utilities;

namespace pentago
{
    public static class Configurations
    {
        // The status of the cell (empty, player 1, player 2)
        public enum CellStatus
        {
            Empty,
            Player1,
            Player2
        }
        
        // The status of the game (player 1 wins, player 2 wins, draw, nothing)
        public enum GameStatus
        {
            Player1,
            Player2,
            Draw,
            Nothing
        }
        
        // The symmetry of the grid (horizontal, vertical)
        public enum Symmetry
        {
            None,
            Horizontal,
            Vertical
        }

        // The number of the subgrids
        public const int NumberOfSubgrids = 4;
        
        // The size of the subgrid
        public const int SubgridSize = 3;
        
        // The number of the cells
        public const int NumberOfCells = 36;
        
        // The number of the directions
        public const int NumberOfDirections = 2;

        // The number of the rotations
        public const int NumberOfRotations = 8;
        
        // The number of the bits that are needed to represent the status of the grid
        public const int NumberOfBits = 36;
        
        // Length of the subgrid
        public const int SubgridLength = 9;

        // The number of the arrows
        public const int NumberOfArrows = 8;
        
        // Number of row masks
        public const int NumberOfRowMasks = 12;
        
        // Number of column masks
        public const int NumberOfColumnMasks = 12;
        
        // Number of diagonal masks
        public const int NumberOfDiagonalMasks = 8;
        
        // Number of subgrid masks
        public const int NumberOfSubgridMasks = 4;
        
        // Number of symmetries
        public const int NumberOfSymmetries = 2;
        
        // Kind of masks (row, column, diagonal)
        public const int KindOfMasks = 3;
        
        // Bit
        public const long Bit = 1L;
        
        // First bit
        public const int FirstBit = 35;

        // Empty status
        public const long EmptyStatus = 0L;
        
        // Full status
        public const long FullStatus = 0b111111111111111111111111111111111111;
        
        // Horizontal shift
        public const int HorizontalShift = 18;
        
        // Vertical shift
        public const int VerticalShift = 3;
        
        // None
        public const int None = -1;
        
        // The positions of the subgrids
        public static readonly Position[] SubgridsPositions =
        {
            new Position(150, 200), new Position(400, 200), new Position(150, 449), new Position(400, 449)
        };
        
        // The positions of the circles in the first subgrid
        private static readonly Position[,] CirclesPositions1 =
        {
            { new Position(175, 225), new Position(250, 225), new Position(325, 225) },
            { new Position(175, 300), new Position(250, 300), new Position(325, 300) },
            { new Position(175, 375), new Position(250, 375), new Position(325, 375) }
        };
        
        // The positions of the circles in the second subgrid
        private static readonly Position[,] CirclesPositions2 =
        {
            { new Position(425, 225), new Position(500, 225), new Position(575, 225) },
            { new Position(425, 300), new Position(500, 300), new Position(575, 300) },
            { new Position(425, 375), new Position(500, 375), new Position(575, 375) }
        };
        
        // The positions of the circles in the third subgrid
        private static readonly Position[,] CirclesPositions3 =
        {
            { new Position(175, 475), new Position(250, 475), new Position(325, 475) },
            { new Position(175, 550), new Position(250, 550), new Position(325, 550) },
            { new Position(175, 625), new Position(250, 625), new Position(325, 625) }
        };
        
        // The positions of the circles in the fourth subgrid
        private static readonly Position[,] CirclesPositions4 =
        {
            { new Position(425, 475), new Position(500, 475), new Position(575, 475) },
            { new Position(425, 550), new Position(500, 550), new Position(575, 550) },
            { new Position(425, 625), new Position(500, 625), new Position(575, 625) }
        };
        
        // The positions of the circles
        public static readonly Position[][,] CirclesPositions =
        {
            CirclesPositions1, CirclesPositions2, CirclesPositions3, CirclesPositions4
        };
        
        // The positions of the arrows
        public static readonly Position[] ArrowsPositions =
        {
            new Position(150, 165), new Position(575, 165), new Position(660, 200), new Position(660, 625),
            new Position(575, 710), new Position(150, 710), new Position(115, 625), new Position(115, 200)
        };
        
        // The rotations of the arrows
        public static readonly int[] ArrowsRotations = { 0, 2, 1, 3, 2, 0, 3, 1 };
    
        // The sizes of the arrows
        public static readonly Size[] ArrowsSizes =
        {
            new Size(75, 25), new Size( 75, 25), new Size( 25, 75), 
            new Size( 25, 75), new Size(75, 25), new Size( 75, 25),
            new Size( 25, 75), new Size( 25, 75)
        };
        
        // The sizes of the subgrids
        public static readonly Size SubgridsSizes = new Size(250, 250);
        
        // The sizes of the circles
        public static readonly Size CirclesSizes = new Size(50, 50);
        
        // The sizes of the screen
        public static readonly Size ScreenSizes = new Size(800, 800);
        
        // Rotations details
        public static readonly Rotation[] Rotations =
        {
            new Rotation(true, 0), new Rotation(false, 1), new Rotation(true, 1), new Rotation(false, 3),
            new Rotation(true, 3), new Rotation(false, 2), new Rotation(true, 2), new Rotation(false, 0)
        };

        // Cell indexes 
        public static readonly int[] CellIndexes =
        {
            0, 1, 2, 6, 7, 8, 12, 13, 14, 3, 4, 5, 9, 10, 11, 15, 16, 17, 18, 
            19, 20, 24, 25, 26, 30, 31, 32, 21, 22, 23, 27, 28, 29, 33, 34, 35
        };
        
        // Logo size
        public static readonly Size LogoSize = new Size(800, 800);
        
        // Instructions size
        public static readonly Size InstructionsSize = new Size(800, 800);
        
        // Buttons size
        public static readonly Size ButtonsSize = new Size(150, 50);
        
        // Header size
        public static readonly Size HeaderSize = new Size(250, 100);
        
        // Header position
        public static readonly Position HeaderPosition = new Position(320, 50);
        
        // Restart button position
        public static readonly Position RestartButtonPosition = new Position(20, 20);
        
        // Instructions button position
        public static readonly Position InstructionsButtonPosition = new Position(500, 600);
        
        // Start button position
        public static readonly Position StartButtonPosition = new Position(150, 600);
        
        // Back button position
        public static readonly Position BackButtonPosition = new Position(600, 700);
    }
}