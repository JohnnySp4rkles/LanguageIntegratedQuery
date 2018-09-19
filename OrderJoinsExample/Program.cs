using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderJoinsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderJoins();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        static List<Product> products = new List<Product> {
            new Product{Name="Cola", CategoryID=001},
            new Product{Name="Tea", CategoryID=001},
            new Product{Name="Mustard", CategoryID=002},
            new Product{Name="Pickles", CategoryID=002},
            new Product{Name="Carrot", CategoryID=003},
            new Product{Name="Bok Choy", CategoryID=003},
            new Product{Name="Peaches", CategoryID=005},
            new Product{Name="Melon", CategoryID=005},
        };

        static List<Category> categories = new List<Category>
        {
            new Category{Name="Beverages", ID=001},
            new Category{Name="Condiments", ID=002},
            new Category{Name="Vegetables", ID=003},
            new Category{Name="Grains", ID=004},
            new Category{Name="Fruit", ID=005}
        };


        public static void OrderJoins()
        {
            var query =
                from category in categories
                join product in products on category.ID equals product.CategoryID into prodGroup
                orderby category.Name
                select new
                {
                    Category = category.Name,
                    Products = from prod2 in prodGroup
                               orderby prod2.Name
                               select prod2
                };

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Category}");
                foreach (var product in item.Products)
                {
                    Console.WriteLine($"\t{product.Name,-10} {product.CategoryID}");
                }
            }
        }


        class Product
        {
            public string Name { get; set; }
            public int CategoryID { get; set; }
        }
        class Category
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }
    }
}
