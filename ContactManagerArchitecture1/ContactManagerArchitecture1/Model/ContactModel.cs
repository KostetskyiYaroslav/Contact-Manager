using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerArchitecture1.Model
{
    public class ContactModel
    {
        public int Id { set; get; }

        public string Phone { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string Email { set; get; }

        public DateTime Birthday { set; get; }

        public string Comment { set; get; }

        public GroupModel Group { set; get; }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6}",this.Id,this.Phone,this.FirstName, this.LastName, this.Email, this.Birthday, this.Comment); ;
        }
    };
}
