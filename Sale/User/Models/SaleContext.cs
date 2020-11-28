using System.Data.Entity;

namespace User.Models
{
    /// <summary>
    /// Контекст данных для взаимодействия с БД
    /// </summary>
    public class SaleContext:DbContext
    {
        public SaleContext():base("DBConnection")
        { }

        static SaleContext()
        {
            Database.SetInitializer<SaleContext>(new SaleContextInitializer());
        }
        
        /// <summary>
        /// Набор сущностей из БД users
        /// </summary>
        public DbSet<User> Users { get; set; }
        
        /// <summary>
        /// Набор сущностей из БД books
        /// </summary>
        public DbSet<Book> Books { get; set; }
        
        /// <summary>
        /// Набор сущностей из БД orders
        /// </summary>
        public DbSet<Order> Orders { get; set; }
    }
}