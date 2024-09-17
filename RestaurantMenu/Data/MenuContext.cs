using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Models;

namespace RestaurantMenu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext ( DbContextOptions<MenuContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngridient>().HasKey(di => new
            {
                di.DishId,
                di.IngridientId
            });
            modelBuilder.Entity<DishIngridient>().HasOne(d => d.Dish).WithMany(di => di.DishIngridient).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngridient>().HasOne(i => i.Ingridient).WithMany(di => di.DishIngridient).HasForeignKey(i => i.IngridientId);


            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Margheritta", Price = 7.50, ImageUrl = "https://www.abeautifulplate.com/wp-content/uploads/2015/08/the-best-homemade-margherita-pizza-1-4.jpg" }
                );
            modelBuilder.Entity<Ingridient>().HasData(
                new Ingridient { Id=1, Name="Mozarella" },
                new Ingridient { Id = 2, Name = "Tomato Passata" },
                new Ingridient { Id = 3, Name = "Bazil" }
                );
            modelBuilder.Entity<DishIngridient>().HasData(
                new DishIngridient { DishId = 1, IngridientId = 1 },
                new DishIngridient { DishId = 1, IngridientId = 2 },
                new DishIngridient { DishId = 1, IngridientId = 3 }
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<DishIngridient> DishIngridients { get; set; }
    }
}
