using Domain.Contracts.Logging;
using Microsoft.Extensions.Logging;
using System;

namespace Infrastructure.Common
{
    /// <summary>
    /// Implementation of the logging abstraction
    /// </summary>
    public class Logging : ILogging
    {
        // Logger implementation for an external library (in this case Microsoft.Extensions.Logging)
        protected readonly ILogger _logger;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="logger"></param>
        public Logging(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Logs a message with Trace level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        public void LogTrace(string message, params object[] args)
        {
            _logger.LogTrace(message, args);
        }

        /// <summary>
        /// Logs a message with Debug level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        public void LogDebug(string message, params object[] args)
        {
            _logger.LogDebug(message, args);
        }

        /// <summary>
        /// Logs a message with Information level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        /// <summary>
        /// Logs a message with Warning level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        /// <summary>
        /// Logs a message with Error level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        /// <summary>
        /// Logs a message with Error level
        /// </summary>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        public void LogError(Exception exception, string message, params object[] args)
        {
            _logger.LogError(exception, message, args);
        }

        /// <summary>
        /// Logs a message with Critical level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        public void LogCritical(string message, params object[] args)
        {
            _logger.LogCritical(message, args);
        }

        /// <summary>
        /// Logs a message with Critical level
        /// </summary>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        public void LogCritical(Exception exception, string message, params object[] args)
        {
            _logger.LogCritical(exception, message, args);
        }
    }
}
