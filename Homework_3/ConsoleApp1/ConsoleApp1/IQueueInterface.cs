
/// <summary>
/// This namespace holds the C# equivalent of the QueueInterface.java program code and structure.
/// </summary>
namespace ConsoleApp1
{
    /// <summary>
    /// This is a FIFO queue interface. 
    /// This ADT is suitable for a singly linked queue.
    /// </summary>
    /// <typeparam name="T">T for Generic Type Parameter</typeparam>
    public interface IQueueInterface<T>
    {
        /// <summary>
        /// This adds an element to the rear of the queue.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>The element that was enqueued</returns>
        T Push(T element);

        /// <summary>
        /// Remove and return the front element.
        /// </summary>
        /// <returns>The element that was removed.</returns>
        T Pop();

        /// <summary>
        /// This tests if the queue is empty
        /// </summary>
        /// <returns> true if the queue is empty; otherwise returns false </returns>
        bool IsEmpty();
    }
}
