using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: add items with priorities and remove highest priority item
    // Expected Result: Item with hightes priority is removed first.
    // Defect(s) Found: Last item in queue wasn't being checked for hightest priority
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Middle", 2);
        priorityQueue.Enqueue("High", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Add multiple items with highest priority
    // Expected Result: First item with highest priority is removed first. 
    // Defect(s) Found: Doesn't follow firs in first out rules for multiple high priority items.
    public void TestPriorityQueue_FirstHighest()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High1", 5);
        priorityQueue.Enqueue("High2", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("High1", result);
    }

    [TestMethod]
    // Scenario: remove item and show it's removed from the queue
    // Expected Result: Removed item not returned again after dequeue. 
    // Defect(s) Found: Item was not being removed from the queue
    public void TestPriorityQueue_Removed()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Low", 1);

        var high = priorityQueue.Dequeue();
        var low = priorityQueue.Dequeue();

        Assert.AreEqual("High", high);
        Assert.AreEqual("Low", low);
    }

    [TestMethod]
    // Scenario: dequeue from an empty queue
    // Expected Result: invalid operation exception error thrown with message
    // Defect(s) Found: None, error thrown with message as expected.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try

        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected an exception");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}