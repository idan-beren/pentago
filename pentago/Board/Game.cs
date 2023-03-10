using pentago.Players;
using static pentago.Configurations;

namespace pentago.Board
{
    public class Game
    {
        private Grid _grid; // grid
        private Computer _computer; // computer
        private Human _human; // human

        // Constructor
        public Game()
        {
            _grid = new Grid();
            _computer = new Computer();
            _human = new Human();
            Sequence();
        }
        
        private void Sequence()
        {
            
        }
        
        
        
        private bool InsertValue(CellStatus player)
        {
            if (player == CellStatus.Player1)
            {
                Coordinates coordinates = _human.CellCoordinates();
                return _grid.InsertValue(player, coordinates.SubgridX, coordinates.SubgridY, coordinates.CellX, coordinates.CellY);
            }
            else
            {
                // TODO: Computer
                return true;
            }
        }
        

        // Getters and Setters for the grid
        public Grid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }
    }
}