using Microsoft.AspNetCore.Mvc;
using Moq;
using PhoneBook.Controllers;
using PhoneBook.Models;
using PhoneBook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.UnitTests
{
    class EmployeeControllerTests
    {
        [Test]
        public void Can_Filter_Employees()
        {
            var employees = (new EmployeeModel[] {
                new EmployeeModel { EmployeeId = 1, Name = "N1", Department = "Dział IT" },
                new EmployeeModel { EmployeeId = 2, Name = "N2", Department = "Marketing" },
                new EmployeeModel { EmployeeId = 3, Name = "N3", Department = "Dział Projektów" },
                new EmployeeModel { EmployeeId = 4, Name = "N4", Department = "Marketing" },
            }).AsQueryable();

            var mock = new Mock<IEmployeeRepository>();
            mock.Setup(x => x.GetAllEmployees()).Returns(employees);

            var target = new EmployeeController(mock.Object);

            var response = target.Index(null, "marketing") as ViewResult;

            var result = ((IEnumerable<EmployeeModel>)response.Model).ToArray();

            Assert.AreEqual(2, result.Length);
            Assert.IsTrue(result[0].Name == "N2" && result[0].Department == "Marketing");
            Assert.IsTrue(result[1].Name == "N4" && result[1].Department == "Marketing");
        }

        [Test]
        public void Can_Sort()
        {
            var employees = (new EmployeeModel[]
            {
                new EmployeeModel { EmployeeId = 1, LastName = "DC" },
                new EmployeeModel { EmployeeId = 2, LastName = "AB" },
                new EmployeeModel { EmployeeId = 3, LastName = "CD" },
                new EmployeeModel { EmployeeId = 4, LastName = "AA" },
            }).AsQueryable();

            var mock = new Mock<IEmployeeRepository>();
            mock.Setup(x => x.GetAllEmployees()).Returns(employees);

            var target = new EmployeeController(mock.Object);

            var response = target.Index("name_asc", null) as ViewResult;

            var result = ((IEnumerable<EmployeeModel>)response.Model).ToArray();

            Assert.AreEqual("AA", result[0].LastName);
            Assert.AreEqual("AB", result[1].LastName);
            Assert.AreEqual("CD", result[2].LastName);
            Assert.AreEqual("DC", result[3].LastName);
        }
    }
}
