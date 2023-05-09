using System;
using pentago.BitBoard;
using static pentago.Configurations;
using pentago.Utilities;

namespace pentago.AI
{
    // The AI of the game - calculates the best move that the computer can play in the game
    public class Computer
    {
        private static Random _random; // random
        private int _cell; // cell - the cell that the computer will play
        private int _rotation; // rotation - the rotation that the computer will play
        private readonly Grid _grid; // grid - the grid of the game
        private const long Middles = 0b000000010010000000000000010010000000; // middles - the middle cells of the grid
        private const int MaxValue = 1000000; // max value
        private const int MinValue = -1000000; // min value
        private bool _isOpening; // isOpening - true if the computer is playing the opening move
        private readonly PossibleMoves _possibleMoves; // possibleMoves - the list of possible moves
        private Move _bestMove; // bestMove - the best move that the computer will play

        // Constructor
        public Computer(Grid grid)
        {
            _grid = grid;
            _random = new Random();
            _isOpening = true;
            _possibleMoves = new PossibleMoves();
        }
        
        // Opening move - the computer plays the center cells
        private void Opening()
        {
            long bitBoard = _grid.BitBoard;
            if ((bitBoard & Middles) == Middles) _isOpening = false;
            if (!_isOpening) return;
            
            long options = (bitBoard & Middles) ^ Middles;
            for (int i = 0; i < NumberOfBits; i++)
            {
                long mask = Bit << FirstBit - i;
                if ((options & mask) != 0)
                {
                    _cell = i;
                    _rotation = _random.Next(0, NumberOfRotations);
                    return;
                }
            }
        }
        
        /// <summary>
        /// Evaluate the state of the grid by important factors. the factors are: the number of the bits in a streak
        /// (streak of cells of the same player without opponent's cells in between), amount of cells of the player that
        /// placed in an optional win, and the opponent's cells are not in between.
        /// the function passes the factors to the score function that calculates the score of the state
        /// </summary>
        /// <returns> the score of the state of the grid </returns>
        private int Evaluate()
        {
            int userScore = 0;
            int computerScore = 0;

            // Iterate over the masks and score the bits in winning states and bits in streaks
            foreach (long mask in Grid.MasksIterator)
            { 
                // Number of player's cells in a win option without opponent's cells in between
                int bitsInWinningState = Factors.CountBitsInWinningState(_grid.Status1, _grid.Status2, mask);
                // Length of the streak of the player's cells without opponent's cells in between
                int bitsInStreak = Factors.CountBitsInStreak(_grid.Status1, mask);
                // Score the bit counter and the streak
                userScore += ScoreMarbles(bitsInWinningState, bitsInStreak);

                // Number of player's cells in a win option without opponent's cells in between
                bitsInWinningState = Factors.CountBitsInWinningState(_grid.Status2, _grid.Status1, mask);
                // Length of the streak of the player's cells without opponent's cells in between
                bitsInStreak = Factors.CountBitsInStreak(_grid.Status2, mask);
                // Score the bit counter and the streak
                computerScore += ScoreMarbles(bitsInWinningState, bitsInStreak);
            }
            
            // Score the symmetries
            userScore += Factors.CountBitsInSymmetries(_grid.Status1);
            computerScore += Factors.CountBitsInSymmetries(_grid.Status2);
            
            // Score the centers and the corners
            userScore += Factors.ControlCentersAndCorners(_grid.Status1);
            computerScore += Factors.ControlCentersAndCorners(_grid.Status2);
            
            // Score the subgrids
            userScore += Factors.ControlSubgrids(_grid.Status1);
            computerScore += Factors.ControlSubgrids(_grid.Status2);

            return computerScore - userScore;
        }
        
        /// <summary>
        /// According to the passed factors, calculate the score of the state of the grid
        /// </summary>
        /// <param name="bitsInWinningState"> amount of cells of the player that placed in an optional win, and the opponent's cells are not in between </param>
        /// <param name="bitsInStreak"> the number of the bits in a streak, (streak of cells of the same player without opponent's cells in between) </param>
        /// <returns> the score for that move </returns>
        private static int ScoreMarbles(int bitsInWinningState, int bitsInStreak)
        {
            if (bitsInWinningState >= BestScoring) return MaxValue;
            if (bitsInWinningState <= NotScoring) return 0;
            return bitsInWinningState * bitsInWinningState + bitsInStreak * bitsInStreak;
        }

        /// <summary>
        /// Calculate the best move that the user can play. the function will iterate over each possible move, make it, evaluate it,
        /// then unmake it. Then, the most optimal move will be chosen.
        /// </summary>
        private void ComputerMove()
        {
            // Initialize the variables that will hold the best move
            _bestMove = new Move();
            int bestScore = MinValue;

            // Iterate over each possible move, make it, evaluate it, then unmake it
            foreach (Move move in _possibleMoves.Moves)
                if (_grid.IsEmptyCell(move.Cell))
                {
                    MakeMove(move.Cell, true, move.Subgrid, move.Rotation);
                    if (Grid.CheckWin(_grid.Status2) && !Grid.CheckWin(_grid.Status1))
                    {
                        UnmakeMove(move.Cell, true, move.Subgrid, !move.Rotation);
                        _cell = move.Cell;
                        _rotation = GetRotation(move.Subgrid, move.Rotation);
                        return;
                    }
                    int score = MakeUserMove();
                    UnmakeMove(move.Cell, true, move.Subgrid, !move.Rotation);
                    if (score > bestScore)
                    {
                        bestScore = score;
                        _bestMove.Cell = move.Cell;
                        _bestMove.Subgrid = move.Subgrid;
                        _bestMove.Rotation = move.Rotation;
                    }
                }
            
            // Get the best cell and the best rotation
            _cell = _bestMove.Cell;
            _rotation = GetRotation(_bestMove.Subgrid, _bestMove.Rotation);
        }

        /// <summary>
        /// Calculate the best move that the computer can play. first, the computer will play the opening move, if yes, it will play it.
        /// otherwise, it will calculate the best move that it can play, by the CalculateMove() method.
        /// </summary>
        public void CalculateMove()
        {
            // If the computer is playing the opening move, play it.
            if (_isOpening) Opening();

            // Calculate the best move
            if (!_isOpening) ComputerMove();
        }
        
        // Make a move - update the status and rotate the subgrid of the player
        private void MakeMove(int cell, bool isComputerMove, int subgrid, bool rotation)
        {
            _grid.UpdateStatus(isComputerMove ? CellStatus.Player2 : CellStatus.Player1, cell);
            _grid.RotateSubgrid(subgrid, rotation);
        }
        
        // Unmake a move - restore the status and rotate the subgrid of the player back
        private void UnmakeMove(int cell, bool isComputerMove, int subgrid, bool rotation)
        {
            _grid.RotateSubgrid(subgrid, rotation);
            _grid.RemoveStatus(isComputerMove ? CellStatus.Player2 : CellStatus.Player1, cell);
        }
        
        // Returns the number of the rotation by the subgrid and the rotation. return -1 if the rotation is not found
        private static int GetRotation(int subgrid, bool rotation)
        {
            for (int i = 0; i < NumberOfRotations; i++)
                if (Rotations[i].SubgridIndex == subgrid && Rotations[i].IsClockwise == rotation) return i;
            return None;
        }
        
        /// <summary>
        /// Calculate the best move that the user can play after the computer played.
        /// </summary>
        /// <returns> the score of that move </returns>
        private int MakeUserMove()
        {
            int bestScore = MaxValue;
            
            // Iterate over each possible move, make it, evaluate it, then unmake it
            foreach (Move move in _possibleMoves.Moves)
                if (_grid.IsEmptyCell(move.Cell))
                {
                    MakeMove(move.Cell, false, move.Subgrid, move.Rotation);
                    int score = Evaluate();
                    UnmakeMove(move.Cell, false, move.Subgrid, !move.Rotation);
                    if (score < bestScore) bestScore = score;
                }
            return bestScore;
        }

        // Getter and Setter for the cell
        public int Cell
        {
            get { return _cell; }
            set { _cell = value; }
        }
        
        // Getter and Setter for the rotation
        public int Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
    }
}