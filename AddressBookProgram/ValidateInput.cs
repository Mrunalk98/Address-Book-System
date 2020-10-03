using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookProgram
{
    public class ValidateInput
    {
        public string checkPhoneNumberLength(string inputStmt)
        {
            string phoneNo = "";
            while (phoneNo.Length != 10 || !isNumber(phoneNo))
            {
                Console.Write(inputStmt);
                phoneNo = Console.ReadLine();
                if (phoneNo.Length != 10 || !isNumber(phoneNo))
                {
                    Console.WriteLine("Enter a valid Phone Number!");
                }
            }
            return phoneNo;
        }

        public string checkZipLength(string inputStmt)
        {
            string zip = "";
            while (zip.Length != 6 || !isNumber(zip))
            {
                Console.Write(inputStmt);
                zip = Console.ReadLine();
                if (zip.Length != 6 || !isNumber(zip))
                {
                    Console.WriteLine("Enter a valid Zip Code!");
                }
            }
            return zip;
        }

        public string checkEmail(string inputStmt)
        {
            string email = "";
            bool validEmail = false;
            Regex regex = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)$");

            while (!validEmail)
            {
                Console.Write(inputStmt);
                email = Console.ReadLine();
                validEmail = regex.IsMatch(email);

                if (!validEmail)
                {
                    Console.WriteLine("Enter a valid Email!");
                }
            }
            return email;
        }

        public string checkIfString(string inputStmt)
        {
            string name = "";
            while(!isString(name) || name == "")
            {
                Console.Write(inputStmt);
                name = Console.ReadLine();

                if (!isString(name))
                {
                    Console.WriteLine("Input should not contain any numbers!");
                }
            }
            return name;
        }

        public bool isString(string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (char.IsDigit(str[i]) == true)
                    return false;
            return true;
        }

        public bool isNumber(string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (char.IsDigit(str[i]) == false)
                    return false;

            return true;
        }

    }
}
