using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookTest_White_New
{
    class GroupRemovingTests : TestBase
    {
        [Test]
        public void TestGroupRemovingWithoutSubgroups()
        {
            int index = 0; // index of group to delete
            List<GroupData> oldList = app.Groups.GetGroupList();

            if (oldList.Count == 0)
            {
                app.Groups.Add(new GroupData() { Name = "newGroup" });
                oldList = app.Groups.GetGroupList();
            }
            GroupData oldGroup = oldList[index];

            app.Groups.RemoveGroupOnly(index);

            oldList.RemoveAt(index);
            Assert.AreEqual(oldList.Count, app.Groups.GetGroupList().Count);

            List<GroupData> newList = app.Groups.GetGroupList();

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);            
        }

        [Test]
        public void TestGroupRemovingCancel()
        {
            int index = 0;
            List<GroupData> oldList = app.Groups.GetGroupList();
            if (oldList.Count == 0)
            {
                GroupData newData = new GroupData(){Name = "newData"};
                app.Groups.Add(newData);
                oldList.Add(newData);
            }
            app.Groups.CancelRemovingGroup(index);

            List<GroupData> newList = app.Groups.GetGroupList();
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void TestGroupRemovingWithSubgroups()
        {
            int index = 0;
            List<GroupData> oldList = app.Groups.GetGroupList();
            if (oldList.Count == 0)
            {
                GroupData newData = new GroupData() { Name = "newData" };
                app.Groups.Add(newData);
                oldList.Add(newData);
            }
            GroupData oldData = oldList[index];

            app.Groups.RemoveGroupWithSubGroups(index);

            //// 
            //oldList.RemoveAt(index);
            //Assert.AreEqual(oldList.Count, app.Groups.GetGroupList().Count);


            //List<GroupData> newList = app.Groups.GetGroupList();

            //oldList.Sort();
            //newList.Sort();
            //Assert.AreEqual(oldList, newList);    
        }
    }
}
