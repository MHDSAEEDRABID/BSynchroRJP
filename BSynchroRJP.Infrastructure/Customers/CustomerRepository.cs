using BSynchroRJP.Domain.Customers;
using BSynchroRJP.Infrastructure.EntityFrameworkCore;
using BSynchroRJP.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Infrastructure.Customers
{
    public class CustomerRepository : EfCoreRepository<BSynchroRJPDbContext, Customer, Guid>, ICustomerRepository
    {
        public async Task<Customer> GetByIdWithDetailsAsync(Guid id)
        {
            return await dbContext.Customers.AsQueryable()
                                .Where(x => x.Id == id)
                                    .Include(x => x.Accounts)
                                            .ThenInclude(x => x.Transactions)
                                .FirstOrDefaultAsync();
        }
    }
}
