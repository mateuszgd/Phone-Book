using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Models
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
