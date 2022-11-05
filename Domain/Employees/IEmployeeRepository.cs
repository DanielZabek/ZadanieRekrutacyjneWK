using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employees
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
        Task<string> GetMaxReferenceNumber(CancellationToken cancellationToken = default);
    }
}
