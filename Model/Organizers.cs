using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    class Organizers : User
    {
        public Organizers( string name, string password, string contactnumber, string email, string gender) : base( name, password)
        {
            ContactNumbers = contactnumber;
            Email = email;
            Gender = gender;
        }

        public string ContactNumbers { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

    }
    
}
