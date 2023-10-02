using BSynchroRJP.Domain.Accounts;
using BSynchroRJP.Domain.Base;
using BSynchroRJP.Domain.Customers;
using BSynchroRJP.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Infrastructure.EntityFrameworkCore
{
    public class BSynchroRJPDbContext : DbContext
    {
        public BSynchroRJPDbContext(DbContextOptions optionsBuilder) : base (optionsBuilder)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
