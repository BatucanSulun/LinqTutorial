using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public static class OrderBy
    {
        //Coding Exercise 1
        /*
         Using LINQ, implement the OrderFromLongestToShortest method, which takes 
        a collection of strings, and returns those strings ordered from 
        longest to shortest.
        For example, for {"bb", "a", "ccc"} the result should be {"ccc", "bb", "a"}
         */
        public static IEnumerable<string> OrderFromLongestToShortest(
            IEnumerable<string> words)
        {
            return words.OrderByDescending(word => word.Length);
        }

        //Coding Exercise 2
        /*
         Using LINQ, implement the FirstEvenThenOddDescending method, 
         which orders numbers like this:
            *first, the even numbers
            *then, the odd numbers
         Then the numbers should be ordered descending. 
         For example, for numbers {1,2,3,4,5,6,7} the result should be: {6,4,2,7,5,3,1}.
         */
        public static IEnumerable<int> FirstEvenThenOddDescending(
            IEnumerable<int> numbers)
        {
            //return numbers.OrderBy(e=>e%2==0).OrderBy(o=>o%2==1).ThenByDescending(number=>number);
            //Key Info: When ordering a collection in C# language by a boolean variable, the false values come before true values.
            //Knowing that alternative solution is as follow:
            return numbers.OrderBy(num=>num%2!=0).ThenByDescending(number=>number);

        }

        //Refactoring challenge
        //TODO implement this method
        public static IEnumerable<DateTime> OrderByMonth_Refactored(List<DateTime> dates)
        {
            return dates.OrderBy(date=>date.Month);    
        }

        //do not modify this method
        public static IEnumerable<DateTime> OrderByMonth(List<DateTime> dates)
        {
            dates.Sort((left, right) =>
            {
                return left.Month.CompareTo(right.Month);
            });
            return dates;
        }
    }
}
