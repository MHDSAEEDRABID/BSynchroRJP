using BSynchroRJP.Domain.Customers;
using BSynchroRJP.Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Infrastructure.Customers
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        public Task<Customer> GetByIdWithDetailsAsync(Guid id);
    }
}
