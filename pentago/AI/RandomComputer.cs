using System;
using pentago.BitBoard;

namespace pentago.AI
{
    public class RandomComputer
    {
        private static Random _random; // random
        private int _cell; // cell - the cell that the computer will play
        private int _rotation; // rotation - the rotation that the computer will play
        private readonly Grid _grid; // grid - the grid of the game
        
        // Constructor
        public RandomComputer(Grid grid)
        {
            _grid = grid;
            _random = new Random();
            _cell = -1;
        }
           
        public int RandomCell()
        {
            _cell = _random.Next(0, 36);
            long bitBoard = _grid.BitBoard;
            while ((bitBoard & (1L << 35 - _cell)) != 0)
                _cell = _random.Next(0, 36);
            return _cell;
        }
        
        public int RandomRotation()
        {
            _rotation =  _random.Next(0, 8);
            return _rotation;
        }
        
        // Getter for the cell
        public int Cell
        {
            get { return _cell; }
        }
        
        // Getter for the rotation
        public int Rotation
        {
            get { return _rotation; }
        }
    }
}