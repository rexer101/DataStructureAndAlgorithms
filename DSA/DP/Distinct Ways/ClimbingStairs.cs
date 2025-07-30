using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Distinct_Ways
{
    internal class ClimbingStairs
    {
        public void start()
        {
            Console.WriteLine(BottomUp(3));
            Console.WriteLine(TopDown());
        }

        private int BottomUp(int n)
        {
            int a = 0;
            int b = 1;
            int c = 0;

            for (int i = 0; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return b;
        }

        private int TopDown()
        {
            return 0;
        }
    }
}
