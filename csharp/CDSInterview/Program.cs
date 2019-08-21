﻿using System;
using System.Collections.Generic;
using System.Linq;
using CDSPractical;

namespace CDSInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();

                var menuItem = Console.ReadLine();
                int.TryParse(menuItem, out int option);

                Questions questions = new Questions();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter on the same line, multiple words and numbers separated by space");
                        var text = Console.ReadLine();
                        string[] words = text.Split(' ');

                        var numbers = questions.ExtractNumbers(words);
                        Console.WriteLine($"The entered numbers are:");
                        foreach (int number in numbers)
                        {
                            Console.Write($" {number}");
                        }

                        break;

                    case 2:
                        Console.WriteLine("Enter on the same line, multiple words separated by space");
                        var firstText = Console.ReadLine();
                        string[] firstLine = firstText.Split(' ');

                        Console.WriteLine("Enter again, on the same line, multiple words separated by space");
                        var secondText = Console.ReadLine();
                        string[] secondLine = secondText.Split(' ');

                        string longestCommonWord = questions.LongestCommonWord(firstLine, secondLine);
                        Console.WriteLine($"Longest common word is: {longestCommonWord}");

                        break;

                    case 3:
                        Console.WriteLine("Enter a number of kilometers");
                        string kmText = Console.ReadLine();
                        
                        if (double.TryParse(kmText, out double km))
                        {
                            double miles = questions.DistanceInMiles(km);
                            Console.WriteLine($"The converion of km to miles is: {miles.ToString()}");
                        }
                        else
                        {
                            Console.WriteLine("The conversion is not possible");
                        }

                        break;

                    case 4:
                        Console.WriteLine("Enter a number of miles");
                        string milesText = Console.ReadLine();
                        
                        if (double.TryParse(milesText, out double miles2))
                        {
                            double km2 = questions.DistanceInKm(miles2);
                            Console.WriteLine($"The converion of miles to km is: {km2.ToString()}");
                        }
                        else
                        {
                            Console.WriteLine("The conversion is not possible");
                        }

                        break;
                        
                    case 5:
                        Console.WriteLine("Enter one word");
                        string textForPalindrome = Console.ReadLine();

                        bool isPalindrome = questions.IsPalindrome(textForPalindrome);

                        Console.WriteLine($"Is palindrome: {isPalindrome}");
                        break;

                    case 6:
                        Console.WriteLine("Enter on the same line, multiple words separated by space");
                        break;

                    default:
                        Console.WriteLine($" {menuItem} is not a valid option.");
                        break;
                }
            }

        }

        private static void DisplayMenu()
        {
            Console.WriteLine(
                $"\nPlease enter the number of the method to be executed: \n" +
                $"1. { nameof(Questions.ExtractNumbers)} \n" +
                $"2. { nameof(Questions.LongestCommonWord)} \n" +
                $"3. { nameof(Questions.DistanceInMiles)} \n" +
                $"4. { nameof(Questions.DistanceInKm)} \n" +
                $"5. { nameof(Questions.IsPalindrome)} \n" +
                $"6. { nameof(Questions.Shuffle)} \n");
        }
    }
}
