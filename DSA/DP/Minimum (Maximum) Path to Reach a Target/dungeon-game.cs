using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class dungeon_game
    {
        public void start()
        {
            int[][] test = [[-2, -3, 3], [-5, -10, 1], [10, 30, -5]];
            Console.WriteLine(BottomUp(test));
            Console.WriteLine(TopDown());
        }

        private int BottomUp(int[][] dungeon)
        {
            var dp = new int[dungeon.Length, dungeon[0].Length];

            for (int i = dungeon.Length - 1; i >= 0; i--)
            {
                for (int j = dungeon[i].Length - 1; j >= 0; j--)
                {
                    if (i == dungeon.Length - 1 && j == dungeon[i].Length - 1)
                    {
                        dp[i, j] = dungeon[i][j];
                    }
                    else if (i == dungeon.Length - 1)
                    {
                        dp[i, j] = dungeon[i][j] + dp[i, j + 1];
                    }
                    else if (j == dungeon[i].Length - 1)
                    {
                        dp[i, j] = dungeon[i][j] + dp[i + 1, j];
                    }
                    else
                    {
                        dp[i, j] = dungeon[i][j] + Math.Max(dp[i + 1, j], dp[i, j + 1]);
                    }

                    dp[i, j] = Math.Min(dp[i, j], 0);
                }
            }

            return Math.Abs(dp[0, 0]) + 1;
        }

        private int TopDown()
        {
            return 0;
        }
    }
}
