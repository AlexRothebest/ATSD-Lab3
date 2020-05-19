using System;


namespace Lab3
{
    class BinaryMaxHeap
    {
        public Node Head = null;
        public int Count = 0;


        public BinaryMaxHeap(params int[] values)
        {
            foreach (int i in values)
            {
                AddNode(i);
            }
        }


        public void AddNode(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);
                Count = 1;
                return;
            }

            Node CurrentNode = Head;
            string CountBinary = Convert.ToString(Count + 1, 2).Substring(1);
            foreach (char i in CountBinary)
            {
                if (i == '0')
                {
                    if (CurrentNode.Left != null)
                    {
                        CurrentNode = CurrentNode.Left;
                    }
                    else
                    {
                        CurrentNode.Left = new Node(data);
                    }
                }
                else if (i == '1')
                {
                    if (CurrentNode.Right != null)
                    {
                        CurrentNode = CurrentNode.Right;
                    }
                    else
                    {
                        CurrentNode.Right = new Node(data);
                    }
                }
            }

            Count++;
        }


        public int DeleteRoot()
        {
            if (Head == null)
            {
                Console.WriteLine("The heap is empty, impossible to delete root element");
                return -1000;
            }

            if (Head.Left == null && Head.Right == null)
            {
                int data = Head.Data;
                Head = null;
                Console.WriteLine("The last node was deleted, the heap is empty now");
                Count = 0;
                return data;
            }

            Node CurrentNode = Head;
            Node ParentOfCurrentNode = Head;
            string CountBinary = Convert.ToString(Count, 2).Substring(1);
            foreach (char i in CountBinary)
            {
                if (i == '0')
                {
                    ParentOfCurrentNode = CurrentNode;
                    CurrentNode = CurrentNode.Left;
                }
                else if (i == '1')
                {
                    ParentOfCurrentNode = CurrentNode;
                    CurrentNode = CurrentNode.Right;
                }
            }

            int DataToReturn = Head.Data;
            Head.Data = CurrentNode.Data;
            if (CountBinary[CountBinary.Length - 1] == '0')
            {
                ParentOfCurrentNode.Left = null;
            }
            else
            {
                ParentOfCurrentNode.Right = null;
            }

            Heapify();

            Count--;

            return DataToReturn;
        }


        public void Heapify()
        {
            if (Head == null)
            {
                Console.WriteLine("The heap is empty, impossible to heapify it");
                return;
            }

            Node CurrentNode = Head;
            while (CurrentNode.Left != null || CurrentNode.Right != null)
            {
                if (CurrentNode.Left != null && CurrentNode.Right != null)
                {
                    if (CurrentNode.Left.Data > CurrentNode.Right.Data)
                    {
                        if (CurrentNode.Left.Data > CurrentNode.Data)
                        {
                            int x = CurrentNode.Data;
                            CurrentNode.Data = CurrentNode.Left.Data;
                            CurrentNode.Left.Data = x;
                            CurrentNode = CurrentNode.Left;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (CurrentNode.Right.Data > CurrentNode.Data)
                        {
                            int x = CurrentNode.Data;
                            CurrentNode.Data = CurrentNode.Right.Data;
                            CurrentNode.Right.Data = x;
                            CurrentNode = CurrentNode.Right;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }


        public void Sort()
        {
            if (Head == null)
            {
                Console.WriteLine("The heap is empty, impossible to sort it");
                return;
            }

            int[] Values = Head.CollectList().ToArray();
            Array.Sort(Values);

            Head = null;
            Count = 0;
            foreach (int i in Values)
            {
                AddNode(i);
            }
        }


        public bool IsFull()
        {
            return Head != null;
        }


        public bool IsEmpty()
        {
            return Head == null;
        }


        public int Size()
        {
            return Count;
        }


        public void PrintPreOrder()
        {
            if (Head != null)
            {
                Head.PrintPreOrder();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The heap is empty");
            }
        }


        public static BinaryMaxHeap DeleteTop(BinaryMaxHeap x)
        {
            if (x.Head == null)
            {
                Console.WriteLine("The heap is empty, impossible to delete root element");
                return new BinaryMaxHeap();
            }

            BinaryMaxHeap HeapToReturn = new BinaryMaxHeap(x.Head.Data);
            x.DeleteRoot();
            return HeapToReturn;
        }


        public object this[int Index]
        {
            get
            {
                if (Index <= 0)
                {
                    throw new Exception($"Indexation starts from 1");
                }

                if (Count < Index)
                {
                    throw new Exception($"The heap has only {Count} elements");
                }

                Node CurrentNode = Head;
                string CountBinary = Convert.ToString(Index, 2).Substring(1);
                foreach (char i in CountBinary)
                {
                    if (i == '0')
                    {
                        CurrentNode = CurrentNode.Left;
                    }
                    else if (i == '1')
                    {
                        CurrentNode = CurrentNode.Right;
                    }
                }

                return CurrentNode.Data;
            }

            set
            {
                if (Index <= 0)
                {
                    throw new Exception($"Indexation starts from 1");
                }

                if (Count < Index)
                {
                    throw new Exception($"The heap has only {Count} elements");
                }

                Node CurrentNode = Head;
                string CountBinary = Convert.ToString(Index, 2).Substring(1);
                foreach (char i in CountBinary)
                {
                    if (i == '0')
                    {
                        CurrentNode = CurrentNode.Left;
                    }
                    else if (i == '1')
                    {
                        CurrentNode = CurrentNode.Right;
                    }
                }

                CurrentNode.Data = (int)value;
            }
        }
    }
}