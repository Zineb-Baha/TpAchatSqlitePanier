using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TpAchatSqlite.Models;

namespace TpAchatSqlite.Data
{
    public class TpAchatSqliteContext : DbContext
    {
        public TpAchatSqliteContext (DbContextOptions<TpAchatSqliteContext> options)
            : base(options)
        {
        }

        public DbSet<TpAchatSqlite.Models.Produit> Produit { get; set; } = default!;
    }
}
