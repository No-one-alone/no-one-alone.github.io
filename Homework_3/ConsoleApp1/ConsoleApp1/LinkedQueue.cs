using System;

/// <summary>
/// This namespace holds the C# equivalent of the LinkedQueue.java program code and structure.
/// </summary>
namespace ConsoleApp1
{
    /// <summary>
    /// A Singly Linked FIFO Queue.  
    /// From Dale, Joyce and Weems "Object-Oriented Data Structures Using Java"
    /// Modified for CS 460 HW3
    /// Subsequently translated into C# equivalent file by Khorben Boyer.
    /// See QueueInterface.java for documentation
    /// </summary>
    /// <typeparam name="T">T for Generic Type Parameter</typeparam>
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        /// <summary>
        /// This is an automatic property to get and set the Front property of Node that is being placed into the queue.
        /// </summary>
        public Node<T> Front { get; set; }

        /// <summary>
        /// This is an automatic property to get and set the Rear property of Node that is being placed into the queue.
        /// </summary>
        public Node<T> Rear { get; set; }

        /// <summary>
        /// This the constructor for initializing the Front and Rear properties to null
        /// </summary>
        public LinkedQueue()
        {
            Front = null;
            Rear = null;
        }

        /// <summary>
        /// This method pushes a node element onto the queue
        /// </summary>
        /// <param name="element">This is a node element</param>
        /// <returns>The node element</returns>
        public T Push(T element)
        {
           if(element == null)  // This checks if the element is null and throws an exception if it is.
            {
                throw new ArgumentNullException();
           }
           if(IsEmpty()) // This checks if the queue is empty and pushes the node into the empty queue.
            {
                Node<T> tmp = new Node<T>(element, null);
                Rear = Front = tmp;
           }
           else // if not empty -(General Case), then it adds the node to the rear of the queue and advances the queue order.
           {
                Node<T> tmp = new Node<T>(element, null);
                Rear.Next = tmp;
                Rear = tmp;
           }
           return element;
        }


        /// <summary>
        /// This method pops a node element off the queue
        /// </summary>
        /// <returns>A node element</returns>
        public T Pop()
        {
            T tmp = default(T);  // default is C# equivalent to "null" in java.

            
            if (IsEmpty()) // This checks if the queue is empty and throws an exception if it is; otherwise it gets a node appropriately.
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if(Front == Rear) // This is for the case of there being one item in the queue.
            {
                tmp = Front.Data;
                Front = null;
                Rear = null;
            }
            else // This covers the general case of there being more than one item in the queue.
            {
                tmp = Front.Data;
                Front = Front.Next;
            }

            return tmp;
        }

        /// <summary>
        /// This checks if the queue is empty.
        /// </summary>
        /// <returns>It returns true if queue is empty; false otherwise</returns>
        public bool IsEmpty()
        {
            if( Front == null && Rear == null) // this checks if queue is empty
            {
                return true;
            }
            else // this covers the general case of the queue not being empty.
            {
                return false;
            }
        }
    }
}
