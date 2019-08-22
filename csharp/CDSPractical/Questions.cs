using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CDSPractical {
    public class Questions {
        /// <summary>
        /// Given an enumerable of strings, attempt to parse each string and if 
        /// it is an integer, add it to the returned enumerable.
        /// 
        /// For example:
        /// 
        /// ExtractNumbers(new List<string> { "123", "hello", "234" });
        /// 
        /// ; would return:
        /// 
        /// {
        ///   123,
        ///   234
        /// }
        /// </summary>
        /// <param name="source">An enumerable containing words</param>
        /// <returns></returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source)
        {
            List<int> numbers = new List<int>();
            int number = 0;

            foreach (string word in source)
            {
                if (int.TryParse(word, out number))
                {
                    numbers.Add(number);
                }
            }

            return numbers;
        }

        /// <summary>
        /// Given two enumerables of strings, find the longest common word.
        /// 
        /// For example:
        /// 
        /// LongestCommonWord(
        ///     new List<string> {
        ///         "love",
        ///         "wandering",
        ///         "goofy",
        ///         "sweet",
        ///         "mean",
        ///         "show",
        ///         "fade",
        ///         "scissors",
        ///         "shoes",
        ///         "gainful",
        ///         "wind",
        ///         "warn"
        ///     },
        ///     new List<string> {
        ///         "wacky",
        ///         "fabulous",
        ///         "arm",
        ///         "rabbit",
        ///         "force",
        ///         "wandering",
        ///         "scissors",
        ///         "fair",
        ///         "homely",
        ///         "wiggly",
        ///         "thankful",
        ///         "ear"
        ///     }
        /// );
        /// 
        /// ; would return "wandering" as the longest common word.
        /// </summary>
        /// <param name="first">First list of words</param>
        /// <param name="second">Second list of words</param>
        /// <returns></returns>
        public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second)
        {
            List<string> commonWords = new List<string>();
            foreach(string word in first)
            {
                if (second.FirstOrDefault(secondWord => secondWord.ToUpper() == word.ToUpper()) != null)
                {
                    commonWords.Add(word);
                }
            }

            if (commonWords.Count == 0)
                return string.Empty;

            int longestLength = commonWords.Max(word => word.Length);
            return commonWords.First(word => word.Length == longestLength);
        }

        /// <summary>
        /// Write a method that converts kilometers to miles, given that there are
        /// 1.6 kilometers per mile.
        /// 
        /// For example:
        /// 
        /// DistanceInMiles(16.00);
        /// 
        /// ; would return 10.00;
        /// </summary>
        /// <param name="km">distance in kilometers</param>
        /// <returns></returns>
        public double DistanceInMiles(double km)
        {
            double kilometersPerMile = 1.6;
            return km / kilometersPerMile;
        }

        /// <summary>
        /// Write a method that converts miles to kilometers, give that there are
        /// 1.6 kilometers per mile.
        /// 
        /// For example:
        /// 
        /// DistanceInKm(10.00);
        /// 
        /// ; would return 16.00;
        /// </summary>
        /// <param name="miles">distance in miles</param>
        /// <returns></returns>
        public double DistanceInKm(double miles) {
            double kilometersPerMile = 1.6;
            return miles * kilometersPerMile;
        }

        /// <summary>
        /// Write a method that returns true if the word is a palindrome, false if
        /// it is not.
        /// 
        /// For example:
        /// 
        /// IsPalindrome("bolton");
        /// 
        /// ; would return false, and:
        /// 
        /// IsPalindrome("Anna");
        /// 
        /// ; would return true.
        /// 
        /// Also complete the related test case for this method.
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns></returns>
        public bool IsPalindrome(string word)
        {
            int wordLength = word.Length;
            if (wordLength % 2 == 1)
            {
                word = word.Remove(wordLength/2, 1);
            }

            string firstPart = word.Substring(0,wordLength / 2);
            string secondPart = word.Substring(wordLength / 2);

            var charrArray = secondPart.ToCharArray();
            Array.Reverse(charrArray);
            string secondPartReversed = new string(charrArray);

            return firstPart == secondPartReversed;
        }

        /// <summary>
        /// Write a method that takes an enumerable list of objects and shuffles
        /// them into a different order.
        /// 
        /// For example:
        /// 
        /// Shuffle(new List<string>{ "one", "two" });
        /// 
        /// ; would return:
        /// 
        /// {
        ///   "two",
        ///   "one"
        /// }
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<object> Shuffle(IEnumerable<object> source)
        {
            List<object> sourceList = source.ToList();

            Random rand = new Random();
            int sourceCount = source.Count();
            for (int i = 0; i <= sourceCount - 2; i++)
            {
                int randomNumber = rand.Next(i+1, sourceCount);

                object aux = sourceList[i];
                sourceList[i] = sourceList[randomNumber];
                sourceList[randomNumber] = aux;
             }

            return sourceList;
        }

        /// <summary>
        /// Write a method that sorts an array of integers into ascending
        /// order - do not use any built in sorting mechanisms or frameworks.
        /// 
        /// Complete the test for this method.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public int[] Sort(int[] source) {
            int sourceCount = source.Count();
            for (int i =0; i<= sourceCount - 2; i++)
            {
                for (int j = i+1; j <= sourceCount - 1; j++)
                {
                    if (source[i] > source[j])
                    {
                        int aux = source[i];
                        source[i] = source[j];
                        source[j] = aux;
                    }
                }
            }

            return source;
        }    

        /// <summary>
        /// Each new term in the Fibonacci sequence is generated by adding the 
        /// previous two terms. By starting with 1 and 2, the first 10 terms will be:
        ///
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        ///
        /// By considering the terms in the Fibonacci sequence whose values do 
        /// not exceed four million, find the sum of the even-valued terms.
        /// </summary>
        /// <returns></returns>
        public int FibonacciSum() {
            Int32 firstNumber = 1;
            Int32 secondNumber = 2;
            Int32 sum = 2;
            while (secondNumber <= 4000000)
            {
                Int32 newNumber = firstNumber + secondNumber;
                if (newNumber % 2 == 0)
                {
                    sum += newNumber;
                }
                firstNumber = secondNumber;
                secondNumber = newNumber;
            }
            return sum;
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        /// 
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GenerateList() {
            var ret = new List<int>();
            var numThreads = 2;

            Thread[] threads = new Thread[numThreads];
            for (var i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(() => 
                {
                    var complete = false;

                    while (!complete)
                    {                        
                        var next = ret.Count + 1;
                        //Thread.Sleep(new Random().Next(1, 10));

                        if (next <= 100)
                        {
                            ret.Add(next);
                        }

                        if (ret.Count >= 100)
                        {
                            complete = true;
                        }
                        Thread.Sleep(new Random().Next(1, 10));
                    }                    
                });
                threads[i].Start();
            }

            //for (var i = 0; i < numThreads; i++)
            //{
            //    threads[i].Join();
            //}
            threads[numThreads - 1].Join();

            return ret;
        }
    }
}
