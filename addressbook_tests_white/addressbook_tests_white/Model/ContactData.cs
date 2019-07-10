using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string LastName { get; set; }

        public int CompareTo(ContactData other)
        {
            return this.LastName.CompareTo(other.LastName);
        }

        public bool Equals(ContactData other)
        {
            return this.LastName.Equals(other.LastName);
        }
    }
}

