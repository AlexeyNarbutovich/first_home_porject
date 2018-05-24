using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace AddressBookTest_White_New
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialog = OpenGroupsDialog();
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach(TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                    {
                        Name = item.Text
                    });
            }            
            CloseGroupDialog(dialog);

            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox =  (TextBox)dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupDialog(dialog);
        }

        public void CancelRemovingGroup(int index)
        {
            Window dialog = OpenGroupsDialog();           
            Window subDialog = GetSubDialog(dialog, index);
            subDialog.Get<RadioButton>("uxDeleteGroupsOnlyRadioButton").Select();
            subDialog.Get<Button>("uxCancelAddressButton").Click();
            CloseGroupDialog(dialog);
        }

        public void RemoveGroupOnly(int index)
        {
            Window dialog = OpenGroupsDialog();
            Window subDialog = GetSubDialog(dialog, index);
            subDialog.Get<RadioButton>("uxDeleteGroupsOnlyRadioButton").Select();
            subDialog.Get<Button>("uxOKAddressButton").Click();
            CloseGroupDialog(dialog);
        }

        public void RemoveGroupWithSubGroups(int index)
        {
            Window dialog = OpenGroupsDialog();
            Window subDialog = GetSubDialog(dialog, index);
            subDialog.Get<RadioButton>("uxDeleteAllRadioButton").Select();
            subDialog.Get<Button>("uxOKAddressButton").Click();
            CloseGroupDialog(dialog);
        }

        private void CloseGroupDialog(Window dialog)
        {
            dialog.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialog()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
        
        private Window GetSubDialog(Window dialog, int index)
        {            
            SelectGroupToDelete(dialog, index);
            dialog.Get<Button>("uxDeleteAddressButton").Click();
            Window subDialog = dialog.ModalWindow("Delete group");
            return subDialog;
        }

        private void SelectGroupToDelete(Window dialog, int index)
        {
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            TreeNode item = root.Nodes[index];
            item.Select();            
        }        
    }
}
