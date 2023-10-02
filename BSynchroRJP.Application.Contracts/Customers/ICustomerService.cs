using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Application.Contracts.Customers
{
    public interface ICustomerService
    {

        Task<CustomerDto> GetCustomerInfo(Guid id);
    }
}