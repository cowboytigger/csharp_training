using System;
using NUnit.Framework;


namespace addressbook_tests_white
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            
        }
    }
}