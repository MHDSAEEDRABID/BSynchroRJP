using BSynchroRJP.Application.Contracts.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace BSynchroRJP.Controllers
{
    [Area("Api")]
    [ApiController]
    public class AccountController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("[controller]/open-current-account")]
        public void OpenNewCurrentAccount([FromBody] CreateAccountDto input)
        {
            _accountService.OpenningANewCurrentAccount(input);
        }
    }
}
