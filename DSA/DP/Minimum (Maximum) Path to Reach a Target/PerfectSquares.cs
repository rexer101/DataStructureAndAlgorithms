using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class PerfectSquares
    {
        public void start()
        {
            Console.WriteLine(BottomUp(12));
            Console.WriteLine(TopDown(10));
        }

        private int BottomUp(int n)
        {
            int[] dp = new int[n + 1];
            for (int i = 1; i <= n; i++)
                dp[i] = Int32.MaxValue;
            dp[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                int j = 1;
                while(j*j <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j*j] + 1);
                    j += 1;
                }
            }
            return dp[n];
        }

        private int TopDown(int n)
        {
            return 0;
        }
    }
}
