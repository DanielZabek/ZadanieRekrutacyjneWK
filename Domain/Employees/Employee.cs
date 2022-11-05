using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employees
{
    public class Employee : AggregateRoot<Guid>
    {
        public ReferenceNumber ReferenceNumber { get; } 
        public PersonalData PersonalData { get; private set; }

        public Employee(PersonalData personalData)
        {
            Id = Guid.NewGuid();
            ReferenceNumber = new ReferenceNumber();
            PersonalData = personalData ?? throw new ArgumentNullException(nameof(personalData));
        }

        public void UpdatePersonalData(PersonalData personalData)
        {
            PersonalData = personalData ?? throw new ArgumentNullException(nameof(personalData));
        }
    }
}
