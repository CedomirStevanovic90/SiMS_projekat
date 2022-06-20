using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMS_projekat.Model
{
    class User
    {
        public int UserId { get; set; }
        public string Jmbg { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public string UserType { get; set; }
        public bool Blocked { get; set; }
    }
}
