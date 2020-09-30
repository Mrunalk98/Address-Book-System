using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProgram
{


    public class AddressBookCalc
    {
        public static List<PersonDetails> Contacts = new List<PersonDetails>();

        public void AddContacts(string firstName, string lastName, string address, string city, string state, int zip, int phone, string email)
        {
            PersonDetails person = new PersonDetails(firstName, lastName, address, city, state, zip, phone, email);
            Contacts.Add(person);
            Console.WriteLine("Contact added successfully");
        }

    }
}
