

using System;

namespace ConsoleApp1
{
    /// <summary>
    /// This is a custom unchecked exception to represent situations where 
    /// an illegal operation was performed on an empty queue.
    /// </summary>
    public class QueueUnderflowException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public QueueUnderflowException()
        {
        }

        public QueueUnderflowException(string message) : base(message)
        {
        }
    }





}
