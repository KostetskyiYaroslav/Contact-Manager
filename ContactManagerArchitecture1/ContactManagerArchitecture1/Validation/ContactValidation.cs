using ContactManagerArchitecture1.Abstract;
using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerArchitecture1.Validation
{
    public class ContactValidation : AbstractContactValidation
    {

        public bool ValidateEmail(string Email)
        {
            if (!String.IsNullOrWhiteSpace(Email))
            {
                if (!Email.Contains('@') || Email.Length < 5 || Email.Contains(";")  || Email.Contains("'"))
                {
                    throw new NotImplementedException("ERROR: Email is invalid!");
                }
            }

            return true;
        }

        public bool ValidateName(string FirstName)
        {
            if (FirstName.Contains('_') ||
                String.IsNullOrWhiteSpace(FirstName) ||
                FirstName.Length < 2 || FirstName.Contains(";") || FirstName.Contains("'"))
            {
                throw new NotImplementedException("ERROR: First Name is invalid!");
            }

            return true;
        }

        public bool ValidatePhone(string Phone)
        {

            if (Phone.Contains('_'))
            {
                throw new NotImplementedException("ERROR: Phone is invalid!");
            }

            return true;
        }

        public DateTime ValidateBirthday(string Year, string Month, string Day)
        {
            if (String.IsNullOrWhiteSpace(Year) && String.IsNullOrWhiteSpace(Month) && String.IsNullOrWhiteSpace(Day))
            {
                return new DateTime(01, 01, 01, 01, 01, 01, 01);

            }

            return new DateTime(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(Day), 01, 01, 01, 01);
        }

        public GroupModel ValidateGroup(string GroupName)
        {
            return new GroupModel { Name = GroupName };
        }
    }
}
