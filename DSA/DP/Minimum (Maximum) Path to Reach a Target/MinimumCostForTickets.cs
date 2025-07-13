using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class MinimumCostForTickets
    {
        int[] days = [1, 4, 6, 7, 8, 20];
        int[] costs = [2, 7, 15];

        public void start()
        {
            Console.WriteLine(BottomUp(days, costs));
            Console.WriteLine(TopDown(days, 11));
        }

        private int BottomUp(int[] days, int[] cost)
        {
            int n = days.Length;       
            int[] dp = new int[n + 1];

            for (int i = 0; i < n + 1; i++)
                dp[i] = -1;

            dp[n] = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                int singledaycost = cost[0] + dp[i + 1];

                int j = i;
                int validityOfTicket = days[j] + 7 - 1;
                while (j < n && days[j] <= validityOfTicket)
                    j++;
                int weekDayCost = costs[1] + dp[j];

                j = i;
                validityOfTicket = days[j] + 30 - 1;
                while (j < n && days[j] <= validityOfTicket)
                    j++;
                int monthDayCost = costs[2] + dp[j];

                dp[i] = Math.Min(singledaycost, Math.Min(weekDayCost, monthDayCost));
            }
            return dp[0];
        }

        private int TopDown(int[] coins, int amount)
        {
            return 0;
        }

        private int TopDown(int[] coins, int target, int n, int[][] dp)
        {
            return 0;
        }
    }
}
