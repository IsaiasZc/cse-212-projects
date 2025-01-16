using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a Queue and add the items at the end of the queue: Noah (1), Brandon (2), Isaiah(3), Spencer (4), Henry (2)
    // Expected Result: Isaiah, Brandon, Noah, Spencer
    // Defect(s) Found: 
    public void TestPriorityQueue_AddingToTheQueue()
    {
        var priorityQueue = new PriorityQueue();

        // Act: Enqueue elements with their respective priorities
        priorityQueue.Enqueue("Noah", 4);
        priorityQueue.Enqueue("Brandon", 2);
        priorityQueue.Enqueue("Isaiah", 3);
        priorityQueue.Enqueue("Spencer", 4);
        priorityQueue.Enqueue("Henry", 2);

        // Expected order of dequeued elements
        var expectedOrder = "[Noah (Pri:4), Brandon (Pri:2), Isaiah (Pri:3), Spencer (Pri:4), Henry (Pri:2)]";

        Debug.WriteLine(priorityQueue.ToString());

        // Assert: Validate if every item was added at the end
        Assert.AreEqual(expectedOrder, priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Create a Queue with the following people and Priority: Noah (4), Brandon (6), Isaiah(7), Spencer (3)
    // Expected Result: Isaiah, Brandon, Noah, Spencer
    // Defect(s) Found: 
    public void TestPriorityQueue_orderPrioority()
    {
        var priorityQueue = new PriorityQueue();

        // Act: Enqueue elements with their respective priorities
        priorityQueue.Enqueue("Noah", 4);
        priorityQueue.Enqueue("Brandon", 6);
        priorityQueue.Enqueue("Isaiah", 7);
        priorityQueue.Enqueue("Spencer", 3);

        // Expected order of dequeued elements
        var expectedOrder = new List<string> { "Isaiah", "Brandon", "Noah", "Spencer" };

        // Assert: Validate the order of elements returned by Dequeue
        foreach (var expected in expectedOrder)
        {
            var actual = priorityQueue.Dequeue();
            
            Assert.AreEqual(expected, actual, $"Expected {expected} but got {actual}");
        }
    }

    [TestMethod]
    // Scenario: Create a Queue with the following people and Priority: Noah (4), Brandon (6), Blake (6), Isaiah(7), Spencer (3). Two of them has the same priority
    // Expected Result: Isaiah, Brandon, Blake, Noah, Spencer
    // Defect(s) Found: 
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();

        // Act: Enqueue elements with their respective priorities
        priorityQueue.Enqueue("Noah", 4);
        priorityQueue.Enqueue("Brandon", 6);
        priorityQueue.Enqueue("Blake", 6);
        priorityQueue.Enqueue("Isaiah", 7);
        priorityQueue.Enqueue("Spencer", 3);

        // Expected order of dequeued elements
        var expectedOrder = new List<string> { "Isaiah", "Brandon", "Blake", "Noah", "Spencer" };

        // Assert: Validate the order of elements returned by Dequeue
        foreach (var expected in expectedOrder)
        {
            var actual = priorityQueue.Dequeue();
            
            Assert.AreEqual(expected, actual, $"Expected {expected} but got {actual}");
        }
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue
    // Expected Result: InvalidOperationException with a specific message is thrown
    public void TestPriorityQueue_EmptyQueue()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();

        // Act & Assert
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        
        // Verify the message of the exception
        Assert.AreEqual("The queue is empty.", exception.Message, "The exception message does not match the expected value.");
    }
}