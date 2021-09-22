using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindrome_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //total time 11 min

            var wordList = new List<string> { "Racecar", "test word" };
            var numberList = new List<int> { 111, 121,225 };
            var doubleList = new List<double> { 12.321, 12.221, 225.32 };
            foreach (var item in wordList)
            {
                Console.WriteLine($"Word : {item}  - Result : {IsWordPalindrome(item)}");

            }
            foreach (var item in numberList)
            {
                Console.WriteLine($"Word : {item}  - Result : {IsWordPalindrome(item)}");

            }
            foreach (var item in doubleList)
            {
                Console.WriteLine($"Word : {item}  - Result : {IsWordPalindrome(item)}");

            }

            Console.ReadLine();
        }

        private static bool IsWordPalindrome(double number)
        {
            var word = number.ToString().Replace(","," ").ToLowerAndRemoveWhiteSpace();
            return IsWordPalindrome(word);
        }

        private static bool IsWordPalindrome(int number)
        {
            var word = number.ToString();
            return IsWordPalindrome(word);
        }

        private static bool IsWordPalindrome(string word)
        {
            var retVal = false;

            var reversedWord = word.ToLowerAndRemoveWhiteSpace().ToCharArray().Reverse();
            if(reversedWord.SequenceEqual( word.ToLowerAndRemoveWhiteSpace().ToCharArray()))
            {
                retVal = true;
            }

            return retVal;
        }


    }


}

public static class CodeTestExtensions
{
    public static string ToLowerAndRemoveWhiteSpace(this string str)
    {
        return str.ToLower().Replace(" ", "");
    }
} 
