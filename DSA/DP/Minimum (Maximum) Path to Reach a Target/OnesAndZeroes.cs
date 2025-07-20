using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class OnesAndZeroes
    {
        public void start()
        {            
            Console.WriteLine(BottomUp(["10", "0001", "111001", "1", "0"], 5, 3));
            Console.WriteLine(TopDown());
        }

        private int BottomUp(string[] strs, int m, int n)
        {
            int[][] dp = new int[m + 1][];

            for (int i = 0; i <= m; i++) 
            {
                dp[i] = new int[n + 1];
            }

            foreach(string input in strs)
            {
                int ones = 0;
                int zeroes = 0;

                foreach (char str in input)
                {
                    if(str == '1') ones++;
                    else zeroes++;
                }


                for (int i = m; i >= zeroes; i--)
                {
                    for (int j = n; j >= ones; j--)
                    {
                        int value = Math.Max(dp[i][j], dp[i - zeroes][j - ones] + 1);
                        dp[i][j] = value;
                    }
                }
            }


            return dp[m][n];
        }

        private int TopDown()
        {
            return 0;
        }
    }
}
