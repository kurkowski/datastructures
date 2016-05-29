using System;

namespace DataStructures
{
    public class Queue<T>
    {
        private LinkedList<T> list;
        public Queue()
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

        public T dequeue()
        {
            return this.list.removeLast();
        }

        public void enqueue(T node)
        {
            this.list.addFirst(node);
        }
    }
}
