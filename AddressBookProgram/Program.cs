using System;

namespace AddressBookProgram
{
    class Program
    {
        public static AddressBookCalc addressBook = new AddressBookCalc();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!\n");
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
            var zip = Console.ReadLine();
            Console.Write("Enter Phone Number : ");
            var phone = Console.ReadLine();
            Console.Write("Enter Email : ");
            var email = Console.ReadLine();
        }
    }
}
