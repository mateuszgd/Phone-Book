using Microsoft.AspNetCore.Mvc;
using PhoneBook.Repositories;

namespace PhoneBook.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;

        public MenuViewComponent(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;   
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<string> departments = _employeeRepository.GetAllEmployees()
                .Select(x => x.Department)
                .Distinct()
                .OrderBy(x => x);

            return await Task.FromResult((IViewComponentResult)View(departments));
        }
    }
}
