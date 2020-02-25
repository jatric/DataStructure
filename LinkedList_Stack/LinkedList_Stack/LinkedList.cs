using System;
using System.Collections;
using System.Linq;

namespace LinkedListDemo
{
    public class LinkedListOperations
    {
        public static void StartMain()
        {
            LinkedList myLinkedList = CreateLinkedList();

            myLinkedList.NextGreater();

            //myLinkedList.MakeLoop();

            myLinkedList.findLoop();

            //Print all nodes
            myLinkedList.Print();

            //Count nodes in the list
            int count = myLinkedList.Count;
            Console.WriteLine("count: " + count);

            //search the node by value
            Node searchedNode = myLinkedList.SelectNode(18);

            if (searchedNode != null)
            {
                Console.WriteLine("Search node data - " + searchedNode.data);

                if (searchedNode.next != null)
                    Console.WriteLine("Search next node data - " + searchedNode.next.data);

                //Delete the searched node
                myLinkedList.Delete(searchedNode);
                int countAfterDelete = myLinkedList.Count;
                Console.WriteLine("count after delete : " + countAfterDelete);
            }

            //Print nodes in the list after operation
            PrintNodes(myLinkedList);


            //Reverse the list
            Console.WriteLine("Operation to reverse the list starting--------");
            myLinkedList.Reverse();
            myLinkedList.Print();

            Console.WriteLine("Operation odd even list starting--------");
            Node oddEventNode = myLinkedList.OddEven();
            oddEventNode.Print();


            Node reverInt = myLinkedList.ReverIntermediate(2, myLinkedList.Count - 1);
            Console.WriteLine("Operation reverse by indexing--------");
            reverInt.Print();
        }

        private static void PrintNodes(LinkedList list)
        {
            list.Print();
            int count = list.Count;
            Console.WriteLine("count: " + count);
        }

        private static LinkedList CreateLinkedList()
        {
            LinkedList myList = new LinkedList();

            int loop = 5; int data = 1;
            Random rand = new Random();
            while (loop > 0)
            {
                loop--;
                myList.AddToSorted(data++);
            }

            return myList;
        }
    }

    internal class Node
    {
        public int data;
        public Node next;

        public Node(int i)
        {
            data = i;
            next = null;
        }

        public void AddToEnd(int data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else
            {
                next.AddToEnd(data);
            }
        }

        public void AddToSorted(int data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else
            {
                if (data < next.data)
                {
                    Node temp = new Node(data);
                    temp.next = this.next;
                    this.next = temp;
                }
                else
                {
                    next.AddToSorted(data);
                }
            }
        }

        public void Print()
        {
            Console.Write(data + "-->");
            if (next != null)
            {
                next.Print();
            }
        }

    }

    internal class LinkedList
    {

        public Node headNode;
        
        public void AddToEnd(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else
            {
                headNode.AddToEnd(data);
            }
        }

        public void AddToSorted(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else if (data < headNode.data)
            {

                AddToBegining(data);

            }
            else
            {
                headNode.AddToSorted(data);
            }
        }

        public void AddToBegining(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else
            {
                Node temp = new Node(data);
                temp.next = headNode;
                headNode = temp;
            }
        }

        public int Count
        {
            get
            {

                return getCount();
            }
        }


        private int getCount()
        {
            int count = 0;
            Node next = headNode;
            while (next != null)
            {
                count++;
                next = next.next;
            }

            return count;
        }

        public Node SelectNode(int searchValue)
        {
            Node currentNode = headNode;
            Node resultNode = null;
            while (currentNode != null)
            {
                if (currentNode.data == searchValue)
                {
                    resultNode = currentNode;
                    return resultNode;
                }
                currentNode = currentNode.next;
            }

            return resultNode;
        }

        public Node ReverIntermediate(int start, int end) {

            Node dummy = new Node(0) { next = this.headNode };

            //get pre
            Node pre = dummy;
            for (int i = 0; i < start - 1; i++)
            {
                pre = pre.next;
            }

            //reverse
            Node curr = pre.next;
            for (int i= 0; i < end - start; i++)
            {                
                Node next = curr.next;
                curr.next = next.next;
                next.next = pre.next;
                pre.next = next;
            }
                                        
            return dummy.next;

        }

        public void Reverse()
        {
            Node prev = null, next, current;

            current = this.headNode;

            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;

                if(current != null)
                headNode = current;
            }
        }

        public void MakeLoop()
        {
            Node current = headNode;
            Node tail = null;
            while (current != null)
            {
                tail = current;
                current = current.next;
            }

            tail.next = headNode.next;
        }

        public int[] NextGreater()
        {
            Node current = this.headNode;
            Node next = this.headNode.next;
            ArrayList arr = new ArrayList();


            while (current != null)
            {
                
                if (current.data >= next.data)
                {
                    next = next.next;

                    if (next == null)
                    {
                        current.data = 0;
                        arr.Add(current.data);
                        next = current.next;
                        current = next;
                    }
                }
                else if (current.data < next.data)
                {
                    current.data = next.data;
                    arr.Add(current.data);
                    next = current.next;
                    current = next;
                }
                else
                {
                    next = next.next;
                }
            }

            int[] outputArray = new int[arr.Count];
            int count = 0;
            foreach (var i in arr)
            {
                outputArray[count] = (int)i;
                count++;
            }

            return outputArray;
        }

        public Node findLoop()
        {


            if (headNode == null || headNode.next == null || headNode.next.next == null)
                return null;

            Node slow = headNode.next;
            Node fast = headNode.next.next;
            
            Boolean hasCycle = false;
            //iterate the list and move 1st pointer by 1 and 2nd pointer by 2

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    hasCycle = true;
                    break;
                }
            }

            if (hasCycle)
            {
                slow = headNode;

                while (slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                }
            }
            

            return slow;
        }

        public Node Delete(Node node)
        {
            Node currentNode = headNode;
            Node prevNode = null;
            Node nextNode = headNode;

            if (this.headNode == node)
            {
                this.headNode = this.headNode.next;
            }
            else
            {
                while (currentNode != null)
                {

                    if (currentNode != node)
                    {
                        Console.WriteLine("--in loop -- : " + currentNode.data);
                        prevNode = currentNode;
                        currentNode = currentNode.next;
                    }
                    else
                    {
                        prevNode.next = currentNode.next;
                        currentNode = null;

                    }
                }
            }

            return node;
        }

        public Node OddEven()
        {
            Node odd = headNode;
            Node even = headNode.next;
            Node evenHead = even;

            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return headNode;
        }       

        public void Print()
        {
            headNode.Print();
        }
    }


}


