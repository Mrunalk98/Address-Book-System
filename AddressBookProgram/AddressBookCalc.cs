using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookProgram
{


    public class AddressBookCalc
    {
        public static Dictionary<string, List<PersonDetails>> AddressBooks = new Dictionary<string, List<PersonDetails>>();

        public void AddContacts(string bookName, string firstName, string lastName, string address, string city, string state, int zip, long phone, string email)
        {
            PersonDetails person = new PersonDetails(firstName, lastName, address, city, state, zip, phone, email);
            List<PersonDetails> CurrentContact = new List<PersonDetails>();
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
                            Console.Write("Enter First Name : ");
                            person.firstName = Console.ReadLine();
                            Console.WriteLine("First Name updated successfully");
                            break;

                        case 2:
                            Console.Write("Enter Last Name : ");
                            person.lastName = Console.ReadLine();
                            Console.WriteLine("Last Name updated successfully");
                            break;

                        case 3:
                            Console.Write("Enter Address: ");
                            person.address = Console.ReadLine();
                            Console.WriteLine("Address updated successfully");
                            break;

                        case 4:
                            Console.Write("Enter City: ");
                            person.city = Console.ReadLine();
                            Console.WriteLine("City updated successfully");
                            break;

                        case 5:
                            Console.Write("Enter State: ");
                            person.state = Console.ReadLine();
                            Console.WriteLine("State updated successfully");
                            break;

                        case 6:
                            Console.Write("Enter Zip Code: ");
                            person.zip = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Zip Code updated successfully");
                            break;

                        case 7:
                            person.phoneNumber = Convert.ToInt64(checkPhoneNumberLength());
                            Console.WriteLine("Phone Number updated successfully");
                            break;

                        case 8:
                            Console.Write("Enter Email: ");
                            person.email = checkEmail();
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

        public string checkPhoneNumberLength()
        {
            string phoneNo = "";
            while (phoneNo.Length != 10)
            {
                Console.Write("Enter Phone Number: ");
                phoneNo = Console.ReadLine();
                if (phoneNo.Length != 10)
                {
                    Console.WriteLine("Enter a valid Phone Number!");
                }
            }
            return phoneNo;
        }

        public string checkZipLength()
        {
            string zip = "";
            while (zip.Length != 6)
            {
                Console.Write("Enter Zip Code: ");
                zip = Console.ReadLine();
                if (zip.Length != 6)
                {
                    Console.WriteLine("Enter a valid Zip Code!");
                }
            }
            return zip;
        }

        public string checkEmail()
        {
            string email = "";
            bool validEmail = false;
            Regex regex = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)$");

            while (!validEmail)
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
                validEmail = regex.IsMatch(email);

                if (!validEmail)
                {
                    Console.WriteLine("Enter a valid Email!");
                }
            }
            return email;
        }


    }
}
