using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class AggregateRoot<T> : IAggregateRoot<T>
    {
        public T Id { get; protected set; }
    }
}
