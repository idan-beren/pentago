namespace pentago
{
    public static class Configurations
    {
        // The number of the subgrids
        public const int NumberOfSubgrids = 4;
        
        // The number of the circles
        public const int NumberOfCircles = 36;
        
        // THhe number of the arrows
        public const int NumberOfArrows = 8;

        // The positions of the subgrids
        public static readonly Position[] SubgridsPositions =
        {
            new Position(150, 200), new Position(400, 200), new Position(150, 449), new Position(400, 449)
        };
        
        // The positions of the circles
        public static readonly Position[] CirclesPositions =
        {
            new Position(175, 225), new Position(250, 225), new Position(325, 225),
            new Position(425, 225), new Position(500, 225), new Position(575, 225),
            new Position(175, 300), new Position(250, 300), new Position(325, 300),
            new Position(425, 300), new Position(500, 300), new Position(575, 300),
            new Position(175, 375), new Position(250, 375), new Position(325, 375),
            new Position(425, 375), new Position(500, 375), new Position(575, 375),
            new Position(175, 475), new Position(250, 475), new Position(325, 475),
            new Position(425, 475), new Position(500, 475), new Position(575, 475),
            new Position(175, 550), new Position(250, 550), new Position(325, 550),
            new Position(425, 550), new Position(500, 550), new Position(575, 550),
            new Position(175, 625), new Position(250, 625), new Position(325, 625),
            new Position(425, 625), new Position(500, 625), new Position(575, 625)
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
    }
}