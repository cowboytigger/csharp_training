using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allemails;

        public ContactData(string firstname, string lastname)
        {
           Firstname = firstname;
           Lastname = lastname;
            
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

           return Firstname == other.Firstname
               && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname + " " + Lastname).GetHashCode();
             
        }

        public override string ToString()
        {
            return "name=" + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname == other.Lastname)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Id { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone)).Trim();
                }
            }
            set { allPhones = value; }
        }

        private string Cleanup(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }

            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allemails != null)
                {
                    return allemails;
                }
                else
                {
                    return (Cleanup(Email) + Cleanup(Email2) + Cleanup(Email3)).Trim();
                }
            }
            set { allemails = value; }

        }

    }
}
