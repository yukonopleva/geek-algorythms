using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using UnityEngine;

namespace LessonTask3_1
{
    public class PointClass
    {
        public float X;
        public float Y;

        public PointClass(float f, float s)
        {
            X = f;
            Y = s;
        }
    }

    public struct PointStruct
    {
        public float X;
        public float Y;

        public PointStruct(float f, float s)
        {
            X = f;
            Y = s;
        }
    }

    public struct PointStructDouble
    {
        public double X;
        public double Y;

        public PointStructDouble(float f, float s)
        {
            X = f;
            Y = s;
        }
    }

    public class Program
    {
        public static PointClass pointOneC = new PointClass(1, 4);
        public static PointClass pointTwoC = new PointClass(5, 1);

        public static PointStruct pointOneS = new PointStruct(1, 4);
        public static PointStruct pointTwoS = new PointStruct(5, 1);

        public static PointStructDouble pointOneSD = new PointStructDouble(1, 4);
        public static PointStructDouble pointTwoSD = new PointStructDouble(5, 1);

        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class BechmarkClass
    {
        public static float PointDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return Mathf.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return Mathf.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            float x = (float)(pointOne.X - pointTwo.X);
            float y = (float)(pointOne.Y - pointTwo.Y);
            return Mathf.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceStructShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return Mathf.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        public void TestPointDistance()
        {
            PointDistance(Program.pointOneC, Program.pointTwoC);
        }

        [Benchmark]
        public void TestPointDistanceStruct()
        {
            PointDistanceStruct(Program.pointOneS, Program.pointTwoS);
        }

        [Benchmark]
        public void TestPointDistanceStructDouble()
        {
            PointDistanceStructDouble(Program.pointOneSD, Program.pointTwoSD);
        }

        [Benchmark]
        public void TestPointDistanceStructShort()
        {
            PointDistanceStructShort(Program.pointOneS, Program.pointTwoS);
        }
    }

}
