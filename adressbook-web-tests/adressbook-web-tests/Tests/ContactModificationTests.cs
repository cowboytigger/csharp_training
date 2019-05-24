using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Harry", "Potter");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(1, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Name = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);

        }   
    }
}
