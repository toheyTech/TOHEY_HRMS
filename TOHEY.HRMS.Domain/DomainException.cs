using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TOHEY.HRMS.Domain
{
    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
