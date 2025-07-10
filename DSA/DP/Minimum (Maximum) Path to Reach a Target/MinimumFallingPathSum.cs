using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class MinimumFallingPathSum
    {
        int[][] path = [[2, 1, 3], [6, 5, 4], [7, 8, 9]];

        public void start()
        {

            Console.WriteLine(TopDown());
            Console.WriteLine(BottomUp());
        }

        private int BottomUp()
        {
            int m = path.Length;
            int n = path[0].Length;
            int minimum = int.MaxValue;
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }
            for (int j = 0; j < n; j++)
            {
                dp[0][j] = path[0][j];
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int left = (j - 1) < 0 ? Int32.MaxValue : dp[i - 1][j - 1];
                    int top = dp[i - 1][j];
                    int right = (j + 1) >= n ? Int32.MaxValue : dp[i - 1][j + 1];

                    dp[i][j] = Math.Min(left, Math.Min(top, right)) + path[i][j];

                    if (i == m - 1 && dp[i][j] < minimum) minimum = dp[i][j];
                }
            }
            return minimum;
        }

        private int TopDown()
        {
            int m = path.Length;
            int n = path[0].Length;
            int minimum = int.MaxValue;
            int[][] dp = new int[m][];
            bool[][] dpflag = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                dpflag[i] = new bool[n];
            }
            for (int j = 0; j < n; j++)
            {
                minimum = Math.Min(minimum, TopDown(0, j, path.Length, path[0].Length, path, dp, dpflag));
            }

            return minimum;
        }

        private int TopDown(int i, int j, int m, int n, int[][] path, int[][] dp, bool[][] dpflag)
        {
            if (i >= m || j >= n || i < 0 || j < 0) return Int32.MaxValue;

            if (i == m - 1) return path[i][j];

            if (dpflag[i][j]) return dp[i][j];

            int left = TopDown(i + 1, j - 1, m, n, path, dp, dpflag);
            int down = TopDown(i + 1, j, m, n, path, dp, dpflag);
            int right = TopDown(i + 1, j + 1, m, n, path, dp, dpflag);

            dp[i][j] = Math.Min(left, Math.Min(down, right)) + path[i][j];
            dpflag[i][j] = true;
            return dp[i][j];
        }
    }
}
