using pentago.Board;
using static pentago.Configurations;

namespace pentago.Players
{
    public class Human : Player
    {
        public const CellStatus Value = CellStatus.Player1; // value of the human => 1 = player 1
    }
}