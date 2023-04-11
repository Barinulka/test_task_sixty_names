using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class LegalPerson
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Inn { get; set; }

        public int Ogrn { get; set; }

        public string Country { get; set; } 

        public string City { get; set; }    

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }   
    }
}
