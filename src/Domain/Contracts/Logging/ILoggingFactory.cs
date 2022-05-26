using System;

namespace Domain.Contracts.Logging
{
    /// <summary>
    /// Interface that define a contract for a logging factory
    /// </summary>
    public interface ILoggingFactory
    {
        /// <summary>
        /// Creates a new instance of a generic logger with a specified category
        /// </summary>
        /// <param name="type">Logger type</param>
        /// <returns></returns>
        ILogging CreateLogger(Type type);
    }
}
