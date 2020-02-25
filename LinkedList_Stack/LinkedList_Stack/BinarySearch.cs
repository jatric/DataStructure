using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_Stack
{
    class BinarySearch
    {
        public int[] getSortedArray()
        {
            List<int> sortedArray = new List<int>();

            sortedArray.Add(2);
            sortedArray.Add(12);
            sortedArray.Add(21);
            sortedArray.Add(35);
            sortedArray.Add(72);
            sortedArray.Add(100);
            sortedArray.Add(167);
            sortedArray.Add(190);
            sortedArray.Add(202);
            sortedArray.Add(234);
            sortedArray.Add(299);
            sortedArray.Add(400);

            return sortedArray.ToArray();
        }

        public int GetSearch(int search)
        {
            return Search(getSortedArray(), search, 0, getSortedArray().Length - 1);
        }


        public int Search(int[] arr, int search, int start, int end)
        {          

            int mid = end + start / 2;

            if (arr[mid] == arr[search])
                return arr[mid];

            while (start < end)
            {
                if (arr[mid] < arr[search])
                {
                    return Search(arr, search, mid + 1, end);
                }
                else
                {
                    return Search(arr, search, start, mid - 1);
                }

            }

            return search;
        }
    }
}
