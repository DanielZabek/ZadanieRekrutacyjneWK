using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employees
{
    public record ReferenceNumber
    {
        public string Number { get; }
        public ReferenceNumber()
        {
            Number = ReferenceNumberHelper.IsUpdated ? ReferenceNumberHelper.GetNextReferenceNumber() : throw new Exception("Reference number is not updated, update reference number to max value");
        }
    }
}
