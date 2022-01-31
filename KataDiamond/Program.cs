﻿using System;

namespace KataDiamond
{
    class Program
    {
        static int totalCharsPerLine;
        static int firstCharPosPlusSecondCharPos;
        static int firstCharPosition, secondCharPosition;
        static int diamondHeight;
        static int diamondCharAscii;
        static int startCharAscii;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter alphabet to print diamond for.");

            while(true)
            {
                string inputString = Console.ReadLine();

                if(ValidateDiamondInput(inputString) == false)
                {
                    Console.WriteLine("Please enter valid alphabet character.");
                    continue;
                }
                SetVariables(inputString[0]);
                PrintUpperHalfOfDiamond();
                PrintLowerHalfOfDiamond();

                Console.WriteLine("Enter alphabet to print diamond for.");
            }
        }

        static bool ValidateDiamondInput(string input)
        {
            if (String.IsNullOrWhiteSpace(input) ||
               input.Trim().Length != 1 ||
               char.IsLetter(input.Trim()[0]) == false)
                return false;

            return true;
        }

        private static void SetVariables(char inputChar)
        {
            diamondCharAscii = (int)inputChar;
            startCharAscii = char.IsLower(inputChar) ? 97 : 65;
            totalCharsPerLine = (diamondCharAscii - startCharAscii) * 2 + 1;
            diamondHeight = diamondCharAscii - startCharAscii + 1;
            firstCharPosPlusSecondCharPos = totalCharsPerLine + 1;
            firstCharPosition = secondCharPosition = 0;
        }

        static void PrintUpperHalfOfDiamond()
        {
            int currentCharAscii = startCharAscii;

            for (; currentCharAscii <= diamondCharAscii; currentCharAscii++)
            {
                firstCharPosition = diamondHeight;
                secondCharPosition = firstCharPosPlusSecondCharPos - diamondHeight;

                for (int countOfChars = 1; countOfChars <= totalCharsPerLine; countOfChars++)
                {
                    if (countOfChars == firstCharPosition || countOfChars == secondCharPosition)
                    {
                        Console.Write((char)currentCharAscii);
                        continue;
                    }
                    Console.Write(" ");
                }

                diamondHeight--;
                Console.WriteLine();
            }
        }

        static void PrintLowerHalfOfDiamond()
        {
            int currentCharAscii = diamondCharAscii - 1;

            for (int reverseDiamondHeight = 2; currentCharAscii >= startCharAscii; currentCharAscii--)
            {
                firstCharPosition = reverseDiamondHeight;
                secondCharPosition = firstCharPosPlusSecondCharPos - reverseDiamondHeight;

                for(int countOfChars = 1; countOfChars <= totalCharsPerLine; countOfChars++)
                {
                    if(countOfChars == firstCharPosition || countOfChars == secondCharPosition)
                    {
                        Console.Write((char)currentCharAscii);
                        continue;
                    }
                    Console.Write(" ");

                }
                reverseDiamondHeight++;
                Console.WriteLine();
            }

        }

    }
}
