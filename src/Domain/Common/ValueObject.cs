using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Common
{
    /// <summary>
    /// Class to be inherited by a value object entity
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// Compares if two value objects are the same instance
        /// </summary>
        /// <param name="left">Value object</param>
        /// <param name="right">Value object</param>
        /// <returns></returns>
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        /// <summary>
        /// Compares if two value objects are not the same instance
        /// </summary>
        /// <param name="left">Value object</param>
        /// <param name="right">Value object</param>
        /// <returns></returns>
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        /// <summary>
        /// Compares if the value object is equal to another one
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if they are the same</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// Gets the has code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Gets a copy of the value object
        /// </summary>
        /// <returns></returns>
        public ValueObject GetCopy()
        {
            return this.MemberwiseClone() as ValueObject;
        }
    }
}
