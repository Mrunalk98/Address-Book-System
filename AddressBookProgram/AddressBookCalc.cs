using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookProgram
{


    public class AddressBookCalc
    {

        public static ValidateInput validate = new ValidateInput();
        public static Dictionary<string, List<PersonDetails>> AddressBooks = new Dictionary<string, List<PersonDetails>>();
        public static List<PersonDetails> CurrentContact = new List<PersonDetails>();

        public void AddContacts(string bookName, string firstName, string lastName, string address, string city, string state, int zip, long phone, string email)
        {
            PersonDetails person = new PersonDetails(firstName, lastName, address, city, state, zip, phone, email);
            if (!AddressBooks.TryGetValue(bookName, out CurrentContact))
            {
                CurrentContact = new List<PersonDetails>();
                AddressBooks.Add(bookName, CurrentContact);
            }
            CurrentContact.Add(person);
            Console.WriteLine("\nContact added successfully");
        }


        public void PrintContacts ()
        {
            if (AddressBooks.Count == 0)
            {
                Console.WriteLine("No Address Book to display");
            }
            foreach (KeyValuePair<string, List<PersonDetails>> book in AddressBooks)            
            {
                if (AddressBooks[book.Key].Count == 0)
                {
                    Console.WriteLine("Address Book " + book.Key +" is empty");
                }
                else
                {
                    Console.WriteLine("All Contacts in " + book.Key + " : \n");
                    foreach (PersonDetails person in book.Value)
                    {
                        Console.WriteLine("First Name : " + person.firstName);
                        Console.WriteLine("Last Name : " + person.lastName);
                        Console.WriteLine("Address : " + person.address);
                        Console.WriteLine("City : " + person.city);
                        Console.WriteLine("State : " + person.state);
                        Console.WriteLine("Zip Code : " + person.zip);
                        Console.WriteLine("Phone Number : " + person.phoneNumber);
                        Console.WriteLine("Email : " + person.email);
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            
        }

        public void EditContact(string name)
        {
            bool personFound = false;
            foreach (KeyValuePair<string, List<PersonDetails>> book in AddressBooks)
            {
                PersonDetails person = book.Value.Find(x => x.firstName == name);
                if (person != null)
                {
                    personFound = true;
                    Console.WriteLine("Select the field you want to edit : \n1. First Name \n2. Last Name \n3. Address \n4. City \n5. State \n6. Zip Code \n7. Phone Number \n8. Email");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            person.firstName = validate.checkIfString("Enter new First Name : ");
                            Console.WriteLine("First Name updated successfully");
                            break;

                        case 2:
                            person.lastName = validate.checkIfString("Enter new Last Name : ");
                            Console.WriteLine("Last Name updated successfully");
                            break;

                        case 3:
                            Console.Write("Enter new Address: ");
                            person.address = Console.ReadLine();
                            Console.WriteLine("Address updated successfully");
                            break;

                        case 4:
                            person.city = validate.checkIfString("Enter new City: ");
                            Console.WriteLine("City updated successfully");
                            break;

                        case 5:
                            person.state = validate.checkIfString("Enter new State: ");
                            Console.WriteLine("State updated successfully");
                            break;

                        case 6:
                            person.zip = Convert.ToInt32(validate.checkZipLength("Enter new Zip Code: "));
                            Console.WriteLine("Zip Code updated successfully");
                            break;

                        case 7:
                            person.phoneNumber = Convert.ToInt64(validate.checkPhoneNumberLength("Enter new Phone Number: "));
                            Console.WriteLine("Phone Number updated successfully");
                            break;

                        case 8:
                            person.email = validate.checkEmail("Enter new Email: ");
                            Console.WriteLine("Email updated successfully");
                            break;
                    }
                }
            }

            if (!personFound)
            {
                Console.WriteLine("Contact does not exist");
            }
            
        }

        public void DeleteContact(string name)
        {
            bool personFound = false;
            foreach (KeyValuePair<string, List<PersonDetails>> book in AddressBooks)
            {
                PersonDetails person = book.Value.Find(x => x.firstName == name);
                if (person != null)
                {
                    book.Value.Remove(person);
                    Console.WriteLine("Contact deleted successfully");
                    personFound = true;
                }

            }
            if (!personFound)
            {
                Console.WriteLine("Contact does not exist");
            }

        }

        public void SearchNameByCity(string city)
        {
            bool personFound = false;
            Console.WriteLine("Name of persons in " + city + " : ");
            Console.WriteLine("First Name" + "\tLast Name");
            foreach (KeyValuePair<string, List<PersonDetails>> book in AddressBooks)
            {
                PersonDetails person = book.Value.Find((p => p.city == city));
                if (person != null)
                {
                    Console.WriteLine(person.firstName + "\t\t" + person.lastName);
                    personFound = true;
                }
            }
            if (!personFound)
                Console.WriteLine("No person found in " + city);

        }

        public void SearchNameByState(string state)
        {
            bool personFound = false;

            Console.WriteLine("Name of persons in " + state + " : ");
            Console.WriteLine("First Name" + "\tLast Name");
            foreach (KeyValuePair<string, List<PersonDetails>> book in AddressBooks)
            {
                PersonDetails person = book.Value.Find((p => p.state == state));
                if (person != null)
                {
                    Console.WriteLine(person.firstName + "\t\t" + person.lastName);
                    personFound = true;
                }
            }
            if (!personFound)
                Console.WriteLine("No person found in " + state);

        }

    }
}
