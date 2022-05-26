using System;

namespace Domain.Contracts.Logging
{
    /// <summary>
    /// Interface for logging to define an abstraction of a logger decoupled from external libraries
    /// </summary>
    public interface ILogging
    {
        /// <summary>
        /// Logs a message with Trace level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        void LogTrace(string message, params object[] args);

        /// <summary>
        /// Logs a message with Debug level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        void LogDebug(string message, params object[] args);

        /// <summary>
        /// Logs a message with Information level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        void LogInformation(string message, params object[] args);

        /// <summary>
        /// Logs a message with Warning level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        void LogWarning(string message, params object[] args);

        /// <summary>
        /// Logs a message with Error level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        void LogError(string message, params object[] args);

        /// <summary>
        /// Logs a message with Error level
        /// </summary>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        void LogError(Exception exception, string message, params object[] args);

        /// <summary>
        /// Logs a message with Critical level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        void LogCritical(string message, params object[] args);

        /// <summary>
        /// Logs a message with Critical level
        /// </summary>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Optional parameters</param>
        void LogCritical(Exception exception, string message, params object[] args);
    }
}
