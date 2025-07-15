using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class LastStoneWeightII
    {
        int[] stones = [2, 7, 4, 1, 8, 1];
        public void start()
        {
            Console.WriteLine(BottomUp(stones));
            Console.WriteLine(TopDown(10));
        }

        private int BottomUp(int[] stones)
        {
            int sum = stones.Sum() / 2, len = stones.Length, max = int.MinValue;
            bool[][] dp = new bool[len + 1][];
            for (int i = 0; i <= len; i++) dp[i] = new bool[sum + 1];
            for (int i = 0; i <= len; i++) dp[i][0] = true;
            for (int i = 1; i <= len; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    dp[i][j] = dp[i - 1][j];
                    if (!dp[i][j] && j >= stones[i - 1])
                        dp[i][j] = dp[i - 1][j - stones[i - 1]];
                    if (dp[i][j]) max = Math.Max(max, j);
                }
            }
            return stones.Sum() - max * 2;
        }

        private int TopDown(int n)
        {
            return 0;
        }
    }
}
