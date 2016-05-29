
using NUnit.Framework;
using DataStructures;

namespace TestDataStructures
{
    [TestFixture]
    public class TestLinkedList : TestList
    {

        protected LinkedList<int?> linkedList;

        [SetUp]
        public void init()
        {
            linkedList = new LinkedList<int?>();
            list = new LinkedList<int?>();
        }

        public void emptyLinkedList()
        {
            Assert.AreEqual(0, linkedList.Count);
            Assert.IsNull(linkedList.First);
            Assert.IsNull(linkedList.Last);
        }

        [Test]
        public void testHasCorrectInitializedProperties()
        {
            Assert.IsTrue(linkedList.Count == 0);
            Assert.IsNull(linkedList.First);
            Assert.IsNull(linkedList.Last);
        }

        #region maintains pointers on add
        [Test]
        public void testMaintainsPointersOnAddFirst()
        {
            linkedList.addFirst(1);
            Assert.AreEqual(linkedList.First.Payload, linkedList.Last.Payload);
            linkedList.addFirst(2);
            linkedList.addFirst(3);
            Assert.AreEqual(3, linkedList.First.Payload);
            Assert.AreEqual(1, linkedList.Last.Payload);
        }

        [Test]
        public void testMaintainsPointersOnAddLast()
        {
            linkedList.addLast(1);
            Assert.AreEqual(linkedList.First.Payload, linkedList.Last.Payload);
            linkedList.addLast(2);
            linkedList.addLast(3);
            Assert.AreEqual(3, linkedList.Last.Payload);
            Assert.AreEqual(1, linkedList.First.Payload);
        }

        #endregion

        #region maintains pointers on clear
        [Test]
        public void testLinkedListClear()
        {
            this.emptyLinkedList();
            linkedList.addFirst(1);
            Assert.AreEqual(1, linkedList.Count);
            linkedList.clear();
            this.emptyLinkedList();
        }

        #endregion

        #region maintains pointers on remove
        [Test]
        public void testMaintainsPointersOnRemoveFirst()
        {
            linkedList.addLast(0);
            linkedList.addLast(1);
            linkedList.addLast(2);
            Assert.AreEqual(0, linkedList.First.Payload);
            Assert.AreEqual(2, linkedList.Last.Payload);
            linkedList.removeFirst();
            Assert.AreEqual(1, linkedList.First.Payload);
            Assert.AreEqual(2, linkedList.Last.Payload);
        }

        [Test]
        public void testMaintainsPointersOnRemoveLast()
        {
            linkedList.addLast(0);
            linkedList.addLast(1);
            linkedList.addLast(2);
            Assert.AreEqual(0, linkedList.First.Payload);
            Assert.AreEqual(2, linkedList.Last.Payload);
            linkedList.removeLast();
            Assert.AreEqual(0, linkedList.First.Payload);
            Assert.AreEqual(1, linkedList.Last.Payload);
        }
        #endregion

        [Test]
        public void testFindOnEmptyList()
        {
            LinkedList<int?>.LinkedListNode nothing = linkedList.find(0);
            Assert.IsNull(nothing);
        }

        [Test]
        public void testFindOnNonEmptyList()
        {
            linkedList.addLast(0);
            linkedList.addLast(1);
            linkedList.addLast(2);
            LinkedList<int?>.LinkedListNode node = linkedList.find(1);
            Assert.AreEqual(1, node.Payload);
            Assert.AreEqual(linkedList.First.Payload, node.Prev.Payload);
            Assert.AreEqual(linkedList.Last.Payload, node.Next.Payload);
        }
    }
}