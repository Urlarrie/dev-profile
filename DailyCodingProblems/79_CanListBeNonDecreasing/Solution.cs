using System;

namespace DailyCodingProblem79
{
    /// <summary>
    /// This problem was asked by Facebook.
    /// Given an array of integers, write a function to determine whether the array could become non-decreasing by 
    /// modifying at most 1 element. For example, given the array [10, 5, 7], you should return true, since we 
    /// can modify the 10 into a 1 to make the array non-decreasing. Given the array [10, 5, 1], you should return
    /// false, since we can't modify any one element to get a non-decreasing array.
    /// </summary>
    class DisplaySolution
    {
        static void Main(string[] args)
        {
            int[] array1 = { 10, 5, 7 };
            int[] array2 = { 10, 5, 1 };
            int[] array3 = { 1, 3, 5, 6, 10, 4, 7 };
            int[] array4 = { 15, 6, 7, 8, 9, 2 };
            int[] array5 = { 16, 4, 5, 6, 7, 8 };
            int[] array6 = { -1, 5, 6, 7, 9, 1 };

            int[][] arrays = { array1, array2, array3, array4, array5, array6 };

            foreach(int[] array in arrays)
            {
                Console.WriteLine(Solution.DetermineIfCanBeNonDescending(array));
            }
        }
    }

    /// <summary>
    /// The solution to the problem
    /// </summary>
    class Solution
    {
        public static Func<int[], bool> DetermineIfCanBeNonDescending = (int[] array) =>
        {
            //iterate through array
            //count number of times the value after is less than the one before
            bool canBeNonDescending = false;
            bool greatestEncounteredReset = false;
            int lessThanCount = 0;
            int max = 0;
            int possibleGreatestNumberEncountered = 0;

            for(int i = 0; i < array.Length; i++)
            {
                if(max < array[i])
                {
                    max = array[i];
                    possibleGreatestNumberEncountered = array[i];
                }
                else if(!greatestEncounteredReset && max > array[i])
                {
                    if(possibleGreatestNumberEncountered > array[i])
                    {
                        possibleGreatestNumberEncountered = array[i];
                        lessThanCount++;
                        greatestEncounteredReset = true;
                    }                    
                }
                else if(greatestEncounteredReset)
                {
                    if(possibleGreatestNumberEncountered > array[i])
                    {
                        lessThanCount++;

                        break;
                    }
                    else if(possibleGreatestNumberEncountered < array[i] && max > array[i])
                    {
                        lessThanCount++;

                        break;
                    }                    
                }
            }

            if (lessThanCount < 2) canBeNonDescending = true;

            return canBeNonDescending;
        };
    }
}
