using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using account_manager_backend.Models;

namespace account_manager_backend.Data
{
    public class account_manager_backendContext : DbContext
    {
        public account_manager_backendContext (DbContextOptions<account_manager_backendContext> options)
            : base(options)
        {
        }

        public DbSet<account_manager_backend.Models.Account> Account { get; set; }

        public DbSet<account_manager_backend.Models.Employee> Employee { get; set; }
    }
}
