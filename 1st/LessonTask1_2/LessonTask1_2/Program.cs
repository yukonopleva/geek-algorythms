using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask1_2
{
    class Program
    {
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(N)
                    {
                        int y = 0; // O(N)

                        if (j != 0)  // O(N)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;  // O(N)
                    }
                }
            }

            return sum; // O(1)
        }

 //O(1 + O(N * N * (N + N + N + N)) + 1) => O(N * N * (4N)) => O(N * N * N) => O(N^3)

        static void Main(string[] args)
        {
        }
    }
}
