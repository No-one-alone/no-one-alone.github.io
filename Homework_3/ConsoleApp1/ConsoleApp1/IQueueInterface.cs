

namespace ConsoleApp1
{
    /// <summary>
    /// This is a FIFO queue interface. 
    /// This ADT is suitable for a singly linked queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
        /// <returns></returns>
        T Pop();

        bool IsEmpty();

    }

}
