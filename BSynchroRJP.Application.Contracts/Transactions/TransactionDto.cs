using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Application.Contracts.Transactions
{
    public class TransactionDto
    {
        public Guid Id { get; set; }

        public decimal ammount { get; set; }
        public DateTime TransactionDate { get; set; }

        public Guid AccountId { get; set; }
    }
}
