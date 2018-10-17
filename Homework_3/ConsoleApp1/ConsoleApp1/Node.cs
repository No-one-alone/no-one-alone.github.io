
/// <summary>
/// This namespace holds the C# equivalent of the Node.java program code and structure.
/// </summary>
namespace ConsoleApp1
{
    /// <summary>
    /// This is a singly linked node class.
    /// </summary>
    public class Node<T>
    {
        /// <summary>
        /// This is an automatic property to get and set the data contents of this node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// This is an automatic property to get and set the Node that this node is being placed on top of in the stack.
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// This is a non-default constructor to create a new Node to be added to the stack and to specific its content.
        /// </summary>
        /// <param name="data">This is the data the node is to contain.</param>
        /// <param name="next">This is a pointer to the next node to be placed on top of the stack.</param>
        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}