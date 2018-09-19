using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeKeyJoinExample
{
    internal class Program
    {
        #region data

        private static List<Product> products = new List<Product>
        {
            new Product{ProductID=001, Description="Tennis ball",Price=2.00F},
            new Product{ProductID=002, Description="Tennis-Racket",Price=15.00F},
            new Product{ProductID=003, Description="Divider Net",Price=29.99F},
            new Product{ProductID=004, Description="Goal Posts",Price=24.99F},
            new Product{ProductID=005, Description="Soccer Boots",Price=32.99F},
            new Product{ProductID=006, Description="Goalie Gloves",Price=5.99F}
        };

        private static List<Order> orders = new List<Order> {
            new Order{OrderID=001, OrderDate=new DateTime(2011, 9, 12), CustomerID=001},
            new Order{OrderID=002, OrderDate=new DateTime(2011, 9, 15), CustomerID=004},
            new Order{OrderID=003, OrderDate=new DateTime(2011, 9, 17), CustomerID=003},
            new Order{OrderID=004, OrderDate=new DateTime(2011, 9, 19), CustomerID=001},
            new Order{OrderID=005, OrderDate=new DateTime(2011, 9, 21), CustomerID=002},
            new Order{OrderID=006, OrderDate=new DateTime(2011, 9, 27), CustomerID=001},
        };

        private static List<OrderDetails> orderDetails = new List<OrderDetails> {
            new OrderDetails{OrderID=001, ProductID=001, Quantity=2},
            new OrderDetails{OrderID=001, ProductID=002, Quantity=1},
            new OrderDetails{OrderID=002, ProductID=002, Quantity=1},
            new OrderDetails{OrderID=003, ProductID=004, Quantity=1},
            new OrderDetails{OrderID=003, ProductID=005, Quantity=1},
            new OrderDetails{OrderID=004, ProductID=006, Quantity=1},
            new OrderDetails{OrderID=005, ProductID=003, Quantity=1},
            new OrderDetails{OrderID=005, ProductID=002, Quantity=2},
            new OrderDetails{OrderID=006, ProductID=001, Quantity=1}
        };

        #endregion data

        private static void Main(string[] args)
        {
            CompositeKeyJoinExample();
            Console.Write("Press any key to continue...");
            Console.Read();
        }

        public static void CompositeKeyJoinExample()
        {
            var query =
                from order in orders
                from prod in products
                join od in orderDetails
                on new { order.OrderID, prod.ProductID } equals new { od.OrderID, od.ProductID } into details
                from d in details
                select new { order.OrderID, prod.ProductID, prod.Description, d.Quantity };

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Description}({item.ProductID})-{item.OrderID}: {item.Quantity}");
            }
        }

        private class Product
        {
            public int ProductID { get; set; }
            public string Description { get; set; }
            public float Price { get; set; }
        }

        private class Order
        {
            public int OrderID { get; set; }
            public DateTime OrderDate { get; set; }
            public int CustomerID { get; set; }
        }

        private class OrderDetails
        {
            public int OrderID { get; set; }
            public int ProductID { get; set; }
            public int Quantity { get; set; }
        }
    }
}