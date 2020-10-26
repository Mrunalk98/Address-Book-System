﻿using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                    tw.WriteLine("First Name \t\t Last Name \t\t Address \t\t City \t\t State \t\t Zip Code \t\t Phone Number \t\t Email Id");
                    foreach (PersonDetails person in book.Value)
                    {
                        tw.WriteLine(person.firstName + "\t\t\t" +person.lastName + "\t\t\t" + person.address + "\t\t\t" + person.city + "\t\t" + person.state + "\t\t" + person.zip + "\t\t\t" + person.phoneNumber + "\t\t\t" + person.email);
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
    }
}