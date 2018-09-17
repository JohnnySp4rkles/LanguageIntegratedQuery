namespace LanguageIntegratedQuery
{
    internal class User
    {
        public User(int id, string f_name, string l_name, string email, char gender)
        {
            this.ID = id;
            this.F_name = f_name;
            this.L_name = l_name;
            this.Email = email;
            this.Gender = gender;
        }
        public int ID { get; set; }
        public string F_name { get; set; }
        public string L_name { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }

    }
}