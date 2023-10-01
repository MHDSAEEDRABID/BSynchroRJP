using BSynchroRJP.Domain.Accounts;
using BSynchroRJP.Domain.Base;
using BSynchroRJP.Domain.Shared.Transactions.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Domain.Transactions
{
    public class Transaction : BaseEntity<Guid>
    {
        public DateTime TransactionDate { get; private set; }

        public decimal Amount { get; private set; }

        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; private set; }

        public virtual Account Account { get; private set; }


        private Transaction(Guid id, DateTime transactionDate , decimal ammount , Guid accountId, Account account = null) : base(id) 
        {
            this.TransactionDate = transactionDate;
            this.Amount = ammount;
            this.AccountId = accountId;

            if (account is not null)
                this.Account = account;
        }

        internal static Transaction Create(decimal amount , Guid accountId , Account account)
        {
            return new Transaction (Guid.NewGuid() , DateTime.Now, amount , accountId , account);
        }
    }
}
