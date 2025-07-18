using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities, dequeue to get highest priority in FIFO order
    // Expected Result: Returns highest priority item first, FIFO for equal priorities
    // Defect(s) Found: Loop excludes last item (index < Count - 1). Item not removed. FIFO not ensured for equal priorities.
    public void TestPriorityQueue_1()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 2);
        Assert.AreEqual("B", queue.Dequeue()); // Highest priority (3)
        Assert.AreEqual("C", queue.Dequeue()); // Next highest (2)
        Assert.AreEqual("A", queue.Dequeue()); // Lowest (1)
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority, dequeue to verify FIFO order
    // Expected Result: Returns items in FIFO order for equal priorities
    // Defect(s) Found: FIFO not respected for equal priorities. Item not removed.
    public void TestPriorityQueue_2()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 2);
        queue.Enqueue("B", 2);
        queue.Enqueue("C", 2);
        Assert.AreEqual("A", queue.Dequeue()); // First enqueued
        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("C", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Throws InvalidOperationException with "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_Empty()
    {
        var queue = new PriorityQueue();
        try
        {
            queue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}