using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

    }
}
