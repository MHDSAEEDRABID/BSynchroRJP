using BSynchroRJP.Application.Contracts.Accounts;
using BSynchroRJP.Application.Contracts.Customers;
using BSynchroRJP.Application.Contracts.Transactions;
using BSynchroRJP.Domain.Customers;
using BSynchroRJP.Infrastructure.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto>  GetCustomerInfo(Guid id)
        {
            var customer = await _customerRepository.GetByIdWithDetailsAsync(id);
            return MapToCustomerDto(customer);
        }

        private CustomerDto MapToCustomerDto(Customer customer)
        {
            // we can Use Auto Mapper Library
            return new CustomerDto
            {
                Name = customer.Name,
                SurName = customer.SurName,
                Accounts = customer.Accounts.Select(x => new
                                                        AccountDto
                {
                    AccountHolder = x.AccountHolder,
                    AccountNumber = x.AccountNumber,
                    Balance = x.Balance,
                    Id = x.Id,
                    LastTransactionDate = x.LastTransactionDate,
                    Transactions = x.Transactions.Select(x => new
                                                                TransactionDto
                    {
                        Id = x.Id,
                        ammount = x.Amount,
                        AccountId = x.AccountId,
                        TransactionDate = x.TransactionDate
                    }).ToList()
                }).ToList(),
            };
        }
    }
}
