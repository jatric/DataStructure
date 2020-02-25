using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_Stack
{
    class HeapSort
    {

        public void Sort(string order)
        {
            //var arr = getIntArray();
            var arr = getIntArrayFromMatrix();
            int n = arr.Length;

            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("----heaped Array----");
            Console.WriteLine(" ");

            for (int i = n / 2 - 1; i >= 0; i--)
                if (order == "asc")
                {
                    MaxHeapify(arr, n, i);
                }
                else
                {
                    MinHeapify(arr, n, i);
                }


            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(" ");
            Console.WriteLine("----sorted Array----");
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                MinHeapify(arr, i, 0);
            }
            Console.WriteLine(" ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
        }

        public int[] getIntArray()
        {
            int[] arr = { 40, 45, 1, 19, 25, 4, 6, 14 };

            getIntArrayFromMatrix();

            return arr;
        }

        public int[] getIntArrayFromMatrix()
        {
            int[,] arr2D = new int[3, 3] { { 1, 5, 9}, { 10, 11, 13 }, { 12, 13, 15} };

            ArrayList arr = new ArrayList();
            int[] arr1 = new int[9];

            int count = 0;
            foreach(int ar in arr2D)
            {
                arr.Add(ar);
                arr1.SetValue(ar, count);
                count++;
            }

            return arr1;
        }

        public void MinHeapify(int[] arr, int n, int i)
        {
            int largest = i;

            int left = getLeftNode(largest);
            int right = getRightNode(largest);
            int head = arr[largest];


            if (left < n && arr[left] < arr[largest])
            {
                largest = left;
            }
            if (right < n && arr[right] < arr[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
                MinHeapify(arr, n, largest);
            }

        }

        public void MaxHeapify(int[] arr, int n, int i)
        {
            int largest = i;

            int left = getLeftNode(largest);
            int right = getRightNode(largest);
            int head = arr[largest];


            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
                MinHeapify(arr, n, largest);
            }

        }

        public int getLeftNode(int index)
        {
            return index * 2 + 1; 
        }

        public int getRightNode(int index)
        {
            return index * 2 + 2;
        }
    }
}
