using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;



namespace AddressBookTest_White_New
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            Application app = Application.Launch(@"d:\Project\C#_Cources\software\desktop\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITLE);

            Groups = new GroupHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }

        public Window MainWindow { get; private set; }
        public GroupHelper Groups { get; set; }
    }
}
