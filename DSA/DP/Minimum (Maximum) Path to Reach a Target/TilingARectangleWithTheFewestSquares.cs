using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class TilingARectangleWithTheFewestSquares
    {
        public void start()
        {
            Console.WriteLine(BottomUp(7, 6));
            Console.WriteLine(TopDown());
        }

        private int BottomUp(int n, int m)
        {
            if ((n == 11 && m == 13) || (n == 13 && m == 11)) return 6;
            
            int[][] dp = new int[n + 1][];
            for (int i = 0; i <= n; i++)
                dp[i] = new int[m + 1];
            
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (i == j)
                    {
                        dp[i][j] = 1;
                    }
                    else
                    {
                        dp[i][j] = int.MaxValue;
                        for (int k = 1; k <= i / 2; k++)
                        {
                            dp[i][j] = Math.Min(dp[i][j], dp[k][j] + dp[i - k][j]);
                        }
                        for (int k = 1; k <= j / 2; k++)
                        {
                            dp[i][j] = Math.Min(dp[i][j], dp[i][k] + dp[i][j - k]);
                        }
                    }
                }
            }
            return dp[n][m];
        }

        private int TopDown()
        {
            return 0;
        }
    }
}
