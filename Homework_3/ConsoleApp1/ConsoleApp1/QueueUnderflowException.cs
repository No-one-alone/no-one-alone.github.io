using System;

/// <summary>
/// This namespace holds the C# equivalent of the QueueUnderflowException.java program code and structure.
/// </summary>
namespace ConsoleApp1
{
    /// <summary>
    /// This is a custom unchecked exception to represent situations where 
    /// an illegal operation was performed on an empty queue.
    /// </summary>
    public class QueueUnderflowException : Exception
    {
        /// <summary>
        /// This the constructor for handling thrown exceptions.
        /// </summary>
        public QueueUnderflowException()
        {
        }

        /// <summary>
        /// This is the non-default constructor for handling thrown exceptions.
        /// </summary>
        /// <param name="message">An error message to the user</param>
        public QueueUnderflowException(string message) : base(message)
        {
        }
    }
}
