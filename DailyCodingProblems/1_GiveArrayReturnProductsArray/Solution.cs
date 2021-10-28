using System;
using System.Collections.Generic;

namespace DailyCodingProblem1
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Uber.
    /// Given an array of integers, return a new array such that each element at index i of the new array is the product
    /// of all the numbers in the original array except the one at i.
    /// For example, if our input was[1, 2, 3, 4, 5], the expected output would be[120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be[2, 3, 6].
    /// Follow-up: what if you can't use division?
    /// 
    /// <b> Solution: 55min. 17sec. </b>
    /// </summary>
    
    class Solution
    {
        static void Main(string[] args)
        {
            int[] originalArray = GetUserOriginalList();
            int[] newArray = new int[originalArray.Length];

            for(int i = 0; i < originalArray.Length; i++)
            {
                newArray[i] = FindProductOfIndex(i, originalArray);
            }

            Console.WriteLine("Here is the new array of values: [" + string.Join(", ", newArray) + "]");

            CheckTryAgain();
        }

        private static int[] GetUserOriginalList()
        {
            Console.WriteLine("Please provide a list of integers separated by a space: ");
            String line = Console.ReadLine();
            List<int> intList = new List<int>();

            foreach(char c in line)
            {
                if(Char.IsWhiteSpace(c))
                {
                    continue;
                }

                if(!Int32.TryParse(c.ToString(), out int result))
                {
                    Console.WriteLine(c.ToString());
                    Console.WriteLine("Your list of integers was invalid. Ex: 1 2 3 4 5");

                    Main(null);
                }

                intList.Add(result);                
            }

            return intList.ToArray();
        }

        private static int FindProductOfIndex(int index, int[] array)
        {
            int product = 1;

            for(int i = 0; i < array.Length; i++)
            {
                if(i == index)
                {
                    continue;
                }

                product *= array[i];
            }

            return product;
        }

        private static void CheckTryAgain()
        {            
            Console.WriteLine("Enter a new List? (Y/N)");
            string input = Console.ReadLine();

            if(input.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Main(null);
            }
            else if(input.Equals("N", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Goodbye...");

                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("I'm sorry your input was invalid. Ex: y");

                CheckTryAgain();
            }
        }
    }
}
