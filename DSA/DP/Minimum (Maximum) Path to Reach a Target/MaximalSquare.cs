using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class MaximalSquare
    {
        string[][] input = [["1", "0", "1", "0", "0"], ["1", "0", "1", "1", "1"], ["1", "1", "1", "1", "1"], ["1", "0", "0", "1", "0"]];
        public void start()
        {
            Console.WriteLine(BottomUp(input));
            Console.WriteLine(TopDown());
        }

        private int BottomUp(string[][] matrix)
        {
            int n = matrix.Length;
            if(n == 0) return 0;
            int m = input[0].Length;
            int max = 0;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[m];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] != "1") continue;
                    if (i == 0 || j == 0)
                    {
                        dp[i][j] = 1;
                    }
                    else
                    {
                        dp[i][j] = Math.Min(dp[i][j - 1], Math.Min(dp[i - 1][j], dp[i - 1][j - 1])) + 1;
                    }
                    max = Math.Max(max, dp[i][j]);
                }
            }
            return max*max;
        }

        private int TopDown()
        {
            return 0;
        }
    }
}
