using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.TableItems;
using TestStack.White.WindowsAPI;


namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact Editor";

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        internal void Add(ContactData newContact)
        {
            Window dialogue = OpenContactsDialogue();
            TextBox lastname = (TextBox) dialogue.Get(SearchCriteria.ByAutomationId("ueLastNameAddressTextBox"));
            lastname.Enter(newContact.LastName);
            SaveAndCloseContactsDialogue(dialogue);
        }

        internal List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            Window dialogue = manager.MainWindow;
            Table table = dialogue.Get<Table>("uxAddressGrid");
            
            foreach (var row in table.Rows)
            {
                list.Add(new ContactData()
                {
                    LastName = row.Cells.Find( cell => cell.Name.StartsWith("Last name ")).Value.ToString()
                });
            }
            
            return list;
        }

        private void SaveAndCloseContactsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxSaveAddressButton").Click();
        }

        private Window OpenContactsDialogue()
        {
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            return manager.MainWindow.ModalWindow(CONTACTWINTITLE);
            
        }

        internal void Remove(ContactData toBeRemoved)
        {
            Window dialogue = manager.MainWindow;
            Table table = dialogue.Get<Table>("uxAddressGrid");
            foreach (var row in table.Rows)
            {
                if (row.Cells.Find(cell => cell.Name.StartsWith("Last name ")).Value.ToString() == toBeRemoved.LastName)
                {
                    row.Focus();
                }
            }
            //(toBeRemoved.LastName)).Focus();
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            dialogue = dialogue.MessageBox("Question");
            dialogue.Get<Button>(SearchCriteria.ByText("Yes")).Click();
        }
    }
}
