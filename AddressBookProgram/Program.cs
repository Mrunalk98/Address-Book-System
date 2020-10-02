using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddressBookProgram
{
    class Program
    {
        public static AddressBookCalc addressBook = new AddressBookCalc();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            int option = 0;
            while(option != 5)
            {
                Console.WriteLine("\nSelect an option : \n1. Display Address Book \n2. Add Contact \n3. Edit Contact \n4. Delete Contact \n5. Exit \n");
                option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (option)
                {
                    case 1:
                        addressBook.PrintContacts();
                        break;

                    case 2:
                        ToAddContact();
                        break;

                    case 3:
                        ToEditContact();
                        break;

                    case 4:
                        ToDeleteContact();
                        break;

                    default:
                        break;

                }
            }            
        }

        private static void ToAddContact()
        {
            Console.WriteLine("Enter the name of Address Book : ");
            string bookName = Console.ReadLine();
            Console.Write("Enter First Name : ");
            var firstName = Console.ReadLine();
            Console.Write("Enter Last Name : ");
            var lastName = Console.ReadLine();
            Console.Write("Enter Address : ");
            var address = Console.ReadLine();
            Console.Write("Enter City : ");
            var city = Console.ReadLine();
            Console.Write("Enter State : ");
            var state = Console.ReadLine();
            int zip = Convert.ToInt32(addressBook.checkZipLength());
            long phone = Convert.ToInt64(addressBook.checkPhoneNumberLength());
            var email = addressBook.checkEmail();

            addressBook.AddContacts(bookName, firstName, lastName, address, city, state, zip, phone, email);
        }

        private static void ToEditContact()
        {
            Console.Write("Enter the first name of the person : ");
            var name = Console.ReadLine();
            addressBook.EditContact(name);
        }

        private static void ToDeleteContact()
        {
            Console.Write("Enter the first name of the person : ");
            var name = Console.ReadLine();
            addressBook.DeleteContact(name);
        }

    }
}
