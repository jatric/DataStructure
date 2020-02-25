using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList_Stack
{
    class MergeSortAlgorithm
    {
        public int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return arr;


            int index = 0;
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            foreach(int item in arr)
            {
                if (index % 2 > 0)
                    left.Add(item);
                else
                    right.Add(item);

                index++;
            }


            left = MergeSort(left.ToArray()).ToList();
            right = MergeSort(right.ToArray()).ToList();

            return Merge(left, right);
        }

        public int[] Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First() <= right.First())
                {
                    result.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right.First());
                    right.RemoveAt(0);
                }
            }

            while (left.Count > 0)
            {
                result.Add(left.First());
                left.RemoveAt(0);
            }
            while (right.Count > 0)
            {
                result.Add(right.First());
                right.RemoveAt(0);
            }

            return result.ToArray();
        }

        
        public void StartMerge()
        {
            List<int> list = new List<int>();
            list.Add(12);
            list.Add(9);
            list.Add(11);
            list.Add(14);
            list.Add(5);
            list.Add(3);
            list.Add(8);
            list.Add(10);
            list.Add(23);

            Console.WriteLine("-----Unsorted Array----");
            Print(list.ToArray());
            var sorted = MergeSort(list.ToArray());

            Console.WriteLine("-----Sorted Array----");
            Print(sorted.ToArray());
        }

        public void Print(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("  ");
        }
    }
}
