using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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

        public static void WriteToCSV(Dictionary<string, List<PersonDetails>> AddressBooks)
        {
            string path = @"D:\Practice Projects\AddressBookProgram\AddressBookProgram\Utility\ContactList.csv";
            using (var writer = new StreamWriter(path))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (KeyValuePair<string, List<PersonDetails>> book in AddressBooks)
                {
                    csvExport.WriteRecords(book.Value);
                }
            }
        }

        public static void WriteToJSON(Dictionary<string, List<PersonDetails>> AddressBooks)
        {
            string path = @"D:\Practice Projects\AddressBookProgram\AddressBookProgram\Utility\ContactList.json";
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                foreach (KeyValuePair<string, List<PersonDetails>> book in AddressBooks)
                {
                    serializer.Serialize(jw, book.Value);
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


        public static void ReadFromCSV()
        {
            string path = @"D:\Practice Projects\AddressBookProgram\AddressBookProgram\Utility\ContactList.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<PersonDetails>().ToList();
                Console.WriteLine("Read data successful from ContactList.csv");
                foreach (PersonDetails person in records)
                {
                    Console.WriteLine(person.firstName + "\t\t" + person.lastName + "\t\t" + person.address + "\t\t" + person.city + "\t" + person.state + "\t" + person.zip + "\t\t" + person.phoneNumber + "\t" + person.email);
                }                
            }
        }

        public static void ReadFromJSON()
        {
            string path = @"D:\Practice Projects\AddressBookProgram\AddressBookProgram\Utility\ContactList.json";
            IList<PersonDetails> addressData = JsonConvert.DeserializeObject<IList<PersonDetails>>(File.ReadAllText(path));
            Console.WriteLine("Read data successful from ContactList.json");
            foreach (PersonDetails person in addressData)
            {
                Console.WriteLine(person.firstName + "\t" + person.lastName + "\t" + person.address + "\t" + person.city + "\t" + person.state + "\t" + person.zip + "\t" + person.phoneNumber + "\t" + person.email);
            }
        }
    }
}
