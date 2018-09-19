using System;
using System.Collections.Generic;
using System.Linq;

namespace MultipleJoinExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MultipleJoinExample();
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void MultipleJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };
            Person rui = new Person { FirstName = "Rui", LastName = "Raposo" };
            Person phyllis = new Person { FirstName="Phyllis", LastName="Harris"};

            Cat barley = new Cat { Name = "Barley", Owner = terry };
            Cat boots = new Cat { Name = "Boots", Owner = terry };
            Cat whiskers = new Cat { Name = "Whiskers", Owner = charlotte };
            Cat bluemoon = new Cat { Name = "Blue Moon", Owner = rui };
            Cat daisy = new Cat { Name = "Daisy", Owner = magnus };

            Dog fourwheeldrive = new Dog { Name = "Four Wheel Drive", Owner = phyllis };
            Dog duke = new Dog { Name = "Duke", Owner = magnus };
            Dog denim = new Dog { Name = "Denim", Owner = terry };
            Dog wiley = new Dog { Name = "Wiley", Owner = charlotte };
            Dog snoopy = new Dog { Name = "Snoopy", Owner = rui };
            Dog snickers = new Dog { Name = "Snickers", Owner = arlene };

            List<Person> people = new List<Person> { magnus,terry,charlotte, arlene, rui,phyllis};
            List<Cat> cats = new List<Cat> { barley, boots, whiskers, bluemoon, daisy };
            List<Dog> dogs = new List<Dog> { fourwheeldrive, duke, denim, wiley, snoopy, snickers};

            var query =
                from person in people
                join cat in cats on person equals cat.Owner
                join dog in dogs on
                new { Owner = person, Letter = cat.Name.Substring(0, 1) }
                equals new { dog.Owner, Letter = dog.Name.Substring(0, 1) }
                select new { CatName = cat.Name, DogName = dog.Name};

            foreach (var item in query)
            {
                System.Console.WriteLine($"The cat {item.CatName} shares a house with, and the first letter of their name with {item.DogName}");
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

        private class Cat : Pet{}
        private class Dog : Pet{}
    }
}