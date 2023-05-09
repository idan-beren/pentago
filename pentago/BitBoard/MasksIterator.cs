using System.Collections;
using System.Collections.Generic;

namespace pentago.BitBoard
{
    // Iterator for the masks of the grid
    public class MasksIterator : IEnumerable<long>
    {
        // Constructor
        public IEnumerator<long> GetEnumerator()
        {
            foreach (long[] row in Grid.Masks)
                foreach (long element in row)
                    yield return element;

        }
        
        // Interface implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}