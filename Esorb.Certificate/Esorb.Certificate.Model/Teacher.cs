using Esorb.Certificate.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.Model.Enumerables;

namespace Esorb.Certificate.Model
{
    public class Teacher : PersistentObject
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public GenderValues Gender { get; set; }
        public Boolean IsHeadmaster { get; set; }
        public Boolean IsAdmin { get; set; }
        public string Password { get; set; } = String.Empty;
    }
}
