using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class Triangle
    {
        public void start()
        {
            IList<IList<int>> cost = new List<IList<int>>();
            var var1 = new List<int>
            {
                -1
            };
            var var2 = new List<int>
            {
                3, 2
            };
            var var3 = new List<int>
            {
                -3, 1, -1
            };
            cost.Add(var1);
            cost.Add(var2);
            cost.Add(var3);

            Console.WriteLine(BottomUp(cost));
            Console.WriteLine(TopDown(cost));
        }

        private int BottomUp(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            int m = triangle[n - 1].Count;
            int mincost = int.MaxValue;

            if (n == 1) return triangle[0][0];

            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    dp[i][j] = int.MaxValue;
                }
            }

            dp[0][0] = triangle[0][0];

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    int left = int.MaxValue;
                    int top = int.MaxValue;
                    //int right = int.MaxValue;

                    if(j - 1 >= 0) left = dp[i - 1][j - 1];
                    top = dp[i - 1][j];
                    //if (j + 1 < m) right = dp[i - 1][j + 1];

                    dp[i][j] = Math.Min(left, top) + triangle[i][j];

                    if(i == n - 1) mincost = Math.Min(mincost, dp[i][j]);
                }
            }
            return mincost;
        }

        private int TopDown(IList<IList<int>> triangle)
        {
            return 0;
        }
    }
}
