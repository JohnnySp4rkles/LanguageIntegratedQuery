using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoCSVFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = System.IO.File.ReadAllLines("C:/Users/JDiamond/Desktop/names.csv");
            string[] scores = System.IO.File.ReadAllLines("C:/Users/JDiamond/Desktop/scores.csv");

            IEnumerable<Student> studentQuery =
                from name in names
                let x = name.Split(',')
                from score in scores
                let y = score.Split(',')
                where x[2] == y[0]
                select new Student()
                {
                    FirstName = x[0],
                    LastName = x[1],
                    ID = Convert.ToInt32(x[2]),
                    ExamScores = (from scoreastext in y.Skip(1) let cleaned = scoreastext.Replace('"',' ').Trim() select Convert.ToInt32(cleaned)).ToList()
                };

            foreach (var item in studentQuery)
            {
                Console.WriteLine($"The average score for student: {item.FirstName} {item.LastName} is: {item.ExamScores.Average()}");
            }
            Console.Write("Press any key to continue...");
            Console.Read();
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public List<int> ExamScores { get; set; }
        }
    }
}
