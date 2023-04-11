using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public int NaturalPersonId { get; set; }

        public int LegalPersonId { get; set; }

        public DateTime Date { get; set; }

        public int Contract_sum { get; set; }

        public string Status { get; set; }
    }
}
