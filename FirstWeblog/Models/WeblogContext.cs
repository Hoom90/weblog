using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWeblog.Models
{
    public class WeblogContext : DbContext
    {

        DbSet<Member> Members { get; set; }
        DbSet<Log> Logs { get; set; }
    }
}
