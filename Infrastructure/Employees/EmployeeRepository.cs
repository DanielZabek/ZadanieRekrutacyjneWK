using Domain.Employees;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ICollection<Employee> employees = new List<Employee>();
        public EmployeeRepository()
        {
            ReferenceNumberHelper.SetCurrentValue("00000000");
            employees.Add(new Employee(new PersonalData("Kowalski", Gender.Male)));
            employees.Add(new Employee(new PersonalData("Nowak", Gender.Female)));
        }
     
        public async Task<Employee> AddAsync(Employee entity, CancellationToken cancellationToken = default)
        {
            employees.Add(entity);
            return entity;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return employees.AsEnumerable();
        }

        public async Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return employees.SingleOrDefault(x => x.Id == id) ?? throw new Exception("Employee not found");
        }

        public async Task<string> GetMaxReferenceNumber(CancellationToken cancellationToken = default)
        {
            var maxNumber = employees.Max(x => x.ReferenceNumber);
            return maxNumber != null ? maxNumber.Number : "00000000";
        }
    }
}
