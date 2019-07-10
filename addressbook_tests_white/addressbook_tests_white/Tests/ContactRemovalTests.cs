using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void TestContactRemove()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.Remove(toBeRemoved);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Remove(toBeRemoved); 
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
