
/// <summary>
/// This is a singly linked node class.
/// </summary>
namespace ConsoleApp1
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;

        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}