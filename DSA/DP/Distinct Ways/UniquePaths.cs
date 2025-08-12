using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSA.DP.Distinct_Ways
{
    public class UniquePaths
    {
        public void start()
        {
            Console.WriteLine(BottomUp(3, 2));
            Console.WriteLine(TopDown());
        }

        private int BottomUp(int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];
            dp[1, 0] = 1;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m, n];
        }

        private int TopDown()
        {
            return 0;
        }
    }
}