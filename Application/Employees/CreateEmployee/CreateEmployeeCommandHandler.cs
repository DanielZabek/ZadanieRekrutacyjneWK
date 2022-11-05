using Domain.Employees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            if(command == null)
                throw new ArgumentNullException(nameof(command));

            if (!ReferenceNumberHelper.IsUpdated)
               ReferenceNumberHelper.SetCurrentValue(await _employeeRepository.GetMaxReferenceNumber());

           await _employeeRepository.AddAsync(new Employee(new PersonalData(command.LastName, command.Gender)));
           return Unit.Value;
        }
    }
}
