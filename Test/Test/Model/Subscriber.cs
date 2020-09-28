using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    class Subscriber
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
            this.firstName = firstName;
            this.secondName = secondName;
            this.sex = sex;
            this.city = city;
            this.postalCode = postalCode;
            this.streetAddress = streetAddress;
            this.houseNumber = houseNumber;
            this.age = age;
        }
    }
}
