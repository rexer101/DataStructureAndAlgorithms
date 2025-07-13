using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DP.Minimum__Maximum__Path_to_Reach_a_Target
{
    internal class _2KeysKeyboard
    {
        int Alength = 18;

        public void start()
        {
            Console.WriteLine(BottomUp(Alength));
            Console.WriteLine(TopDown(Alength));
        }

        private int BottomUp(int Alength)
        {
            if (Alength == 1) return 0;
            int factor = 2;
            int steps = 0;
            while(Alength > 1)
            {
                while(Alength % factor == 0)
                {
                    Alength = Alength / factor;
                    steps += factor;
                }
                factor++;
            }
            return steps;
        }

        private int TopDown(int Alength)
        {
            return 0;
        }

    }
}
