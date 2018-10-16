using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        public Node<T> Front { get; set; }
        public Node<T> Rear { get; set; }

        public LinkedQueue()
        {
            Front = null;
            Rear = null;
        }

        public T Push(T element)
        {
           // throw new NotImplementedException();
           if(element == null)
           {
                throw new ArgumentNullException();
           }

           if(IsEmpty())
           {
                Node<T> tmp = new Node<T>(element, null);
                Rear = Front = tmp;
           }
           else
           {
                Node<T> tmp = new Node<T>(element, null);
                Rear.Next = tmp;
                Rear = tmp;
           }
           return element;
        }


        public T Pop()
        {
            // throw new NotImplementedException();
            T tmp = default(T);

            if(IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if(Front == Rear)
            {
                tmp = Front.Data;
                Front = null;
                Rear = null;
            }
            else
            {
                tmp = Front.Data;
                Front = Front.Next;
            }

            return tmp;
        }

      


        public bool IsEmpty()
        {
           // throw new NotImplementedException();
           
            if( Front == null && Rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
