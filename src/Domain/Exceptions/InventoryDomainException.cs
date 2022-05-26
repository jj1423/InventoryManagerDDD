using System;

namespace Domain.Exceptions
{
    public class InventoryDomainException : Exception
    {
        public InventoryDomainException()
        {
        }

        public InventoryDomainException(string message) : base(message)
        {
        }

        public InventoryDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
