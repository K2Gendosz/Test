using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{   [Serializable]
    public class Subscriber
    {
        private string firstName;
        private string secondName;
        private string sex;
        private string city;
        private string postalCode;
        private string streetAddress;
        private string houseNumber;
        private int age;

        public Subscriber(string firstName, string secondName, string sex, string city, 
            string postalCode, string streetAddress, string houseNumber, int age)
        {
            
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Sex = sex;
            this.City = city;
            this.PostalCode = postalCode;
            this.StreetAddress = streetAddress;
            this.HouseNumber = houseNumber;
            this.Age = age;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string Sex { get => sex; set => sex = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string StreetAddress { get => streetAddress; set => streetAddress = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        public int Age { get => age; set => age = value; }
    }
}
