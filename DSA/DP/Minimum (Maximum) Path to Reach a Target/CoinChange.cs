using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class CoinChange
    {
        int[] coins = [1, 2, 5];

        public void start()
        {
            Console.WriteLine(BottomUp(coins, 11));
            Console.WriteLine(TopDown(coins, 11));
        }

        private int BottomUp(int[] coins, int amount)
        {
            int amountlen = amount + 1;
            int coinlen = coins.Length + 1;
            int[][] dp = new int[coinlen][];
            
            for(int i = 0; i < coinlen; i++)
            {
                dp[i] = new int[amount + 1];
                dp[i][0] = 0;
            }

            for(int j = 0; j < amountlen; j++)
            {
                dp[0][j] = Int32.MaxValue - 1;
            }

            for (int i = 1; i < coinlen; i++)
            {
                for(int j = 1; j < amountlen; j++)
                {
                    int upval = Int32.MaxValue;
                    if(j >= coins[i - 1])
                    {
                        upval = dp[i][j - coins[i - 1]] + 1;
                    }
                    int val = Math.Min(upval, dp[i - 1][j]);
                    dp[i][j] = val;
                }
            }
            return dp[coinlen - 1][amountlen - 1] == Int32.MaxValue - 1 ? -1 : dp[coinlen -1][amountlen - 1];
        }

        private int TopDown(int[] coins, int amount)
        {
            int[][] dp = new int[coins.Length + 1][];
            for (int i = 0; i <= coins.Length; i++)
            {
                dp[i] = new int[amount + 1];
                for (int j = 0; j <= amount; j++)
                {
                    dp[i][j] = -1;
                }
            }

            var ans = TopDown(coins, amount, coins.Length -1, dp);
            
            return ans == Int32.MaxValue - 1 ? -1 : ans;
        }

        private int TopDown(int[] coins, int target, int n, int[][] dp)
        {
            if(target == 0) return 0;

            if(n < 0 || target < 0) return Int32.MaxValue - 1;

            if (dp[n][target] != -1) return dp[n][target];

            int include = TopDown(coins, target - coins[n], n, dp) + 1;

            int exclude = TopDown(coins, target, n - 1, dp);

            return dp[n][target] = Math.Min(include, exclude);

        }
    }
}
