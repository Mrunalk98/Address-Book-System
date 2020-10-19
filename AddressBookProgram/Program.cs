using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AddressBookProgram
{
    class Program
    {
        public static AddressBookCalc addressBook = new AddressBookCalc();
        public static ValidateInput validate = new ValidateInput();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            int option = 0;
            while(option != 7)
            {
                Console.WriteLine("\nSelect an option : \n1. Display Address Book \n2. Add Contact \n3. Edit Contact \n4. Delete Contact \n5. Search By City \n6. Search By State \n7. Exit");
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

                    case 5:
                        ToSearchCity();
                        break;

                    case 6:
                        ToSearchState();
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
            var firstName = validate.checkIfString("Enter First Name : ");
            var lastName = validate.checkIfString("Enter Last Name : ");
            Console.Write("Enter Address : ");
            var address = Console.ReadLine();
            var city = validate.checkIfString("Enter City : ");
            var state = validate.checkIfString("Enter State : ");
            int zip = Convert.ToInt32(validate.checkZipLength("Enter Zip Code: "));
            long phone = Convert.ToInt64(validate.checkPhoneNumberLength("Enter Phone Number: "));
            var email = validate.checkEmail("Enter Email: ");

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

        private static void ToSearchCity()
        {
            Console.Write("Enter the city name : ");
            var city = Console.ReadLine();
            addressBook.SearchNameByCity(city);
        }

        private static void ToSearchState()
        {
            Console.Write("Enter the state name : ");
            var state = Console.ReadLine();
            addressBook.SearchNameByState(state);
        }
    }
}
