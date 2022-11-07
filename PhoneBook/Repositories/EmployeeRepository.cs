using PhoneBook.Models;

namespace PhoneBook.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PhoneBookContext _context;

        public EmployeeRepository(PhoneBookContext context)
        {
            _context = context;
        }

        public IQueryable<EmployeeModel> GetAllEmployees()
        {
            return _context.Employees.OrderBy(x => x.EmployeeId);
        }
    }
}
