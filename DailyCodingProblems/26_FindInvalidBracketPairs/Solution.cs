using System;
using System.Collections.Generic;

/// <summary>
/// Good morning! Here's your coding interview problem for today.
/// This problem was asked by Facebook.
/// Given a string of round, curly, and square open and closing brackets, return whether the brackets are balanced (well-formed).
/// For example, given the string "([])[]({})", you should return true.
/// Given the string "([)]" or "((()", you should return false.
/// </summary>
namespace DailyCodingProblem26
{
    class BracketPair
    {
        public char LeftBracket { get; }

        public char RightBracket { get; }

        public BracketPair(char leftBracket, char rightBracket)
        {
            LeftBracket = leftBracket;
            RightBracket = rightBracket;
        }

        public char? OppositeFacingBracket(char bracket)
        {
            if (bracket == LeftBracket)
            {
                return RightBracket;
            }
            else if (bracket == RightBracket)
            {
                return LeftBracket;
            }
            else
            {
                return null;
            }
        }

        public bool IsBracket(char c)
        {
            if (c == RightBracket || c == LeftBracket)
            {
                return true;
            }

            return false;
        }
    }

    class BracketChecker
    {
        private List<BracketPair> validBracketPairs;

        private BracketChecker()
        {
            validBracketPairs = new List<BracketPair>();
        }

        public static BracketChecker GetInstance()
        {
            return new BracketChecker();
        }

        public void AddBracketPair((char rightFacing, char leftFacing) pair)
        {
            validBracketPairs.Add(new BracketPair(pair.rightFacing, pair.leftFacing));
        }

        public bool CheckString(String line)
        {
            try
            {
                string allBracketsInString = RemoveNonBracketCharacters(line.Trim());

                SortedDictionary<int, BracketPair> bracketPairsFromString = MapBracketPairsFromString(allBracketsInString);

                foreach (BracketPair p in bracketPairsFromString.Values)
                {
                    if (!IsBracketPairingValid(p))
                    {
                        Console.WriteLine($"{line} was did not have proper bracket closure");

                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private SortedDictionary<int, BracketPair> MapBracketPairsFromString(string allBracketsInString)
        {
            SortedDictionary<int, BracketPair> bracketPairs = new SortedDictionary<int, BracketPair>();

            ///for every bracket in the string, map it to the index of where the left facing bracket was found
            for (int i = 0; i < allBracketsInString.Length; i++)
            {
                if (!bracketPairs.ContainsKey(i))
                {
                    int? indexOfMatchingBracket = FindMatchingBracket(i, allBracketsInString);

                    if (indexOfMatchingBracket == null)
                    {
                        throw new Exception($"No matching pair found at Bracket Index {i}");
                    }

                    bracketPairs.Add((int)indexOfMatchingBracket, new BracketPair(allBracketsInString[i], allBracketsInString[(int)indexOfMatchingBracket]));
                }
            }

            return bracketPairs;
        }

        private int? FindMatchingBracket(int indexOfRightFacingBracket, string line)
        {
            BracketPair validBracketPair = null;

            if (!IsBracket(line[indexOfRightFacingBracket], out validBracketPair))
            {
                return null;
            }
            else
            {
                char? bracketToFind = validBracketPair.OppositeFacingBracket(line[indexOfRightFacingBracket]);

                int bracketLevel = 0;

                for(int i = indexOfRightFacingBracket; i < line.Length; i++)
                {
                    if(!RightFacingBrackets().Contains(line[i]))
                    {
                        bracketLevel--;

                        if (bracketLevel == 0 && line[i] == bracketToFind)
                        {
                            return i;
                        }
                        else if(bracketLevel <= 0 && line[i] != bracketToFind)
                        {
                            return null;
                        }                        
                    }
                    else
                    {
                        bracketLevel++;
                    }
                }

                return null;
            }
        }

        private bool IsBracketPairingValid(BracketPair pair)
        {
            if(pair.LeftBracket == pair.RightBracket)
            {
                return false;
            }

            return true;
        }

        private string RemoveNonBracketCharacters(string line)
        {
            string allBracketsInString = line;

            for(int i = 0; i < line.Length; i++)
            {
                if(!IsBracket(line[i]))
                {
                    allBracketsInString = allBracketsInString.Remove(i, 1);
                }
            }

            return allBracketsInString;
        }

        private bool IsBracket(char c)
        {
            foreach(BracketPair p in validBracketPairs)
            {
                if(p.IsBracket(c))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsBracket(char c, out BracketPair validBracketPair)
        {
            validBracketPair = null;

            foreach (BracketPair p in validBracketPairs)
            {
                if (p.IsBracket(c))
                {
                    validBracketPair = p;

                    return true;
                }
            }

            return false;
        }

        private List<char> RightFacingBrackets()
        {
            List<char> rightFacingBrackets = new List<char>();

            foreach(BracketPair pair in validBracketPairs)
            {
                rightFacingBrackets.Add(pair.LeftBracket);
            }

            return rightFacingBrackets;
        }
    }

    class Display
    {
        static BracketChecker checker;
        static string[] bracketsToCheck;

        static void Main()
        {
            checker = BracketChecker.GetInstance();
            bracketsToCheck = new string[] {"()", "()()()()()()()()", "{}{}{}{}{}{}{}{}", "(((())))", "([])[]({ })", "([)]", "((()" };

            checker.AddBracketPair(('{', '}'));
            checker.AddBracketPair(('(', ')'));
            checker.AddBracketPair(('[', ']'));

            foreach(string b in bracketsToCheck)
            {
                if(!checker.CheckString(b))
                {
                    Console.WriteLine(string.Format("Invalid Bracket: {0}", b));
                }
                else
                {
                    Console.WriteLine(string.Format("Valid Bracket: {0}", b));
                }
            }
        }
    }
}
