using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsCreationTest : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> groups = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new ContactData(GenerateRandomString(15), GenerateRandomString(15)));
            }
            return groups;
        }


       
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
           // ContactData contact = new ContactData("Amanda", "Rose");

            List<ContactData> oldContacts = app.Contacts.GetContactList();
                       
            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
        }

       

    }
}
