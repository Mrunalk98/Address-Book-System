using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProgram
{
    public class PersonDetails
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public long phoneNumber { get; set; }
        public string email { get; set; }

        public PersonDetails(string FIRST_NAME, string LAST_NAME, string ADDRESS, string CITY, string STATE, int ZIP, long PHONE_NO, string EMAIL)
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
