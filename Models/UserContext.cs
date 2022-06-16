using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}
