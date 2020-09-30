using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProgram
{
    public class PersonDetails
    {
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public int zip;
        public int phoneNumber;
        public string email;

        public PersonDetails(string FIRST_NAME, string LAST_NAME, string ADDRESS, string CITY, string STATE, int ZIP, int PHONE_NO, string EMAIL)
        {
            this.firstName = FIRST_NAME;
            this.lastName = LAST_NAME;
            this.address = ADDRESS;
            this.city = CITY;
            this.state = STATE;
            this.zip = ZIP;
            this.phoneNumber = PHONE_NO;
            this.email = EMAIL;

        }
    }
}
