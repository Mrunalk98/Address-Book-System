using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookProgram
{
    public class File_Read_Write
    {
        public static void WriteUsingStreamWriter(Dictionary<string, List<PersonDetails>> AddressBooks)
        {
            string path = @"D:\Practice Projects\AddressBookProgram\AddressBookProgram\Utility\ContactList.txt";
            using (TextWriter tw = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, List<PersonDetails>> book in AddressBooks)
                {
                    tw.WriteLine("All Contacts in " + book.Key + " : \n");
                    tw.WriteLine("First Name \t Last Name \t Address \t City \t State \t Zip Code \t Phone Number \t Email Id");
                    foreach (PersonDetails person in book.Value)
                    {
                        tw.WriteLine(person.firstName + "\t\t" +person.lastName + "\t\t" + person.address + "\t\t" + person.city + "\t" + person.state + "\t" + person.zip + "\t\t" + person.phoneNumber + "\t" + person.email);
                    }
                    tw.WriteLine();
                }
            }

        }

        public static void ReadFromStreamReader()
        {
            string path = @"D:\Practice Projects\AddressBookProgram\AddressBookProgram\Utility\ContactList.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                String s = "";
                if (sr.ReadLine() == null)
                {
                    Console.WriteLine("No Address Books to display");
                }
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                sr.Close();
            }
        }
    }
}
