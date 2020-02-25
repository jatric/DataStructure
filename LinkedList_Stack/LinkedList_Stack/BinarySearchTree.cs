using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_Stack
{
    public class Node {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Data { get; set; }

        public Node(int data)
        {
            this.Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BinarySearchTree {

        public BinaryTree Tree{ get; set; }
        public void InitializeTree()
        {
            BinaryTree tree = new BinaryTree();
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                tree.Add(rand.Next(30));
            }

            Tree = tree;
        }

        public Node FindTree(int value)
        {
            return Tree.Find(value);
        }
    }

    public class BinaryTree
    {
        public Node root { get; set; }

        public Node Find(int value)
        {
            Node root = this.root;

            return Find(value, root);
        }

        public void PreOrderPrint(Node Parent)
        {
            if (Parent == null)
                return;

            Console.Write(" " + Parent.Data);
            PreOrderPrint(Parent.Left);
            PreOrderPrint(Parent.Right);
        }

        public void InOrderPrint(Node Parent)
        {
            if (Parent == null)
                return;

            InOrderPrint(Parent.Left);
            Console.Write(" " + Parent.Data);
            InOrderPrint(Parent.Right);
        }

        public void PostOrderPrint(Node Parent)
        {
            if (Parent == null)
                return;

            PostOrderPrint(Parent.Left);
            PostOrderPrint(Parent.Right);
            Console.Write(" " + Parent.Data);
        }

        public Node Find(int value, Node parent)
        {
            Node result = null;

            if (parent == null)
                return null;

            if (value == parent.Data)
                result = parent;

            if (value < parent.Data)
                Find(value, parent.Left);
            else if (value > parent.Data)
                    Find(value, parent.Right);

            return result;
        }

        public bool Add(int data)
        {
            Node current = this.root;
            Node before = null;

            while (current != null)
            {
                before = current;

                if (data < current.Data)
                {
                    current = current.Left;
                }
                else if (data > current.Data)
                {
                    current = current.Right;
                }
                else
                {
                    return false;
                }
            }

            if (this.root == null)
            {
                Node newNode = new Node(data);
                this.root = newNode;
            }
            else
            {
                if (data < before.Data)
                {
                    before.Left = new Node(data);
                }
                else
                {
                    before.Right = new Node(data);
                }
            }

            return true;

        }
    }
}
