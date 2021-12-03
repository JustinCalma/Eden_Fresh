using System;
using System.Data.SqlClient;


namespace EdenFresh
{
    class User
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }


        public User(string firstName, string lastName, string email, string password, string address, string city, string state, int zipcode)
        {
            Random rnd = new Random();
            int value = rnd.Next(100000, 999999);
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.userId = value;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
        }

    }
}