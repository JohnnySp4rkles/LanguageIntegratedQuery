using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsOutsideQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> dataSource;

            try
            {
                dataSource = getData();
            }
            catch
            {
                Console.WriteLine("Invalid Operation!!");
                goto Exit;
            }

            var query =
                from ds in dataSource
                select ds * ds;

            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }

        Exit:
            Console.WriteLine("Press anyt key to exit!!");
            Console.ReadLine();
        }

        static IEnumerable<int> getData()
        {
            throw new InvalidOperationException();
        }
    }
}
