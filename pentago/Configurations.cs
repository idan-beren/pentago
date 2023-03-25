namespace pentago
{
    public static class Configurations
    {
        // The number of the subgrids
        public const int NumberOfSubgrids = 4;
        
        // The size of the subgrid
        public const int SubgridSize = 3;
        
        // The number of the circles
        public const int NumberOfCircles = 36;
        
        // THhe number of the arrows
        public const int NumberOfArrows = 8;

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
        
        // Circles to Positions
        public static readonly Position[] CirclesToPositions =
        {
            new Position(0, 0), new Position(1, 0), new Position(2, 0), new Position(3, 0), 
            new Position(4, 0), new Position(5, 0), new Position(0, 1), new Position(1, 1),
            new Position(2, 1), new Position(3, 1), new Position(4, 1), new Position(5, 1),
            new Position(0, 2), new Position(1, 2), new Position(2, 2), new Position(3, 2),
            new Position(4, 2), new Position(5, 2), new Position(0, 3), new Position(1, 3),
            new Position(2, 3), new Position(3, 3), new Position(4, 3), new Position(5, 3),
            new Position(0, 4), new Position(1, 4), new Position(2, 4), new Position(3, 4),
            new Position(4, 4), new Position(5, 4), new Position(0, 5), new Position(1, 5),
            new Position(2, 5), new Position(3, 5), new Position(4, 5), new Position(5, 5)
        };
        
        // Cell indexes 
        public static readonly int[] CellIndexes =
        {
            0, 1, 2, 6, 7, 8, 12, 13, 14, 3, 4, 5, 9, 10, 11, 15, 16, 17, 18, 
            19, 20, 24, 25, 26, 30, 31, 32, 21, 22, 23, 27, 28, 29, 33, 34, 35
        };
        
        // Rotations to Positions
        public static readonly Position[] RotationsToPositions =
        {
            new Position(0, 0), new Position(1, 0), new Position(1, 0), new Position(1, 1),
            new Position(1, 1), new Position(0, 1), new Position(0, 1), new Position(0, 0)
        };
    }
}