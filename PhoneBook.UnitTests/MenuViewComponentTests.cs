using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using PhoneBook.Components;
using PhoneBook.Models;
using PhoneBook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.UnitTests
{
    class MenuViewComponentTests
    {
        [Test]
        public async Task Can_Create_Departments()
        {
            var employees = (new EmployeeModel[] {
                new EmployeeModel { EmployeeId = 1, Name = "N1", Department = "Dział IT" },
                new EmployeeModel { EmployeeId = 2, Name = "N2", Department = "Dział IT" },
                new EmployeeModel { EmployeeId = 3, Name = "N3", Department = "Marketing" },
                new EmployeeModel { EmployeeId = 4, Name = "N4", Department = "Dział Projektów" },
            }).AsQueryable();

            var mock = new Mock<IEmployeeRepository>();
            mock.Setup(x => x.GetAllEmployees()).Returns(employees);

            var target = new MenuViewComponent(mock.Object);

            var response = await target.InvokeAsync() as ViewViewComponentResult;

            var results = ((IEnumerable<string>)response.ViewData.Model).ToArray();

            Assert.AreEqual(3, results.Length);
            Assert.AreEqual("Dział IT", results[0]);
            Assert.AreEqual("Dział Projektów", results[1]);
            Assert.AreEqual("Marketing", results[2]);
        }
    }
}
