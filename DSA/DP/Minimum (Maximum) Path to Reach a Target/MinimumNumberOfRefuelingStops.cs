using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class MinimumNumberOfRefuelingStops
    {
        public void start()
        {
            int[][] test = [[10, 60], [20, 30], [30, 30], [60, 40]];
            Console.WriteLine(BottomUp(100, 10, test));
            Console.WriteLine(TopDown());
        }

        private int BottomUp(int target, int startFuel, int[][] stations)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            int i = 0;            // Index for stations
            int fuel = startFuel; // Current fuel in tank
            int stops = 0;        // Number of stops

            // Loop until we reach or surpass target
            while (fuel < target)
            {
                // Add all reachable stations' fuel to maxHeap
                while (i < stations.Length && stations[i][0] <= fuel)
                {
                    pq.Enqueue(stations[i][1], stations[i][1]);
                    i++;
                }

                // No station reachable to refuel
                if (pq.Count == 0) return -1;

                // Refuel with largest fuel available
                fuel += pq.Dequeue();
                stops++;
            }

            return stops;
        }

        private int TopDown()
        {
            return 0;
        }
    }
}
