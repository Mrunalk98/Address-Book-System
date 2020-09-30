using System;

namespace AddressBookProgram
{
    class Program
    {
        public static AddressBookCalc addressBook = new AddressBookCalc();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            int option = 0;
            while(option != 2)
            {
                Console.WriteLine("\nSelect an option : \n1. Add Contact \n2.Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ToAddContact();
                        break;
                    case 2:
                        break;

                }
            }            
        }

        private static void ToAddContact()
        {
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
            Console.Write("Enter Zip Code: ");
            var zip = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Phone Number : ");
            var phone = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Email : ");
            var email = Console.ReadLine();

            addressBook.AddContacts(firstName, lastName, address, city, state, zip, phone, email);
        }
    }
}
