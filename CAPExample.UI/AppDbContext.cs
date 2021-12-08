using Microsoft.EntityFrameworkCore;

namespace CAPExample.UI
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name:{Name}, Id:{Id}";
        }
    }

    public class AppDbContext : DbContext
    {
        public const string ConnectionString = "Server=localhost;Database=CapExampleDB;User Id=sa;Password=yourStrong(!)Password;";

        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}

