using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerJoinExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call JoinsExample
            InnerJoinsExample();
            Console.WriteLine("Press any key to continue. . .");
            Console.ReadKey();
        }



        public static void InnerJoinsExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };
            Person rui = new Person { FirstName = "Rui", LastName = "Raposo" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = rui };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create 2 lists for the Person and Pet Object
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene, rui };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy};

            var queryPetOwners =
                from person in people
                join pet in pets on person equals pet.Owner
                select new
                {
                    OwnerName = person.FirstName + " " + person.LastName,
                    PetName = pet.Name
                };

            // Print results to screen
            foreach (var item in queryPetOwners)
            {
                Console.WriteLine($"{item.PetName} is owned by {item.OwnerName}");
            }

        }


        // Classes!!
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }
    }
}
