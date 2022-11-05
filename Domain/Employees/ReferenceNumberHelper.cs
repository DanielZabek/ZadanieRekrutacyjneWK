using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employees
{
    public static class ReferenceNumberHelper
    {
        public static bool IsUpdated = false;
        private static int current = 0;

        public static string GetNextReferenceNumber()
        {
            return Interlocked.Increment(ref current).ToString("D8");
        }

        public static void SetCurrentValue(string referenceNumber)
        {
            if (referenceNumber.All(char.IsDigit) && int.TryParse(referenceNumber, out current))
                IsUpdated = true;
            else
                throw new ArgumentException(nameof(referenceNumber));
        }
    }
}
