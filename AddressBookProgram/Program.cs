﻿using System;
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
                Console.WriteLine("\nSelect an option : \n1. Display Address Book \n2. Add Contact \n3. Edit Contact \n4. Delete Contact \n5. Search Contact \n6. Sort Contacts \n7. Exit");
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
                        Search();
                        break;

                    case 6:
                        addressBook.DisplaySortedContacts();
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

        private static void Search()
        {
            Console.WriteLine("Select an option : \n1. Search By City \n2. Search By State \n3. Get Number of persons in City \n4. Get Number of persons in State");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    ToSearchCity();
                    break;

                case 2:
                    ToSearchState();
                    break;

                case 3:
                    GetCountOfPersonByCity();
                    break;

                case 4:
                    GetCountOfPersonByState();
                    break;

                default:
                    break;
            }
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

        private static void GetCountOfPersonByCity()
        {
            foreach (KeyValuePair<string, List<string>> cityBook in AddressBookCalc.CityBook)
            {
                Console.WriteLine("City : " + cityBook.Key + "\t\tNumber of persons : " + cityBook.Value.Count);
            }
        }

        private static void GetCountOfPersonByState()
        {
            foreach (KeyValuePair<string, List<string>> stateBook in AddressBookCalc.StateBook)
            {
                Console.WriteLine("State : " + stateBook.Key + "\t\tNumber of persons : " + stateBook.Value.Count);
            }
        }


    }
}
