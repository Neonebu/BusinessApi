using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessApi.Models;
using Microsoft.EntityFrameworkCore;
namespace BusinessApi
{
    public class MoneyContext : DbContext
    {
        public MoneyContext(DbContextOptions<MoneyContext> options) : base(options) { }
        public DbSet<Tarih_Date> tarih_Dates { get; set; }
        public DbSet<Currency> currencies { get; set; }
    }
}
