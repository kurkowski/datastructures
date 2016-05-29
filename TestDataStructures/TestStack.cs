using NUnit.Framework;
using DataStructures;
using System;

namespace TestDataStructures
{
    class TestStack
    {
        private Stack<int?> stack;
        [SetUp]
        public void init()
        {
            stack = new Stack<int?>();
        }

        [Test]
        public void testInitialize()
        {
            Assert.AreEqual(0, stack.Count);
        }

        [Test]
        public void testRemovalOnEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => stack.pop());
        }

        [Test]
        public void testOrder()
        {
            stack.push(1);
            stack.push(2);
            stack.push(3);
            stack.push(4);
            stack.push(5);
            Assert.AreEqual(5, stack.Count);
            int? first = stack.pop();
            int? second = stack.pop();
            int? third = stack.pop();
            int? fourth = stack.pop();
            int? fifth = stack.pop();
            Assert.AreEqual(5, first);
            Assert.AreEqual(4, second);
            Assert.AreEqual(3, third);
            Assert.AreEqual(2, fourth);
            Assert.AreEqual(1, fifth);
        }
    }
}
