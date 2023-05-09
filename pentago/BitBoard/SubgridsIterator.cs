using System.Collections;
using System.Collections.Generic;

namespace pentago.BitBoard
{
    // Iterator for the subgrid masks of the grid
    public class SubgridsIterator : IEnumerable<long>
    {
        // Constructor
        public IEnumerator<long> GetEnumerator()
        {
            foreach (long element in Grid.SubGridsMasks)
                yield return element;
        }
        
        // Interface implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}