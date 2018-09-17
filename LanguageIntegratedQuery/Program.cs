using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageIntegratedQuery
{
    public delegate int IntDel(int a, int b);
    class Program
    {
        static Data d = new Data();
        static void Main(string[] args)
        {
            Console.WriteLine("# of users: {0}", d.users.Count);

            // WRITE CODE IN MAIN THAT INITIALIZES AND INVOKES THE DELEGATE
            var delA = new IntDel(Add);
            IntDel delB = Add;

            // INVOKE THE DELEGATE
            int resultA1 = delA.Invoke(1, 2);
            int resultA2 = delB.Invoke(2, 3);

            Console.WriteLine("{0} {1}",resultA1, resultA2);

            foreach (var item in d.users)
            {
                Console.WriteLine("First name: {0}", item.F_name);
            }


            Console.Write("Press any key to continue. . .");
            Console.ReadKey();
        }
        
        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
