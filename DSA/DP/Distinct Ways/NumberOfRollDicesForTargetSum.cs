using System;

namespace DSA.DP.Distinct_Ways
{
    public class NumberOfRollDicesForTargetSum
    {
        public void start()
        {
            Console.WriteLine(BottomUp(1, 6, 3));
            Console.WriteLine(TopDown());
        }

        private int BottomUp(int n, int k, int target)
        {
            int MOD = 1000000007;
            int[] dp = new int[target + 1];
            dp[0] = 1;

            for (int i = 1; i <= n; i++) {
                int[] temp = new int[target + 1]; // Temporary array for current dice count
                for (int j = 1; j <= k; j++) {
                    for (int t = j; t <= target; t++) {
                        temp[t] = (temp[t] + dp[t - j]) % MOD;
                    }
                }
                Array.Copy(temp, 0, dp, 0, target + 1); // Update the dp array
            }

            return dp[target];
        }

        private int TopDown()
        {
            return 0;
        }
    }
}
