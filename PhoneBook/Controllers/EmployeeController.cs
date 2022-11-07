using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Repositories;

namespace PhoneBook.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ActionResult Index(string sortOrder, string department)
        {
            var employees = _employeeRepository.GetAllEmployees()
                .Where(x => department == null || x.Department.ToLower().Replace(" ", "-") == department);

            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";

            switch (sortOrder)
            {
                case "name_asc":
                    employees = employees.OrderBy(x => x.LastName);
                    break;
            }

            return View(employees);
        }
    }
}
