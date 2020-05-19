using System;


namespace Lab3
{
    class Program
    {
        public static BinaryMaxHeap BuildHeap(int[] values)
        {
            return new BinaryMaxHeap(values);
        }


        static void Main(string[] args)
        {
            BinaryMaxHeap a = new BinaryMaxHeap(1, 2, 10);

            a[2] = 3;

            // Console.WriteLine((int)a[0]);
            // Error
            Console.WriteLine((int)a[1]);
            Console.WriteLine((int)a[2]);
            Console.WriteLine((int)a[3]);

            a.Heapify();

            a.AddNode(4);
            a.AddNode(5);
            a.AddNode(6);

            a.DeleteRoot();
            a.PrintPreOrder();

            a.Sort();
            a.PrintPreOrder();

            BinaryMaxHeap b = BinaryMaxHeap.DeleteTop(a);

            a.PrintPreOrder();
            b.PrintPreOrder();

            int[] values = {1, 4, 546};

            BinaryMaxHeap x = BuildHeap(values);

            x.PrintPreOrder();
        }
    }
}