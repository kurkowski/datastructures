using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Stack<T>
    {
        private LinkedList<T> list;
        public Stack()
        {
            list = new LinkedList<T>();
        }

        public UInt64 Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public void push(T node)
        {
            this.list.addFirst(node);
        }

        public T pop()
        {
            return this.list.removeFirst();
        }
    }
}
