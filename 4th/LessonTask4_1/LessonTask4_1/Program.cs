using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace LessonTask4_1
{
	public class Values
	{
		public string Value { get; set; }
	}

	public class Program
	{
		public static string[] array = new string[10000];
		public static HashSet<Values> hashSet = new HashSet<Values>();
		public static Random rnd = new Random();

		static void Main(string[] args)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToString(rnd.Next());
				var val = new Values() { Value = array[i] };
				hashSet.Add(val);
			}

			BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
		}
	}

	public class BechmarkClass
	{
		public char ArraySearch(string[] array, string n)
		{
			for (int i = 0; i < array.Length; i++)
				if (array[i] == n)
					return 'Y';
			return 'N';
		}

		public char HashSearch(HashSet<Values> hashSet, string n)
		{
			Values val = new Values { Value = n };
			if (hashSet.Contains(val))
				return 'Y';
			return 'N';
		}

		[Benchmark]
		public void TestArraySearch()
		{
			ArraySearch(Program.array, "10");
		}

		[Benchmark]
		public void TestHashSearch()
		{
			HashSearch(Program.hashSet, "10");
		}
	}
}