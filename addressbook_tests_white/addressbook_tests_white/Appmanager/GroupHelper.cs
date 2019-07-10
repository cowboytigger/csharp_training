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
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper: HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach ( TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text

                });
            }
            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textbox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textbox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);

        }

        internal void Remove(GroupData toBeRemoved)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get(SearchCriteria.ByText(toBeRemoved.Name)).Focus();
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            dialogue = dialogue.ModalWindow("Delete group");
            // в окне ничего не делаем
            dialogue.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialogue(manager.MainWindow.ModalWindow(GROUPWINTITLE));
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

    }
}