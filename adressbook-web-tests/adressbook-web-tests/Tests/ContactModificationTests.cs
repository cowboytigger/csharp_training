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
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            ContactData newData = new ContactData("Harry", "Potter");
            app.Contacts.Modify(0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0] = newData;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(oldContacts, newContacts);
                }
            }


        }   
    }
}
