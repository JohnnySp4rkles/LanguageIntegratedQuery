using System;
using System.Collections.Generic;

namespace LanguageIntegratedQuery
{
    internal class User
    {
        static Random r = new Random();
        public User(int id, string f_name, string l_name, string email, char gender, int fav)
        {
            this.ID = id;
            this.F_name = f_name;
            this.L_name = l_name;
            this.Email = email;
            this.Gender = gender;
            this.Fav = fav;
            this.Age = getRandomAge();
            this.AgeGroup = classify(this.Age);
        }
        public int ID { get; set; }
        public string F_name { get; set; }
        public string L_name { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public int Fav { get; set; }
        public int Age { get; set; }
        public string AgeGroup { get; set; }

        public static int getRandomAge()
        {
            return r.Next(15,56);
        }

        public string classify(int age)
        {
            if (age >= 15 && age < 18)
                return "Teenager";
            else if (age >= 18 && age < 30)
                return "Young Adult";
            else if (age >= 30 && age < 50)
                return "Adult";
            else
                return "Senior";
        }
    }
}