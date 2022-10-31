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
        private int[] IA = new int[63];
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
            Console.WriteLine("\n===============");
            //get array elements
            for (int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                IA[i] = Int32.Parse(s1);
            }
        }
        //swaps the element at index x with the element at index y
        void swap(int x, int y)
        {
            int temp;

            temp = IA[x];
            IA[x] = IA[y];
            IA[y] = temp;
        }
        public void q_sort(int low, int high)
        {
            int pivot, i, j;
            if (low < high)
                return;

            i = low + 1;
            j = high;

            pivot = IA[low];
            while (i <= j)
            {
                while ((IA[i] <= pivot) && (i <= high))
                {
                    j++;
                    cmp_count++;
                }
                cmp_count++;

                while ((IA[j] <= pivot) && (j >= low))
                {
                    j--;
                    cmp_count++;
                }
                cmp_count++;
                if (i < j)
                {
                    swap(i, j);
                    mov_count++;
                }
            }
            if (low < j)
            {
                swap(low, j);
                mov_count++;
            }
            q_sort(low, j - 1);
            q_sort(j + 1, high);
        }
        void display()
        {
            Console.WriteLine("\n--------------");
            Console.WriteLine("Sorted array element");
            Console.WriteLine("----------------");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(IA[j]);
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
