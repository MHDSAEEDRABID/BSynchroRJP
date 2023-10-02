using BSynchroRJP.Domain.Base;
using BSynchroRJP.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using BSynchroRJP.Domain.Customers;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSynchroRJP.Domain.Accounts
{
    public partial class Account : BaseEntity<Guid>
    {
        [Required]
        [MaxLength(9)]
        public string AccountNumber { get; private set; }
        public string AccountHolder { get; private set; }
        [Required]
        public decimal Balance { get; private set; }
        public DateTime? LastTransactionDate { get; private set; }

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; private set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Transaction> Transactions { get; private set; }

        protected Account() { }


        private Account(Guid id ,string accountNumber , string accountHolder , decimal balance) : base (id)
        {
            this.Transactions = new List<Transaction>();
            AccountHolder = accountHolder;
            AccountNumber = accountNumber;
            Balance = balance;
        }


        public static Account Create(string accountNumber, string accountHolder, decimal balance)
        {
            if (string.IsNullOrEmpty(accountNumber) || accountNumber.Length != 9)
                throw new ArgumentException("Account Number Should be 9 char length");

            return new Account(Guid.NewGuid(),accountNumber,accountHolder, balance);
        }

        public void AddTransaction(decimal amount)
        {
            this.Balance += amount;

            var transaction = Transaction.Create(amount, this.Id, this);
            this.Transactions.Add(transaction);

            this.LastTransactionDate = transaction.TransactionDate;
        }
    }
}
