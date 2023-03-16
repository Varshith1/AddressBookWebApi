using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBookWebAPI.Repository.EfRepo
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserDetailsList> UserDetailsList { get; set; }
        public DbSet<LoginDetails> LoginCredentials { get; set; }
    }
}
