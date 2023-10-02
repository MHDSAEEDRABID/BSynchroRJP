using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Application.Contracts.Accounts
{
    public class CreateAccountDto
    {
        public decimal InitialCredit { get; set; }
        public Guid CustomerId { get; set; }

    }
}
