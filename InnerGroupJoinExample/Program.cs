using System.Collections.Generic;
using System;
using System.Linq;

namespace InnerGroupJoinExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            InnerGroupJoinExample();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void InnerGroupJoinExample()
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

            var query1 =
                from person in people
                join pet in pets on person equals pet.Owner into gj
                from subpet in gj
                select new { OwnerName = person.FirstName, PetName = subpet.Name };

            Console.WriteLine("Inner join using GroupJoin():");
            foreach (var item in query1)
            {
                Console.WriteLine($"{item.OwnerName} - {item.PetName}");
            }

            var query2 =
                from person in people
                join pet in pets on person equals pet.Owner
                select new { OwnerName = person.FirstName, PetName = pet.Name };

            Console.WriteLine("\nThe equivalent operation using Join()");
            foreach (var item in query2)
            {
                Console.WriteLine($"{item.OwnerName} - {item.PetName}");
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