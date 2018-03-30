using NUnit.Framework;

namespace LoopDetector
{

    public class Node
    {
        public Node next;
    }
    public class Kata
    {
        public static int getLoopSize(LoopDetector.Node startNode)
        {
            System.Collections.Generic.Dictionary<LoopDetector.Node, int> previousNodes = new System.Collections.Generic.Dictionary<LoopDetector.Node, int>();

            var currentNode = startNode;
            var currentIndex = 0;
            while(true)
            {
                int loopStartIndex;
                currentIndex++;
                if (previousNodes.TryGetValue(currentNode, out loopStartIndex))
                {
                    return currentIndex - loopStartIndex;
                }
                
                previousNodes[currentNode] = currentIndex;
                currentNode = currentNode.next;
            }
        }
    }

    [TestFixture]
    public class CanYouGetTheLoop
    {
        [Test]
        public void FourNodesWithLoopSize3()
        {
            var n1 = new LoopDetector.Node();
            var n2 = new LoopDetector.Node();
            var n3 = new LoopDetector.Node();
            var n4 = new LoopDetector.Node();
            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n2;
            Assert.AreEqual(3, Kata.getLoopSize(n1));
        }

        [Test]
        public void More_nodes()
        {
            var n1 = new LoopDetector.Node();
            var n2 = new LoopDetector.Node();
            var n3 = new LoopDetector.Node();
            var n4 = new LoopDetector.Node();
            var n5 = new LoopDetector.Node();
            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n3;

            Assert.AreEqual(3, Kata.getLoopSize(n1));
        }

        //[Test]
        //public void RandomChainNodesWithLoopSize30()
        //{
        //    var n1 = LoopDetector.createChain(3, 30);
        //    Assert.AreEqual(30, Kata.getLoopSize(n1));
        //}

        //[Test]
        //public void RandomLongChainNodesWithLoopSize1087()
        //{
        //    var n1 = LoopDetector.createChain(3904, 1087);
        //    Assert.AreEqual(1087, Kata.getLoopSize(n1));
        //}
    }
}
