using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employees
{
    public record PersonalData
    {
        public string LastName { get; }
        public Gender Gender { get; }

        public PersonalData(string lastName, Gender? gender)
        {
            if(String.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));
            lastName = lastName.Trim();
            if (lastName.Length > 50) throw new ArgumentOutOfRangeException(nameof(lastName));
            LastName = lastName;

            Gender = gender ?? throw new ArgumentNullException(nameof(gender));
        }
    }

    public enum Gender
    {
        Female,
        Male
    }
}
