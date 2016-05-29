using NUnit.Framework;
using DataStructures;
using System;

namespace TestDataStructures
{
    public abstract class TestList
    {
        protected List<int?> list;

        #region adding
        [Test]
        public void testAddFirstMethod()
        {
            list.addFirst(1);
            Assert.AreEqual(1, list.Count);
            list.addFirst(2);
            Assert.AreEqual(2, list.Count);
            list.addFirst(3);
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void testAddLastMethod()
        {
            list.addLast(1);
            Assert.AreEqual(1, list.Count);
            list.addLast(2);
            Assert.AreEqual(2, list.Count);
            list.addLast(3);
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void testAddFirstWorksWithNull()
        {
            list.addFirst(null);
            Assert.AreEqual(1, list.Count);
        }

        #endregion

        #region isEmpty
        [Test]
        public void testListIsEmptyMethodAfterAddFirst()
        {
            Assert.IsTrue(list.isEmpty());
            list.addFirst(0);
            Assert.IsFalse(list.isEmpty());
        }

        [Test]
        public void testListIsEmptyMethodAfterAddLast()
        {
            Assert.IsTrue(list.isEmpty());
            list.addLast(0);
            Assert.IsFalse(list.isEmpty());
        }

        #endregion

        #region clear
        [Test]
        public void testClear()
        {
            Assert.AreEqual(0, list.Count);
            list.addFirst(1);
            list.addFirst(2);
            Assert.AreEqual(2, list.Count);
            list.clear();
            Assert.AreEqual(0, list.Count);
        }

        #endregion

        #region removing
        [Test]
        public void testRemoveFirstEmptyList()
        {
            Assert.AreEqual(0, list.Count);
            Assert.Throws<InvalidOperationException>(() => list.removeFirst());
        }

        [Test]
        public void testRemoveFirstAfterAddFirst()
        {
            list.addFirst(0);
            list.addFirst(1);
            list.addFirst(2);
            int? removed = list.removeFirst();
            Assert.AreEqual(2, removed);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void testRemoveFirstAfterAddLast()
        {
            list.addLast(0);
            list.addLast(1);
            list.addLast(2);
            int? removed = list.removeFirst();
            Assert.AreEqual(0, removed);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void testRemoveLastAfterAddFirst()
        {
            list.addFirst(0);
            list.addFirst(1);
            list.addFirst(2);
            int? removed = list.removeLast();
            Assert.AreEqual(0, removed);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void testRemoveLastAfterAddLast()
        {
            list.addLast(0);
            list.addLast(1);
            list.addLast(2);
            int? removed = list.removeLast();
            Assert.AreEqual(2, removed);
            Assert.AreEqual(2, list.Count);
        }

        #endregion

        #region contains
        [Test]
        public void testContains()
        {
            list.addFirst(0);
            list.addFirst(1);
            list.addFirst(2);
            Assert.IsTrue(list.contains(2));
            Assert.IsFalse(list.contains(3));
            list.removeFirst();
            Assert.IsFalse(list.contains(2));
            list.addLast(3);
            Assert.IsTrue(list.contains(3));
        }

        [Test]
        public void testContainsOnNullItem()
        {
            list.addFirst(1);
            list.addFirst(null);
            list.addFirst(2);
            Assert.IsTrue(list.contains(null));
        }

        [Test]
        public void testContainsOnEmptyList()
        {
            Assert.IsFalse(list.contains(null));
        }
        #endregion
    }
}
