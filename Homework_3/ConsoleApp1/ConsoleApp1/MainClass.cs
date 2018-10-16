using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MainClass
    {
        static LinkedList<string> GenerateBinaryRepresentationList(int n)
        {
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            LinkedList<string> output = new LinkedList<string>();

            if( n < 1)
            {
                return output;
            }

            q.Push(new StringBuilder("1"));

            while(n-- > 0)
            {
                StringBuilder sb = q.Pop();

                output.AddLast(sb.ToString());

                StringBuilder sbc = new StringBuilder(sb.ToString());

                sb.Append('0');

                q.Push(sb);

                sbc.Append('1');

                q.Push(sbc);

            }

            return output;
        }


        





    }
}
