using Domain.Employees;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mocs
{
    public static class MockEmployeeRepository
    {
        public static Mock<IEmployeeRepository> GetEmployeeRepository()
        {
            ReferenceNumberHelper.SetCurrentValue("00000000");

            var employees = new List<Employee> {
                new Employee (new PersonalData("Kowalski", Gender.Male)),
                new Employee (new PersonalData("Nowak", Gender.Female))
            };
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(employees);
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>())).ReturnsAsync((Employee employee, CancellationToken cancellationToken) =>
            {
                employees.Add(employee);
                return employee;
            });

            return mockRepo;
        }
    }
}
