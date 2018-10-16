

namespace ConsoleApp1
{
    /// <summary>
    /// This is a singly linked node class.
    /// </summary>
    public class Node<T>
    {
        private T data;
        private Node<T> next;

        public T Data { get => data; set => data = value; }
        public Node<T> Next { get => next; set => next = value; }

        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}