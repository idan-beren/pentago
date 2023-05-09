using System.Collections.Generic;
using pentago.Utilities;
using static pentago.Configurations;

namespace pentago.AI
{
    // List of all the possible moves that the computer can play
    public class PossibleMoves
    {
        private readonly List<Move> _moves; // moves - the list of moves that the computer will play
        
        // Constructor
        public PossibleMoves()
        {
            _moves = new List<Move>();
            GenerateMoves();
        }
        
        // Generate all the possible moves that the computer can play in the game
        private void GenerateMoves()
        {
            for (int cellNumber = 0; cellNumber < NumberOfCells; cellNumber++)
                for (int rotationNumber = 0; rotationNumber < NumberOfDirections; rotationNumber++)
                    for (int subgridNumber = 0; subgridNumber < NumberOfSubgrids; subgridNumber++)
                        _moves.Add(new Move(cellNumber, rotationNumber == 0, subgridNumber));
        }
        
        // Getter for the list of moves
        public List<Move> Moves
        {
            get { return _moves; }
        }
    }
}