using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookTest_White_New
{
    class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData() { Name = "test" };

            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestSubGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();            
        }
    }
}
