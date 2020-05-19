using System;
using System.Collections.Generic;


namespace Lab3
{
    class Node
    {
        public int Data;
        public Node Left = null;
        public Node Right = null;


        public Node(int data)
        {
            Data = data;
        }


        public List<int> CollectList()
        {
            List<int> ItemsList = new List<int>();

            ItemsList.Add(Data);

            if (Left != null)
            {
                foreach (int i in Left.CollectList())
                {
                    ItemsList.Add(i);
                }
            }

            if (Right != null)
            {
                foreach (int i in Right.CollectList())
                {
                    ItemsList.Add(i);
                }
            }

            return ItemsList;
        }


        public void PrintPreOrder()
        {
            Console.Write(Data);
            Console.Write(" ");

            if (Left != null)
            {
                Left.PrintPreOrder();
            }

            if (Right != null)
            {
                Right.PrintPreOrder();
            }
        }
    }
}