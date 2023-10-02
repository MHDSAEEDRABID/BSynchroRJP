using BSynchroRJP.Application.Contracts.Accounts;
using BSynchroRJP.Infrastructure.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Application.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly ICustomerRepository _customerRepository;

        public AccountService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task OpenningANewCurrentAccount(CreateAccountDto input)
        {
            var customer =  await _customerRepository.GetAsync(x => x.Id == input.CustomerId);

            Random rnd = new Random(652478653);
            var account = customer.AddAccount(rnd.Next(1, 1000000000).ToString(),customer.Name);
          
            if(input.InitialCredit != 0)
            {
                account.AddTransaction(input.InitialCredit);
            }

            await _customerRepository.UpdateAsync(customer);
        }
    }
}
