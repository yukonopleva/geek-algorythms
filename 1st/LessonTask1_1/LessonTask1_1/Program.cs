using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask1_1
{
    class Program
    {
        public class TestCase
        {
            public int X { get; set; }
            public string Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static string TryPrime(int n)
        {
            int d = 0;
            int i = 2;

            while (i < n)
            {
                if (n % i == 0)
                    d++;
                i++;
            }

            if (d == 0)
                return "Prime number";
            else
                return "Not prime number";
        }

        static void TestPrime(TestCase testCase)
        {
            try
            {
                var actual = TryPrime(testCase.X);

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
                Expected = "Prime number",
                ExpectedException = null
            };

            var testCase2 = new TestCase()
            {
                X = 4,
                Expected = "Not prime number",
                ExpectedException = null
            };

            var testCase3 = new TestCase()
            {
                X = 5,
                Expected = "Prime number",
                ExpectedException = null
            };

            var testCase4 = new TestCase()
            {
                X = 3,
                Expected = "Not prime number",
                ExpectedException = null
            };

            var testCase5 = new TestCase()
            {
                X = 6,
                Expected = "Prime number",
                ExpectedException = null
            };


            TestPrime(testCase1);
            TestPrime(testCase2);
            TestPrime(testCase3);
            TestPrime(testCase4);
            TestPrime(testCase5);
        }
    }
}
