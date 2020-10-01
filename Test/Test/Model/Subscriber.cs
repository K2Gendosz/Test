using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    [Serializable]
    public class Subscriber
    {
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

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Sex { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public string HouseNumber { get; set; }
        public int Age { get; set; }
    }
}
