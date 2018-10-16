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


        }


        public T Pop()
        {
            throw new NotImplementedException();
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
