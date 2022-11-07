using PhoneBook.Models;

namespace PhoneBook.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<EmployeeModel> GetAllEmployees();
    }
}
