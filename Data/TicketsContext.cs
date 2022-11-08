using Microsoft.EntityFrameworkCore;
using test_csharp.Models;

namespace test_csharp.Data
{
    public class TicketsContext : DbContext
    {

        public TicketsContext(DbContextOptions<TicketsContext> context) :base (context){
            
        }
        public DbSet<Tickets> tickets {get;set;}

        
    }
}