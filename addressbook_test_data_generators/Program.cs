﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Threading.Tasks;
using WebAddressbookTests;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string datatype = args[1];
            string filename = args[2];
            //StreamWriter writer = new StreamWriter(args[1]);
            string format = args[3];

            if (datatype == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });

                }

                //if (format == "excel")
                //{
                //    // WriteGroupsToExcelFile(groups, filename);
                //}
                //else
                //{
                //    StreamWriter writer = new StreamWriter(filename);

                //    if (format == "csv")
                //    {
                //        WriteGroupsToCsvFile(groups, writer);
                //    }
                //    else if (format == "xml")

                StreamWriter writer = new StreamWriter(filename);
                if (format == "xml")
                {
                        WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                        WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                        System.Console.Out.Write("Unrecognized format " + format);
                }

                writer.Close();
                
            }
            else if (datatype == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
                }

                StreamWriter writer = new StreamWriter(filename);
                if (format == "xml")
                {
                    WriteContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }

                writer.Close();
            }
            else
            {
                System.Console.Out.Write("Unrecognized datatype " + datatype);
            }

           

           

        }

        private static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        private static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                    group.Name, group.Header, group.Footer));

            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        //private static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        //{
        //    Excel.Application app = new Excel.Application();
        //    app.Visible = true;
        //    Excel.Workbooks wb = app.Workbooks.Add();
        //    Excel.Worksheet sheet = wb.ActiveSheet;
        //    //sheet.Cells[1, 1] = "test";

        //    int row = 1;
        //    foreach (GroupData group in groups)
        //    {
        //        sheet.Cells[row, 1] = group.Name;
        //        sheet.Cells[row, 2] = group.Header;
        //        sheet.Cells[row, 3] = group.Footer;
        //        row++;
        //    }

        //    string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
        //    File.Delete(fullPath);
        //    wb.SaveAs(fullPath);

        //    wb.Close();
        //    app.Visible = false;
        //    app.Quit();
        //}
    }
}

