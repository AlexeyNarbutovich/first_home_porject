using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;

namespace AddressBookTest_White_New
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected Application app;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;            
        }
    }
}
