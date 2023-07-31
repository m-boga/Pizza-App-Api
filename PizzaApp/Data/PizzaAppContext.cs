using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;

namespace PizzaApp.Data
{
    public class PizzaAppContext : DbContext
    {
        public PizzaAppContext(DbContextOptions<PizzaAppContext> options)
            : base(options)
        {

        }
        

        public DbSet<RestaurantBranch> RestaurantBranches { get; set; }
    }
}
