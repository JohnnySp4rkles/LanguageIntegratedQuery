using System;
using System.Linq;

namespace QueryThatThrows
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Data Source
            string[] files = { "fileA.txt", "fileB.txt", "fileC.txt" };

            var exceptionQuery =
                from file in files
                let n = SomeMethodThatMightFail(file)
                select n;

            try
            {
                foreach (var item in exceptionQuery)
                {
                    Console.WriteLine($"Processing: {item}");
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error:"+e.Message);
            }

            Console.Write("Press any key to continue..");
            Console.Read();
        }

        private static object SomeMethodThatMightFail(string file)
        {
            if (file[4] == 'C')
                throw new InvalidOperationException();
            return @"C:\newFolder\" + file;
        }
    }
}