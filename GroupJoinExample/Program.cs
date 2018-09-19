using System.Collections.Generic;
using System;
using System.Linq;

namespace InnerGroupJoinExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GroupJoinExample();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void GroupJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create a list where each element is an anonymous type
            // that contains the person's first name and a collection of
            // pets that are owned by them
            var query =
                from person in people
                join pet in pets on person equals pet.Owner into grpjoin
                select new { PersonName = person.FirstName, Pets=grpjoin};

            foreach (var item in query)
            {
                Console.WriteLine($"{item.PersonName}:");
                foreach (var Pet in item.Pets)
                {
                    Console.WriteLine($"   {Pet.Name}");
                }
            }
        }

        private class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        private class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }
    }
}