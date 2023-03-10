using System;
using pentago.Board;
using static pentago.Configurations;

namespace pentago.Players
{
    public class Computer : Player
    { 
        public const CellStatus Value = CellStatus.Player2; // value of the computer => 2 = player 2
        private Random _random; // random
           
        public Computer()
        {
            _random = new Random();
        }
           
        private int RandomCell()
        {
            return _random.Next(0, Subgrid.SubgridSize * Subgrid.SubgridSize);
        }
        
        private int RandomRotation()
        {
            return _random.Next(0, Subgrid.SubgridSize * Subgrid.SubgridSize);
        }
    }
}