using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask2_2
{
    class Program
    {
        public class TestCase
        {
            public int[] X { get; set; }
            public int Y { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0; //O(1)
            int max = inputArray.Length - 1; //O(1)
            while (min <= max) //O(N)
            {
                int mid = (min + max) / 2; //O(N)
                if (searchValue == inputArray[mid]) //O(N)
                {
                    return inputArray[mid];
                }
                else if (searchValue < inputArray[mid]) //O(N)
                {
                    max = mid - 1;
                }
                else //O(N)
                {
                    min = mid + 1;
                }
            }
            return -1; //O(1)
        }
        //O(1 + 1 + (N + N + N + N + N) + 1) => O(3 + 5N) => O(3 + 5N) => O(5N) => O(N)

        static void TestBinary(TestCase testCase)
        {
            try
            {
                var actual = BinarySearch(testCase.X, testCase.Y);

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
                X = new int[] { 1, 2, 3, 4, 5, 6},
                Y = 2,
                Expected = 2,
                ExpectedException = null
            };

            var testCase2 = new TestCase()
            {
                X = new int[] { 10, 20, 30, 40, 50, 60 },
                Y = 50,
                Expected = 50,
                ExpectedException = null
            };

            var testCase3 = new TestCase()
            {
                X = new int[] { 2, 4, 6, 8, 10, 12, 14 },
                Y = 4,
                Expected = 4,
                ExpectedException = null
            };

            var testCase4 = new TestCase()
            {
                X = new int[] { 10, 20, 30, 40, 50, 60 },
                Y = 50,
                Expected = 40,
                ExpectedException = null
            };

            var testCase5 = new TestCase()
            {
                X = new int[] { 2, 4, 6, 8, 10, 12, 14 },
                Y = 4,
                Expected = 8,
                ExpectedException = null
            };


            TestBinary(testCase1);
            TestBinary(testCase2);
            TestBinary(testCase3);
            TestBinary(testCase4);
            TestBinary(testCase5);

        }
    }
}
