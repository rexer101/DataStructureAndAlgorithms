using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class MinimumPathSum
    {
        int[][] path = [[1, 3, 1], [1, 5, 1], [4, 2, 1]];

        public void start()
        {
            Console.WriteLine(BottomUp(path));
            int m = path.Length;
            int n = path[0].Length;

            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }
            Console.WriteLine(TopDown(0, 0, path.Length, path[0].Length, path, dp));
        }

        private int BottomUp(int[][] path)
        {
            int m = path.Length;
            int n = path[0].Length;

            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }

            dp[0][0] = path[0][0];

            for (int i = 1; i < m; i++) 
            {
                dp[i][0] = dp[i - 1][0] + path[i][0];
            }

            for (int j = 1; j < n; j++)
            {
                dp[0][j] = dp[0][j - 1] + path[0][j];
            }

            for(int i = 1;i < m; i++)
            {
                for (int j = 1;j < n; j++)
                {
                    dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + path[i][j];
                }
            }

            return dp[m - 1][n - 1];
        }

        private int TopDown(int i, int j, int m, int n, int[][] path, int[][] dp)
        {
            if (i >= m || j >= n) return Int32.MaxValue;

            if (i == m - 1 && j == n - 1) return path[i][j];

            if (dp[i][j] != 0) return dp[i][j];

            //Right
            int right = TopDown(i, j + 1, m, n, path, dp);
            //Down
            int down = TopDown(i + 1, j, m, n, path, dp);
            
            dp[i][j] = Math.Min(right, down) + path[i][j];
            
            return dp[i][j];
        }
    }
}
