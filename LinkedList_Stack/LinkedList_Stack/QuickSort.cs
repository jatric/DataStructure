using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LinkedList_Stack
{
    class QuickSort
    {
        ArrayList arr;

        public MyArrayList InitializeArray(int size)
        {
            arr = new ArrayList();

            //for (int i = 0; i < size; i++)
            //{
            //    Random ran = new Random();
            //    arr.Add(ran.Next(10, 20));
            //}

            arr.Add(1);
            arr.Add(5);
            arr.Add(0);
            arr.Add(34);
            arr.Add(3);
            arr.Add(3);
            arr.Add(9);
            arr.Add(90);
            arr.Add(40);

            return new MyArrayList(arr);
        }
    }

    public class MyArrayList {
        ArrayList arr;

        public MyArrayList(ArrayList _arr) {

            this.arr = _arr;
        }

        public ArrayList List {
            get {
                return arr;
            }
        }


        public int Count {
            get {
                return arr.Count;
            }
        }


        public void QuickSort(ArrayList arr)
        {                                  

            SortArray(arr, 0, arr.Count - 1);
            
        }

        private int PivotElement(ArrayList localArr, int left, int right)
        {
            int lowVal = (int)localArr[left];
            int highVal = (int)localArr[right];
            int middleVal = (int)localArr[((left + right) / 2)];

            if (middleVal > lowVal || middleVal < highVal)
            {
                return middleVal;
            }
            else if (lowVal > highVal)
            {
                return lowVal;
            }
            else { return highVal; }
        }

        private void SortArray(ArrayList lArra, int left, int right)
        {
            if (left >= right)
                return;

            int i = left;
            int j = right;
            int pivot = PivotElement(lArra, left, right);

            while (i <= j)
            {
                while ((int)lArra[i] < pivot)
                {
                    i++;
                }

                while ((int)lArra[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    //swap value of i and j
                    var tempi = lArra[i];
                    lArra[i] = lArra[j];                    
                    lArra[j] = tempi;
                    
                    i++;
                    j--;
                }
            }            

            if (left < j)
            {
                SortArray(lArra, left, j);                               
            }

            if (i < right)
            {
                SortArray(lArra, i, right);
            }
        }

        public void Print()
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(" --- ");            
        }

    }
}
