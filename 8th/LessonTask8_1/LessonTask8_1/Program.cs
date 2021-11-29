using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 54, 23, 5, 7, 23, 16, 35, 37, 180, 56, 1, 64, 23, 6, 5, 1, 25 };
            int[] sortArray = new int[array.Length];
            float max = array.Max();
            float min = array.Min();
            double kol = Math.Ceiling((max - min) / 10);
            int kol1 = Convert.ToInt32(kol);
            int m = 0;

            List<int>[] list = new List<int>[kol1];

            for (int i = 0; i < list.Length; ++i)
                list[i] = new List<int>();



            foreach (int i in array)
            {
                int j = 0;
                int step = 10;

                while (j < list.Length)
                    if (i <= min + step)
                    {
                        list[j].Add(i);
                        break;
                    }
                    else
                    {
                        step = step + 10;
                        j = j + 1;
                    }
            }
               

            foreach (List<int> el in list)
            {
                if (el.Count > 0)
                {
                    QuickSort(el, 0, el.Count - 1);

                    foreach (int elem in el)
                    {
                        sortArray[m] = elem;
                        m = m + 1;
                    }
                }
                   
            }

            for (int i = 0; i < sortArray.Length; i++)
                Console.WriteLine(sortArray[i]);

                }

        static void QuickSort(List<int> el, int first, int last)
        {
            int i = first, j = last, x = el[(first + last) / 2];

            do
            {
                while (el[i] < x)
                    i++;
                while (el[j] > x)
                    j--;

                if (i <= j)
                {
                    if (el[i] > el[j])
                    {
                        var tmp = el[i];
                        el[i] = el[j];
                        el[j] = tmp;
                    }

                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
                QuickSort(el, i, last);
            if (first < j)
                QuickSort(el, first, j);
        }

    }
        }
  

