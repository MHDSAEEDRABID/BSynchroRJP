using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Application.Contracts.Accounts
{
    public interface IAccountService
    {
        Task OpenningANewCurrentAccount(CreateAccountDto input);
    }
}
