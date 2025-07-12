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
            int m = cost.Length + 1;
            int n = days[days.Length - 1] + 1;
            
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                dp[i][0] = 0;
            }
            for(int j = 0; j < n; j++)
            {
                dp[0][j] = int.MaxValue;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {                    
                    if (days.Contains(j))
                    {
                        int upval = dp[i - 1][j];
                        int preval = dp[i][j - 1];
                        int newcost = Math.Min(upval, preval);
                        dp[i][j] = newcost + cost[i - 1];
                    }
                    else
                    {
                        int preval = dp[i][j - 1];
                        dp[i][j] = preval;
                    }
                }
            }
            return dp[m - 1][n - 1];
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
