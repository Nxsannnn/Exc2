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


namespace binary_and_linear
{
    class Program
    {
        // Array to be searched
        int[] ichsan = new int[63];
        //Number of elements in the array
        int n;
        //Get the number of elements to store in the array
        int i;

        public void input()
        {
            while (true)
            {
                Console.WriteLine("Enter the number of the element in the array: ");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if ((n > 0) && (n <= 20))
                    break;
                else
                    Console.WriteLine("\nArray should have minimum 1 and maximum 63 elements.\n");
            }
            //Accept array elements
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine(" Enter array elements ");
            Console.WriteLine("----------------------");

            for (i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                ichsan[i] = Int32.Parse(s1);
            }
        }

        public void BinarySearch()
        {
            char ch;
            do
            {
                //Accept the number to be searched
                Console.Write("\nEnter element want you to search: ");
                int item = Convert.ToInt32(Console.ReadLine());

                //Apply binary search
                int lowerbound = 0;
                int upperbound = n - 1;

                //Obtain the index of the elements
                int mid = (lowerbound + upperbound) / 2;
                int ctr = 1;

                //loop to search for the elements in the array
                while ((item != ichsan[mid]) && (lowerbound <= upperbound))
                {
                    if (item > ichsan[mid])
                        lowerbound = mid + 1;
                    else
                        upperbound = mid - 1;

                    mid = (lowerbound + upperbound) / 2;
                    ctr++;
                }
                if (item == ichsan[mid])
                    Console.WriteLine("\n" + item.ToString() + "found at position" + (mid + 1).ToString());
                else
                    Console.WriteLine("\n" + item.ToString() + "not found in the array\n");
                Console.WriteLine("\nNumber of comparison: " + ctr);

                Console.Write("\nContinue search (y/n): ");
                ch = char.Parse(Console.ReadLine());

            } while ((ch == 'y') || (ch == 'Y'));
        }

        public void LinearSearch()
        {
            char ch;
            //Search for number of comparison
            int ctr;
            do
            {
                //Accept the number to be searched
                Console.Write("\nEnter the element you want to search: ");
                int item = Convert.ToInt32(Console.ReadLine());

                ctr = 0;
                for (i = 0; i < n; i++)
                {
                    ctr++;
                    if (ichsan[i] == item)
                    {
                        Console.WriteLine("\n" + item.ToString() + " found st position" + (i + 1).ToString());
                        break;
                    }
                }
                if (i == 0)
                    Console.WriteLine("\n" + item.ToString() + " not found in the array");
                Console.WriteLine("\nNumber of comparison: " + ctr);
                Console.Write("\nContinue search (y/n): ");
                ch = Char.Parse(Console.ReadLine());

            } while ((ch == 'y') || (ch == 'Y'));
        }

        static void Main(string[] args)
        {
            Program myList = new Program();
            int pilihanmenu;
            do
            {
                Console.WriteLine("Menu option");
                Console.WriteLine("===============");
                Console.WriteLine("1. Linear search");
                Console.WriteLine("2. Binary search");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (1,2,3): ");
                pilihanmenu = Convert.ToInt32(Console.ReadLine());

                switch (pilihanmenu)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine(".....................");
                        Console.WriteLine("Linear Search");
                        Console.WriteLine(".....................");
                        myList.input();
                        myList.LinearSearch();
                        break;

                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("..............");
                        Console.WriteLine("Binary Search");
                        Console.WriteLine("..............");
                        myList.input();
                        myList.BinarySearch();
                        break;

                    case 3:

                        Console.WriteLine("exit");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                Console.WriteLine("\n\n Press Return to exit.");
                Console.ReadLine();

            } while (pilihanmenu != 3);
        }
    }
}