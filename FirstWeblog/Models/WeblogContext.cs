using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWeblog.Models
{
    public class WeblogContext : DbContext
    {
        public WeblogContext(DbContextOptions<WeblogContext> options)
            : base(options)
        {

        }
       

        public DbSet<Member> Members { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
