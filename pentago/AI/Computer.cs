using System;

namespace pentago.AI
{
    public class Computer
    {
        private static Random _random; // random
        private int _cell; // cell
        private int _rotation; // rotation
        
        public Computer()
        {
            _random = new Random();
            _cell = -1;
        }
           
        public int RandomCell()
        {
            //_cell = _random.Next(0, 36);
            ++_cell;
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