using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Array
{
    /*
     * Given a collection of intervals, merge all overlapping intervals.
     */
    public class T56
    {
        [Test]
        public void MergeTest()
        {
            var x = new[]
            {
                new[] {1,4},
                new[] {4,5}
            };

            var y = new[]
            {
                new[] {1,3},
                new[] {2,6},
                new[] {8,10},
                new[] {15,18},
                new[] {0,20},
            };

            
            var merged = MergeInner(x);
        }
        
        private int[][] MergeInner(int[][] intervals)
        {
            if (intervals.Length <= 1) return intervals;

            var result = new List<int[]>();

            intervals = intervals.OrderBy(i => i.First()).ToArray();
            
            var prev = intervals.First();
            for (var i = 1; i < intervals.Length; i++)
            {
                var current = intervals[i];
                if (prev.Last() >= current.First())
                {
                    if (current.First() < prev.First())
                    {
                        prev[0] = current[0];
                    }

                    if (current.Last() > prev.Last())
                    {
                        prev[^1] = current[^1];
                    }
                    if (i == intervals.Length - 1)
                    {
                        result.Add(prev);
                    }
                    
                }
                else
                {
                    result.Add(prev);
                    prev = current;
                    
                    if (i == intervals.Length - 1)
                    {
                        result.Add(current);
                    }
                }
            }

            return result.ToArray();
        }
    }
}