using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArraySort
{
    public class ReverseComparer : IComparer
    {
        
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] Unsorted = { 38, 32, 31, 30, 48, 48, 28, 46, 16, 5, 43, 12, 14, 15, 25, 27 };
           

            IComparer Reverse = new ReverseComparer();

            Console.WriteLine("The original Unsorted Array is: ");

            DisplayValues(Unsorted);

            // Sort a section of the array using the default comparer.
            Array.Sort(Unsorted, 1, 3);
            DisplayValues(Unsorted);

            // Sort a section of the array using the reverse case-insensitive comparer.
            Array.Sort(Unsorted, 1, 3, Reverse);
            Console.WriteLine("After sorting elements 1-3 by using the reverse case-insensitive comparer:");
            DisplayValues(Unsorted);

            // Sort the entire array using the default comparer.
            Array.Sort(Unsorted);
            Console.WriteLine("After sorting the entire array by using the default comparer:");
            DisplayValues(Unsorted);

            // Sort the entire array by using the reverse case-insensitive comparer.
            Array.Sort(Unsorted, Reverse);
            Console.WriteLine("After sorting the entire array using the reverse case-insensitive comparer:");
            DisplayValues(Unsorted);

            Array.Sort<int>(Unsorted, new Comparison<int>((i1, i2)=> i2.CompareTo(i1)));
            Console.WriteLine("Sweet method that I found to compare my unsorted array:");
            DisplayValues(Unsorted); 

        }

    
        public static void DisplayValues(int[] arr)
        {
            for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0);
                  i++)
            {
                Console.WriteLine("   [{0}] : {1}", i, arr[i]);
            }
            Console.WriteLine();
        }
        
  }
}




