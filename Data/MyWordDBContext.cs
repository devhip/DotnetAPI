using webappmssql.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace webappmssql.Data.Entities
{
    public class MyWordDBContext : DbContext
    {
        public MyWordDBContext(DbContextOptions<MyWordDBContext> options) : base(options)
        {

        }

        public DbSet<Gadgets> Gadgets{get;set;}
    }
}