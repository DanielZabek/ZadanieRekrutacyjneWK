using Domain.Employees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.CreateEmployee
{
    public record CreateEmployeeCommand(string LastName, Gender? Gender) : IRequest;
}
