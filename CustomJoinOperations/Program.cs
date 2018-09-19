using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomJoinOperations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CrossJoin();
            Console.WriteLine();
            NonEquijoinQuery();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        private static void CrossJoin()
        {
            var crossjoinsquery =
                from c in categories
                from p in products
                select new { c.ID, p.Name };

            Console.WriteLine("Cross Join Query");
            foreach (var item in crossjoinsquery)
            {
                Console.WriteLine($"{item.ID,-10}{item.Name}");
            }
        }

        private static void NonEquijoinQuery()
        {
            var nonEquiJoinQuery =
                from p in products
                let catIDs = (from c in categories select c.ID)
                where catIDs.Contains(p.CategoryID) == true
                select new { p.Name, p.CategoryID };

            Console.WriteLine("Non-equijoin query");
            foreach (var item in nonEquiJoinQuery)
            {
                Console.WriteLine($"{item.CategoryID,-5}{item.Name}");
            }
        }

        #region data

        private class Product
        {
            public string Name { get; set; }
            public int CategoryID { get; set; }
        }

        private class Category
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        // Specify the first data source.
        private static List<Category> categories = new List<Category>()
 {
            new Category() { Name = "Beverages", ID = 001 },
            new Category() { Name = "Condiments", ID = 002 },
            new Category() { Name = "Vegetables", ID = 003 },
        };

        // Specify the second data source.
        private static List<Product> products = new List<Product>()
        {
            new Product{Name="Tea",  CategoryID=001},
            new Product{Name="Mustard", CategoryID=002},
            new Product{Name="Pickles", CategoryID=002},
            new Product{Name="Carrots", CategoryID=003},
            new Product{Name="Bok Choy", CategoryID=003},
            new Product{Name="Peaches", CategoryID=005},
            new Product{Name="Melons", CategoryID=005},
            new Product{Name="Ice Cream", CategoryID=007},
            new Product{Name="Mackerel", CategoryID=012},
        };

        #endregion data
    }
}