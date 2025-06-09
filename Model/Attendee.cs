using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    class Attendee : User
    {
        public Attendee(int id, string name, string password, string contactnumber, string gender) : base(id, name, password)
        {
            ContactNumbers = contactnumber;
            Gender = gender;
        }
        public string ContactNumbers { get; set; }
        public string Gender { get; set; }

       
    }
}
