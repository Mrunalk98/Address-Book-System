using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("\nContact added successfully");
        }

        public void PrintContacts ()
        {
            if (Contacts.Count == 0)
            {
                Console.WriteLine("Address Book is empty");
            }
            foreach (PersonDetails person in Contacts)
            {
                Console.WriteLine("First Name: " + person.firstName);
                Console.WriteLine("Last Name: " + person.lastName);
                Console.WriteLine("Address: " + person.address);
                Console.WriteLine("City: " + person.city);
                Console.WriteLine("State " + person.state);
                Console.WriteLine("Zip Code: " + person.zip);
                Console.WriteLine("Phone Number: " + person.phoneNumber);
                Console.WriteLine("Email: " + person.email);
                Console.WriteLine();
            }
        }

        public void EditContact(string name)
        {
            PersonDetails person = Contacts.Find(x => x.firstName == name);
            if (person == null)
            {
                Console.WriteLine("Contact does not exist");
            }
            else
            {
                Console.WriteLine("Select the field you want to edit : \n1. First Name \n2. Last Name \n3. Address \n4. City \n5. State \n6. Zip Code \n7. Phone Number \n8. Email");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the new First Name : ");
                        person.firstName = Console.ReadLine();
                        Console.WriteLine("First Name updated successfully");
                        break;

                    case 2:
                        Console.Write("Enter the new Last Name : ");
                        person.lastName = Console.ReadLine();
                        Console.WriteLine("Last Name updated successfully");
                        break;

                    case 3:
                        Console.Write("Enter the new Address: ");
                        person.address = Console.ReadLine();
                        Console.WriteLine("Address updated successfully");
                        break;

                    case 4:
                        Console.Write("Enter the new City: ");
                        person.city = Console.ReadLine();
                        Console.WriteLine("City updated successfully");
                        break;

                    case 5:
                        Console.Write("Enter the new State: ");
                        person.state = Console.ReadLine();
                        Console.WriteLine("State updated successfully");
                        break;

                    case 6:
                        Console.Write("Enter the new Zip Code: ");
                        person.zip = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Zip Code updated successfully");
                        break;

                    case 7:
                        Console.Write("Enter the new Phone Number: ");
                        person.phoneNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Phone Number updated successfully");
                        break;

                    case 8:
                       Console.Write("Enter the new Email: ");
                        person.email = Console.ReadLine();
                        Console.WriteLine("Email updated successfully");
                        break;
                }
            }
            
        }


    }
}
