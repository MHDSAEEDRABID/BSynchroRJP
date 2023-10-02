using BSynchroRJP.Domain.Accounts;
using BSynchroRJP.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Domain.Customers
{
    public partial class Customer : BaseEntity<Guid>
    {
        public string Name { get; private set; }
        public string SurName { get; private set; }

        public virtual ICollection<Account> Accounts { get; private set; }

        private Customer(Guid id, string name , string SurName , ICollection<Account> account) : base(id)
        {
            this.Name = name;
            this.SurName = SurName;
            Accounts = account;
        }

        public static Customer Create (string name , string surName , ICollection<Account> account)
        {
            return new Customer(Guid.NewGuid(),name , surName , account);
        }

        protected Customer()
        {
            
        }


        public Account AddAccount(string accountNumber , string accountHolder)
        {
            var account = Account.Create(accountNumber, accountHolder, 0);
            this.Accounts.Add(account);
            return account;
        }
    }
}
