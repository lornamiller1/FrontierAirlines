using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontierAirlines.Models
{
    public class Accounts
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        public string PhoneNumber { get; set; }

       // [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal AmountDue { get; set; }
        public int AccountStatusId { get; set; }
    }
}
