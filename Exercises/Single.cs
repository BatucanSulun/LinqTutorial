using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public static class Single
    {
        //Coding Exercise 1
        /*
         Implement the GetTheOnlyUpperCaseWord method, which given a collection 
         of strings:
            *will return the only upper case string, if only one is present
            *will return null if no upper case string is present
            *will throw an InvalidOperationException if two or more upper case 
               strings are present.
         For example:
            *for words {"aaa", "BBB", "CcC"} the result will be "BBB"
            *for words {"aaa", "bbB", "CcC"} the result will be null
            *for words {"aaa", "BBB", "CcC", "DDD"} InvalidOperationException 
                will be thrown
         */
        public static string GetTheOnlyUpperCaseWord(IEnumerable<string> words)
        {
            //Kelimenin uzunluğu kelimedeki büyük harf sayısına eşit mi diye kontrol ediyoruz.
            return words.SingleOrDefault(
            word => word.Length == word.Count(character => char.IsUpper(character)));

            //First alternative, kelimedeki bütün karakterler büyük harf mi diye bakıyoruz.
            //return words.SingleOrDefault(word=>word.All(c=>char.IsUpper(c)));

            //Second alternative,
            //return words.SingleOrDefault(word => word.ToUpper() == word);
            //Kelimenin upper case hali kelimenin kendisine eşit mi diye bakıyoruz.
        }

        /*
        Implement the GetSingleElementCollection method, which given a nested collection
        of integers will return the only collection which contains only a single element. 
        
        For example, for numberCollections parameter like this:
            *numberCollections[0] = {1,2,3}
            *numberCollections[1] = {4}
            *numberCollections[2] = {5,6}
        ...the result shall be numberCollections[1], because it is the only 
        single-element collection in the input parameter

        If there is no single-element list present, or there is more than one list 
        like that, an InvalidOperationException should be thrown.

        For example, for numberCollections parameter like this:
            *numberCollections[0] = {1,2,3}
            *numberCollections[1] = {5,6}
        ...InvalidOperationException should be thrown, 
        because there is no single-element collection here.

        For example, for numberCollections parameter like this:
            *numberCollections[0] = {1,2,3}
            *numberCollections[1] = {4}
            *numberCollections[2] = {5,6}
            *numberCollections[3] = {7}

        ...InvalidOperationException should be thrown, 
        because there are two single-element collections here.
         */
        //Coding Exercise 2
        public static IEnumerable<int> GetSingleElementCollection(
            IEnumerable<IEnumerable<int>> numberCollections)
        {
            return numberCollections.Single(sequence=> sequence.Count()==1);
        }

        //Refactoring challenge
        //TODO implement this method
        public static DateTime? GetSingleDay_Refactored(
            IEnumerable<DateTime> dates, DayOfWeek dayOfWeek)
        {
            //First metodunu kullanmadan yaptığımız için ve hem Single() hem de SingleOrDefault() metotları predicate'e uyan birden fazla değer varsa hata fırlatacağı için bu yolu tercih etmememiz lazım
            //Temel algo şu şekilde işliyor: Aradığım dayofweek listedeki dayofweek'e eşitliğinin sayısı bir tane mi ? Hayır ise null gönder evet ise single ile o dayofweek'i gönder.        
            //Müthiş zekice!
            return dates.Count(date => date.DayOfWeek == dayOfWeek) == 1 ?
                dates.Single(date => date.DayOfWeek == dayOfWeek) :
                 null;
            //DateTime tipi değer tipli olduğu için ve == operatörü built-in bir şekilde zaten halihazırda overload edildiği için değer tipli karşılaştırma yapabiliyorum ve Contains kullanmama gerek kalmıyor.
            //return dates.First(date=> date.DayOfWeek==dayOfWeek);

        }

        //do not modify this method
        public static DateTime? GetSingleDay(
            IEnumerable<DateTime> dates, DayOfWeek dayOfWeek)
        {
            var count = 0;
            DateTime? result = null;
            foreach (var date in dates)
            {
                if (date.DayOfWeek == dayOfWeek)
                {
                    result = date;
                    count++;
                }
            }
            if (count == 1)
            {
                return result;
            }
            return null;
        }

        public enum PetType
        {
            Cat,
            Dog,
            Fish
        }

        public class Pet
        {
            public int Id { get; }
            public string Name { get; }
            public PetType PetType { get; }
            public float Weight { get; }

            public Pet(int id, string name, PetType petType, float weight)
            {
                Id = id;
                Name = name;
                PetType = petType;
                Weight = weight;
            }

            public override string ToString()
            {
                return $"Id: {Id}, Name: {Name}, Type: {PetType}, Weight: {Weight}";
            }
        }
    }
}
