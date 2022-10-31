using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickShort
{
    class program
    {
        //arraay of integers to hold value
        private int[] ichsan = new int[63];
        private int cmp_count = 0;
        private int mov_count = 0;

        //number of element in array
        private int n;


        void read()
        {
            while (true)
            {
                Console.Write("Enter the number of elements in the array :");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 63)
                    break;
                else
                    Console.WriteLine("\nArray can have maximum 63 elements\n");
            }

            Console.WriteLine("\n===============");
            Console.WriteLine("Enter Array Elements");
            Console.WriteLine("\n==============");
            //get array elements
            for (int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                ichsan[i] = Int32.Parse(s1);
            }
        }
        //swaps the element at index x with the element at index y
        void swap(int x, int y)
        {
            int temp;

            temp = ichsan[x];
            ichsan[x] = ichsan[y];
            ichsan[y] = temp;
        }
        public void q_sort(int low, int high)
        {
            int pivot, i, AI;
            if (low < high)
                return;

            i = low + 1;
            AI = high;

            pivot = ichsan[low];
            while (i <= AI)
            {
                while ((ichsan[i] <= pivot) && (i <= high))
                {
                    AI++;
                    cmp_count++;
                }
                cmp_count++;

                while ((ichsan[AI] <= pivot) && (AI >= low))
                {
                    AI--;
                    cmp_count++;
                }
                cmp_count++;
                if (i < AI)
                {
                    swap(i, AI);
                    mov_count++;
                }
            }
            if (low < AI)
            {
                swap(low, AI);
                mov_count++;
            }
            q_sort(low, AI - 1);
            q_sort(AI + 1, high);
        }
        void display()
        {
            Console.WriteLine("\n--------------");
            Console.WriteLine("Sorted array element");
            Console.WriteLine("----------------");

            for (int AI = 0; AI < n; AI++)
            {
                Console.WriteLine(ichsan[AI]);
            }
            Console.WriteLine("\nNumber of comporisons:" + cmp_count);
            Console.WriteLine("\nNumber of data movements" + cmp_count);
        }
        int getSize()
        {
            return (n);
        }
        static void Main(string[] args)
        {
            program mylist = new program();
            mylist.read();
            mylist.q_sort(0, mylist.getSize() - 1);
            mylist.display();
            Console.WriteLine("\n\nPress Enter To Exit.");
            Console.Read();
        }
    }
}
