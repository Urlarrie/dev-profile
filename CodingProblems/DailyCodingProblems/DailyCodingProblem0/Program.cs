using System;

namespace DailyCodingProblem0
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was recently asked by Google.
    /// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
    /// For example, given[10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
    /// Bonus: Can you do this in one pass?
    /// 
    /// <b> Solution: 1hr 36min. </b>
    /// </summary>
    class FindSumInAListOfInt
    {
        static void Main(string[] args)
        {
            int[] listOfNumbers = new int[0] { };
            int k = 0;
            int firstNumber = 0;
            int secondNumber = 0;

            bool sumFound = false;

            Console.WriteLine("This program takes an a list of integers and a sum as an integer and tests to see whether or not there are two integers that equal that sum" +
                                "among the integers provided");
            Console.WriteLine("Please provide a list of integers adding a space between each number: ");

            bool validList = false;

            while(!validList)
            {
                string[] stringListOfNumbers = Console.ReadLine().Trim().Split(' ', '\n');

                bool flag = false;

                foreach(string s in stringListOfNumbers)
                {
                    bool isInt = Int32.TryParse(s, out int integer);

                    if(!isInt)
                    {
                        Console.WriteLine("Your input was invalid. Please type each integer in the list separated by a space. Example of proper input: 1 2 3 4 5 6 7");

                        flag = true;

                        break;
                    }                    
                }
                if (flag) continue;

                try
                {
                    listOfNumbers = Array.ConvertAll(stringListOfNumbers, s => int.Parse(s));
                }
                catch(FormatException e)
                {
                    ;
                }

                validList = true;
            }

            Console.WriteLine("Please provide a sum k: ");

            bool validNumber = false;

            while(!validNumber)
            {
                string number = Console.ReadLine().Trim();

                bool isValidInt = Int32.TryParse(number, out int integer);

                if(!isValidInt)
                {
                    Console.WriteLine("Your input was invalid. Please input an Integer. Example of proper input: 1");

                    continue;
                }

                k = Int32.Parse(number);

                validNumber = true;
            }

            foreach(int x in listOfNumbers)
            {
                int indexOfX = Array.IndexOf(listOfNumbers, x);

                foreach(int y in listOfNumbers)
                {
                    if(Array.IndexOf(listOfNumbers, y) != indexOfX)
                    {
                        if(x + y == k)
                        {
                            sumFound = true;
                            firstNumber = x;
                            secondNumber = y;

                            break;
                        }
                    }
                }

                if(sumFound)
                {
                    break;
                }                
            }

            if(sumFound)
            {
                try
                {
                    Console.WriteLine("The sum of {0} and {1} is equal to {2}", firstNumber, secondNumber, k);
                }
                catch(FormatException f)
                {

                    throw new ArgumentOutOfRangeException("Format Exception thrown");
                }
                
            }
            else
            {
                Console.WriteLine("Oh poop. A sum was not found.");
            }

            bool validAnswer = false;

            while(!validAnswer)
            {
                string[] validInput = { "y", "n" };

                Console.WriteLine("Try again? (Y/N)");

                string answer = Console.ReadLine();

                if(String.Compare("y", answer, true) == 0)
                {
                    Main(null);
                }
                else if(String.Compare("n", answer, true) == 0)
                {
                    Console.WriteLine("Thanks for playing, Goodbye!");

                    validAnswer = true;
                }
                else
                {
                    Console.WriteLine("Your input was invalid. Please type \"Y\" or \"N\". Example of valid input: y");

                    break;
                }

            }
        }
    }
}
