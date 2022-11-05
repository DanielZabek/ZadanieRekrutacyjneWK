using Domain.Employees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.UpdateEmployee
{
    public record UpdateEmployeeCommand(Guid Id, string LastName, Gender? Gender) : IRequest;
}
