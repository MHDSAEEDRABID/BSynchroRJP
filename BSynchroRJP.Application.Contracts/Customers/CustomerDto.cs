using BSynchroRJP.Application.Contracts.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BSynchroRJP.Application.Contracts.Customers
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public IList<AccountDto> Accounts { get; set; }
    }
}
