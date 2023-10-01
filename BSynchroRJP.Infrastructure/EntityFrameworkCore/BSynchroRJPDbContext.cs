using BSynchroRJP.Domain.Base;
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

    }
}
