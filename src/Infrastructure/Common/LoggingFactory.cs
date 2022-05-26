using Domain.Contracts.Logging;
using Microsoft.Extensions.Logging;
using System;

namespace Infrastructure.Common
{
    /// <summary>
    /// Implementation for logging factory
    /// </summary>
    public class LoggingFactory : ILoggingFactory
    {
        ILoggerFactory _loggerFactory;

        /// <summary>
        /// Parameterized constructor to inject an external logger factory
        /// </summary>
        /// <param name="loggerFactory"></param>
        public LoggingFactory(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        /// <summary>
        /// Creates a new instance of logger with the specified category name
        /// </summary>
        /// <param name="type">Logger type</param>
        /// <returns></returns>
        public ILogging CreateLogger(Type type)
        {
            return new Logging(_loggerFactory.CreateLogger(type.FullName));
        }
    }
}
