using pentago.BitBoard;
using static pentago.Configurations;

namespace pentago.AI
{
    public static class Factors
    {
        private static long _horizontal = 0b111111111111111111000000000000000000; // horizontal symmetry
        private static long _vertical = 0b111000111000111000111000111000111000; // vertical symmetry
        private static long _centers = 0b000000000000001100001100000000000000; // center cells
        private static long _corners = 0b100001000000000000000000000000100001; // corner cells

        /// <summary>
        /// Count the amount of cells that placed in the winning option, only if that option to win doesn't contain opponent's cells.
        /// This function is being called from the evaluation function, there it checks to every option to win if it actually can lead to a win
        /// because if it contains opponent's cells, it can't lead to a win.
        /// </summary>
        /// <param name="status1"> the status of the player </param>
        /// <param name="status2"> the status of the opponent </param>
        /// <param name="mask"> mask that represents an optional win </param>
        /// <returns> the amount of cells in that option to win, only if that option to win doesn't contain opponent's cells </returns>
        public static int CountBitsInWinningState(long status1, long status2, long mask)
        {
            int count = 0;
            status1 &= mask;
            status2 &= mask;
            if (status1 == 0 || status2 != 0) return 0;
            for (int i = 0; i < NumberOfBits; i++)
                if ((status1 & (Bit << i)) != 0) count++;
            return count;
        }
        
        /// <summary>
        /// Check the length of the streak of a player. streak = cells of the player that are next to each other.
        /// This function is being called from the evaluation function, there it checks to every option to win the streaks
        /// of cells in the winning state.
        /// </summary>
        /// <param name="status"> the status of the player </param>
        /// <param name="mask"> mask that represents an optional win </param>
        /// <returns> the length of the streak at the position of the winning option </returns>
        public static int CountBitsInStreak(long status, long mask)
        {
            int count = 0;
            status &= mask;
            if (status == 0) return 0;
            for (int i = 0; i < NumberOfBits; i++)
            {
                long state = Bit << i;
                if ((status & state) != 0 && (mask & state) != 0) count++;
                else if ((mask & state) != 0 && count != 0) return count;
            }
            return count;
        }
        
        /// <summary>
        /// Check the average number of bits at the symmetries.
        /// </summary>
        /// <param name="status"> the status of the player </param>
        /// <returns> the average number of bits at the symmetries </returns>
        public static int CountBitsInSymmetries(long status)
        {
            int count = 0;
            count += CountBitsInSymmetry(status, _horizontal, Symmetry.Horizontal);
            count += CountBitsInSymmetry(status, _vertical, Symmetry.Vertical);
            return count / NumberOfSymmetries;
        }

        /// <summary>
        /// Check the number of bits at the symmetry.
        /// </summary>
        /// <param name="status"> the status of the player </param>
        /// <param name="mask"> symmetry mask </param>
        /// <param name="symmetry"> kind of symmetry </param>
        /// <returns> the number of bits the are symmetrical </returns>
        private static int CountBitsInSymmetry(long status, long mask, Symmetry symmetry)
        {
            long first = status & mask;
            long second = status & ~mask;
            int shift = 0;
            switch (symmetry)
            {
                case Symmetry.Horizontal:
                    shift = HorizontalShift;
                    break;
                case Symmetry.Vertical:
                    shift = VerticalShift;
                    break;
            }
            status = first >> shift & second;
            return CountBits(status);
        }

        /// <summary>
        /// Check the number of bits at the center and the corners.
        /// </summary>
        /// <param name="status"> the status of the player </param>
        /// <returns> the number of bits that are in the centers and corners </returns>
        public static int ControlCentersAndCorners(long status)
        {
            status &= _centers | _corners;
            return CountBits(status);
        }
        
        /// <summary>
        /// Check the number of bits at the subgrids.
        /// </summary>
        /// <param name="status"> the status of the player </param>
        /// <returns> the amount of bits that in the subgrids with the most bits </returns>
        public static int ControlSubgrids(long status)
        {
            int count = 0;
            foreach (long subgrid in Grid.SubgridsIterator)
            {
                int subgridCount = CountBits(status & subgrid);
                if (subgridCount > count) count = subgridCount;
            }
            return count;
        }
        
        // return the number of bits in the status that are turned on
        private static int CountBits(long status)
        {
            if (status == 0) return 0;
            int count = 0;
            long state = Bit;
            for (int i = 0; i < NumberOfBits; i++, state <<= i)
                if ((status & state) != 0) count++;
            return count;
        }
    }
}
