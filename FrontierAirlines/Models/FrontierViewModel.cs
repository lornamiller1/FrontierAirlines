using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontierAirlines.Models
{
    public class FrontierViewModel
    {
        public List<Accounts> CurrentAccounts { get; set; }
        public List<Accounts> PastDueAccounts { get; set; }
        public List<Accounts> InactiveAccounts { get; set; }
    }
}
