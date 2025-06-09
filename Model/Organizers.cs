using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    class Organizers : User
    {
        public Organizers(int id, string name, string password, string contactnumber, string email) : base(id, name, password)
        {
            ContactNumbers = contactnumber;
            Email = email;
        }

        public string ContactNumbers { get; set; }
        public string Email { get; set; }

    }
    
}
