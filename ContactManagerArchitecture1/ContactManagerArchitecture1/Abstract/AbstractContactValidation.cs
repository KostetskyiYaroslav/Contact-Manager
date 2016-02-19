using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerArchitecture1.Abstract
{
    public interface AbstractContactValidation
    {
        bool ValidatePhone(string Phone);
        
        bool ValidateName(string Phone);

        bool ValidateEmail(string Phone);

        DateTime ValidateBirthday(string Year, string Month, string Day);

        GroupModel ValidateGroup(string GroupName);
    }
}
