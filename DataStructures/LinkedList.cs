using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /**
     * Doubly-linked linkedlist with sentinel nodes.
     */
    public class LinkedList<T> : List<T>
    {
        private LinkedListNode sentinelFirst;
        private LinkedListNode sentinelLast;
        public LinkedListNode First { get; protected set; }
        public LinkedListNode Last { get; protected set; }

        public LinkedList() : base()
        {
            sentinelFirst = new LinkedListNode();
            sentinelLast = new LinkedListNode();
            this.First = null;
            this.Last = null;
        }

        public override void addFirst(T node)
        {
            LinkedListNode nodeToAdd = new LinkedListNode(node);
            if (this.First == null)
            {
                this.firstInsert(nodeToAdd);
            }
            else
            {
                this.sentinelFirst.Next = nodeToAdd;
                nodeToAdd.Prev = this.sentinelFirst;
                nodeToAdd.Next = this.First;
                this.First.Prev = nodeToAdd;
                this.First = nodeToAdd;
            }
            this.Count++;
        }

        public override void addLast(T node)
        {
            LinkedListNode nodeToAdd = new LinkedListNode(node);
            if (this.Last == null)
            {
                this.firstInsert(nodeToAdd);
            }
            else
            {
                this.sentinelLast.Prev = nodeToAdd;
                nodeToAdd.Next = this.sentinelLast;
                nodeToAdd.Prev = this.Last;
                this.Last.Next = nodeToAdd;
                this.Last = nodeToAdd;
            }
            this.Count++;
        }

        private void firstInsert(LinkedListNode nodeToAdd)
        {
            this.sentinelFirst.Next = nodeToAdd;
            this.sentinelLast.Prev = nodeToAdd;
            nodeToAdd.Next = this.sentinelLast;
            nodeToAdd.Prev = this.sentinelFirst;
            this.First = nodeToAdd;
            this.Last = nodeToAdd;
        }

        public override void clear()
        {
            this.First = null;
            this.Last = null;
            this.Count = 0;
            this.sentinelFirst.Next = null;
            this.sentinelLast.Prev = null;
        }

        public override bool isEmpty()
        {
            return this.Count == 0;
        }

        public override T removeFirst()
        {
            if (this.First != null)
            {
                T value = this.First.Payload;
                this.sentinelFirst.Next = this.First.Next;
                this.First.Next.Prev = this.sentinelFirst;
                this.First = this.sentinelFirst.Next;
                this.Count--;
                return value;
            }
            throw new InvalidOperationException();
        }

        public override T removeLast()
        {
            if (this.Last != null)
            {
                T value = this.Last.Payload;
                this.sentinelLast.Prev = this.Last.Prev;
                this.Last.Prev.Next = this.sentinelLast;
                this.Last = this.sentinelLast.Prev;
                this.Count--;
                return value;
            }
            throw new InvalidOperationException();
        }

        public override bool contains(T node)
        {
            LinkedListNode current = this.First;
            while (current != null && current != this.sentinelLast)
            {
                if (EqualityComparer<T>.Default.Equals(current.Payload, node))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public LinkedListNode find(T node)
        {
            LinkedListNode current = this.First;
            while (current != null && current != this.sentinelLast)
            {
                if (current.Payload.Equals(node))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
        
        public class LinkedListNode
        {
            public LinkedListNode()
            {
                this.Next = null;
                this.Prev = null;
                this.Payload = default(T);
            }
            public LinkedListNode(T payload)
            {
                this.Next = null;
                this.Prev = null;
                this.Payload = payload;
            }
            public LinkedListNode Next { get; set; }
            public LinkedListNode Prev { get; set; }
            public T Payload { get; set; }

        }
    }
}
