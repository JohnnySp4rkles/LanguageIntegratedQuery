using System;
using System.Collections.Generic;
using System.Linq;

namespace LanguageIntegratedQuery {

    public delegate int IntDel(int a, int b);

    internal class Program {
        private static Data d = new Data();
        static List<int> numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        static List<int> numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };
        static List<int> concatedValues = numbers1.Concat(numbers2).ToList();

        private static void Main(string[] args) {
            // WRITE CODE IN MAIN THAT INITIALIZES AND INVOKES THE DELEGATE
            var delA = new IntDel(Add);
            IntDel delB = Add;

            // INVOKE THE DELEGATE
            int resultA1 = delA.Invoke(1, 2);
            int resultA2 = delB.Invoke(2, 3);

            // QUERIES!!!
            // Standard Query
            IEnumerable<int> highScoresQuery0 = // Query Variable
                from number in d.users // Required
                where number.Fav > 50 // Optional
                orderby number.Fav descending // Optional
                select number.Fav; // Must end in Select or Groupby

            // Projection - Int to a String
            IEnumerable<string> highScoresQuery1 =
                from number in d.users
                where number.Fav > 80
                orderby number.Fav descending
                select $"The score is {number}";

            // Count Expression
            int highScoreCount1 =
                (from number in d.users
                 where number.Fav > 80
                 select number.Fav)
                 .Count();
            /********* OR ***********/
            IEnumerable<int> highScoresQuery2 =
                from number in d.users
                where number.Fav > 80
                select number.Fav;
            int scoreCount = highScoresQuery2.Count();

            // Groupby
            var queryNumberGroup =
                (from number in d.users
                 group number by number.Fav >= 75);

            // Projection - Anonnymous Type
            var favNumQuery =
                from user in d.users
                select new { name = user.F_name + " " + user.L_name, number = user.Fav };

            // averageQuery is an IEnumerable<IGrouping<int, User>>
            var averageQuery =
                from user in d.users
                let tenth = (int)user.Fav / 10
                group user by tenth into userGrouped
                orderby userGrouped.Key descending
                where userGrouped.Key > 5
                select userGrouped;

            // Filtering using Where clause
            var rangeFavs =
                from user in d.users
                where user.Fav > 50 && user.Fav < 80
                select new { name = user.F_name + " " + user.L_name, favNum = user.Fav };

            // Orderby Clause
            IEnumerable<User> userQuery =
                from user in d.users
                orderby user.F_name, user.L_name descending
                select user;

            // Join Clause
            var favFimlQuery =
                from user in d.users
                join film in d.films on user.Fav equals film.FilmID
                orderby user.F_name, user.L_name
                select new { user = user.F_name + " " + user.L_name, film.FilmTitle };

            // Let Clause
            string[] names = { "Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia" };
            IEnumerable<string> queryFirstNames =
                from name in names
                let firstName = name.Split(' ')[0]
                select firstName;

            // SubQueries
            var queryGroupMax =
                from student in d.students
                group student by student.Year into studentGroup
                select new {
                    Level = studentGroup.Key,
                    HighestScore =
                    (from student2 in studentGroup
                     select student2.ExamScores.Average())
                    .Max()
                };

            // Query Syntax
            // Query #1
            IEnumerable<int> numbersList = numbers1.Concat(numbers2);
            IEnumerable<int> filteringQuery =
                from number in numbersList
                where number < 3 || number > 7
                select number;

            // Query #2
            IEnumerable<int> orderingQuery =
                from num in numbersList
                where num < 3 || num > 7
                orderby num ascending
                select num;

            // Method Syntax
            // Query #1
            double average = numbers1.Average();

            // Query #2
            

            // Query #3
            IEnumerable<int> largeNumbersQuery = numbers2.Where(c => c > 15);

            // Mixed query and method syntax
            // Query #1
            int numCount1 =
                (from num in numbers1
                 where num < 3 || num > 7
                 select num).Count();
            int lambdaNumCount1 =
                numbers1.Where(x => x < 3 || x > 7).Count();
            Console.WriteLine($"Lamda Count: {lambdaNumCount1}");

            // Query #2
            IEnumerable<int> numbersQuery =
                from num in numbers1
                where num < 3 || num > 7
                select num;
            int numCount2 = numbersQuery.Count();

            IEnumerable<int> queryFactorsOfFour =
                from num in numbers1.Concat(numbers2)
                where num % 4 == 0
                select num;
            List<int> factorsofFourList = queryFactorsOfFour.ToList();

            IEnumerable<int> lambdaQueryFactor =
                numbers1.Where(x => x % 4 == 0);



            // OUTPUT!!
            foreach (var item in lambdaQueryFactor) {
                Console.WriteLine(item);
            }



            Console.Write("Press any key to continue. . .");
            Console.ReadKey();
        }

        private static int Add(int a, int b) {
            return a + b;
        }

        public static int[] getNumbers(List<User> users) {
            int[] favnumbers = new int[100];
            int i = 0;
            foreach (var item in users) {
                favnumbers[i] = item.Fav;
                i++;
            }
            return favnumbers;
        }
    }
}