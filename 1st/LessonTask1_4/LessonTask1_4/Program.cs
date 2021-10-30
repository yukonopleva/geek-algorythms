using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask1_3
{
    class Program
    {
        public class TestCase
        {
            public int X { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static int TryFibonachi(int n, int i, int j)
        {
            int s = 0;

            while (s < n)
            {
                s = i + j;
                i = j;
                j = s;
            }

            return j;
        }

        static void TestFibonachi(TestCase testCase, int i, int j)
        {
            try
            {
                var actual = TryFibonachi(testCase.X, i, j);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }

            }
        }

        static void Main(string[] args)
        {
            var testCase1 = new TestCase()
            {
                X = 2,
                Expected = 2,
                ExpectedException = null
            };

            var testCase2 = new TestCase()
            {
                X = 3,
                Expected = 3,
                ExpectedException = null
            };

            var testCase3 = new TestCase()
            {
                X = 5,
                Expected = 5,
                ExpectedException = null
            };

            var testCase4 = new TestCase()
            {
                X = 9,
                Expected = 34,
                ExpectedException = null
            };

            var testCase5 = new TestCase()
            {
                X = 7,
                Expected = 13,
                ExpectedException = null
            };


            TestFibonachi(testCase1, 0, 1);
            TestFibonachi(testCase2, 0, 1);
            TestFibonachi(testCase3, 0, 1);
            TestFibonachi(testCase4, 0, 1);
            TestFibonachi(testCase5, 0, 1);

        }
    }
}

