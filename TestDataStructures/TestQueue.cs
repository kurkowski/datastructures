using NUnit.Framework;
using DataStructures;
using System;

namespace TestDataStructures
{
    class TestQueue
    {
        Queue<int?> queue;
        [SetUp]
        public void init()
        {
            queue = new Queue<int?>();
        }

        [Test]
        public void testInitialize()
        {
            Assert.AreEqual(0, queue.Count);
        }

        [Test]
        public void testRemovalOnEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => queue.dequeue());
        }

        [Test]
        public void testOrder()
        {
            queue.enqueue(1);
            queue.enqueue(2);
            queue.enqueue(3);
            queue.enqueue(4);
            queue.enqueue(5);
            Assert.AreEqual(5, queue.Count);
            int? first = queue.dequeue();
            int? second = queue.dequeue();
            int? third = queue.dequeue();
            int? fourth = queue.dequeue();
            int? fifth = queue.dequeue();
            Assert.AreEqual(1, first);
            Assert.AreEqual(2, second);
            Assert.AreEqual(3, third);
            Assert.AreEqual(4, fourth);
            Assert.AreEqual(5, fifth);
        }
    }
}
