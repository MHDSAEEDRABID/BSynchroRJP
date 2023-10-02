using BSynchroRJP.Application.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;

namespace BSynchroRJP.Controllers
{
    [ApiController]
    [Area("Api")]
    public class CustomerController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("[controller]/get-customer-info-by-id/{id}")]
        public Task<CustomerDto> GetCustomerInfoById(Guid id)
        {
            return _customerService.GetCustomerInfo(id);
        }
    }
}
