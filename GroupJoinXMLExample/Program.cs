using System.Collections.Generic;
using System;
using System.Linq;
using System.Xml.Linq;

namespace GroupJoinXMLExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GroupJoinXMLExample();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void GroupJoinXMLExample()
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

            XElement ownersAndPets = new XElement("PetOwners",
                from person in people
                join pet in pets on person equals pet.Owner into grpjoin
                select new XElement("Person",
                    new XAttribute("FirstName", person.FirstName),
                    new XAttribute("LastName", person.LastName),
                    from subpet in grpjoin
                    select new XElement("Pet", subpet.Name)
                )

            );

            Console.WriteLine(ownersAndPets);

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