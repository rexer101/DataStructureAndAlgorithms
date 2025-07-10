using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class MinCostClimbingStairs
    {
        int[] cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1];

        public void start()
        {
            Console.WriteLine(BottomUp());
            Console.WriteLine(TopDown(new int[cost.Length + 1], cost, cost.Length));
        }

        private int BottomUp()
        {
            if (cost.Length <= 2) return Math.Min(cost[0], cost[1]);
            int[] dp = new int[cost.Length + 1];
            dp[0] = cost[0];
            dp[1] = cost[1];
            dp[2] = cost[2];
            for (int i = 2; i <= cost.Length; ++i)
            {
                dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + (i >= cost.Length ? 0 : cost[i]);
            }
            return dp[cost.Length];
        }

        private int TopDown(int[] dp, int[] cost, int i) 
        {
            if(i < 2) return cost[i];
            
            dp[i] = Math.Min(TopDown(dp, cost, i -1), TopDown(dp, cost, i -2)) + (i >= cost.Length ? 0 : cost[i]);

            return dp[i];
        }
    }
}
