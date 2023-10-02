using BSynchroRJP.Application.Contracts.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Application.Contracts.Accounts
{
    public class AccountDto
    {
        public Guid Id { get; set; }

        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal Balance { get;  set; }
        public DateTime? LastTransactionDate { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
