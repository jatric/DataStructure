using System;
using LinkedListDemo;

namespace LinkedList_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BinarySearchTree searchTree = new BinarySearchTree();

            searchTree.InitializeTree();

            Console.WriteLine("Please enter the number want to search: ");
            var value = Console.ReadLine();

            Node ret = searchTree.FindTree(Convert.ToInt32(value));

            if (ret != null)
            {
                Console.WriteLine("Result: " + ret.Data);
            }
            else {
                Console.WriteLine("Expected value doesn't exist in the binary tree");
                Console.WriteLine("Look at the items below and search again");
                //searchTree.Tree.PreOrderPrint();
            }

            Console.WriteLine(" ");
            Console.WriteLine("PreOrder: ");
            //Console.WriteLine(" ");
            searchTree.Tree.PreOrderPrint(searchTree.Tree.root);

            Console.WriteLine(" ");
            Console.WriteLine("InOrder: ");
            //Console.WriteLine(" ");
            searchTree.Tree.InOrderPrint(searchTree.Tree.root);

            Console.WriteLine(" ");
            Console.WriteLine("PostOrder: ");
            //Console.WriteLine(" ");
            searchTree.Tree.PostOrderPrint(searchTree.Tree.root);

            Console.Read();

            //BinarySearch bs = new BinarySearch();
            //int ret = bs.GetSearch(6);

            //MergeSortAlgorithm mergeSort = new MergeSortAlgorithm();
            //mergeSort.StartMerge();


            //LinkedListOperations.StartMain();



            //QuickSort sort = new QuickSort();
            //var list = sort.InitializeArray(7);

            //list.Print();

            //list.QuickSort(list.List);
            //Console.WriteLine("Sorted Array");
            //list.Print();

            //Find kth by QuickSort
            //KthByQuickSort k = new KthByQuickSort();
            //k.FindKth();

            //HeapSort heap = new HeapSort();
            //Console.WriteLine(" ");
            //Console.WriteLine("Arrange in ascending sorting order");
            //heap.Sort("asc");

            //Console.WriteLine(" ");
            //Console.WriteLine("Arrange descending sorting order");
            //heap.Sort("desc");


            //GoatLatinProblem gl = new GoatLatinProblem();
            //var result = gl.ToGoatLatin("I speak Goat Latin");

            //Console.WriteLine(result);

            Console.Read();
                      
        }
    }
}
