using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public abstract class List<T>
    {
        public List()
        {
            this.Count = 0;
        }
        public UInt64 Count { get; protected set; }
        public abstract bool isEmpty();
        public abstract void addFirst(T node);
        public abstract void addLast(T node);
        public abstract T removeFirst();
        public abstract T removeLast();
        public abstract bool contains(T node);
        public abstract void clear();
    }
}
