/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create two customer service, one with a valida size (5) and other with an invalid size (-2), and the second one needs to show a size of 10 after the creation:
        // CustomerServiceValidSize = new CustomerService(5);
        // CustomerServiceinvalidSize = new CustomerService(-2);
        // Expected Result: 
        Console.WriteLine("Test 1");

        var CustomerServiceValidSize = new CustomerService(5);
        var CustomerServiceInvalidSize = new CustomerService(-2);
        // Defect(s) Found: 

        Console.WriteLine("Customer Service Valid (should be 5): " + CustomerServiceValidSize.ToString());
        Console.WriteLine("Customer Service invalid (should be 10): " + CustomerServiceInvalidSize.ToString());

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Running the AddNewCustomer should add a customer to the Queue
        // Expected Result: [size=1 max_size=2 => Customer(id): problem]
        Console.WriteLine("Test 2");

        var CustomerServiceAddToQueue = new CustomerService(2);


        CustomerServiceAddToQueue.AddNewCustomer();

        Console.WriteLine(CustomerServiceAddToQueue);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Should arise a warning when we try to add more customers than the allowed
        // Expected Result: "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 3");

        CustomerServiceAddToQueue.AddNewCustomer();
        CustomerServiceAddToQueue.AddNewCustomer();

        Console.WriteLine(CustomerServiceAddToQueue);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 4
        // Scenario: function shall dequeue the next customer from the queue and display the details
        // Expected Result: Information of the first customer added to the queue
        Console.WriteLine("Test 4");

        CustomerServiceAddToQueue.ServeCustomer();

        Console.WriteLine(CustomerServiceAddToQueue);
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 5
        // Scenario: If the queue is empty when trying to serve a customer, then an error message will be displayed
        // Expected Result: "The Customer Service is empty."
        Console.WriteLine("Test 5");

        Console.WriteLine("Removing the last Customer");
        CustomerServiceAddToQueue.ServeCustomer();

        Console.WriteLine("====Trying to Serve Another customer, should throw an error====");
        CustomerServiceAddToQueue.ServeCustomer();

        Console.WriteLine(CustomerServiceAddToQueue);
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {

        if (_queue.Count == 0) {
            Console.WriteLine("The Customer Service is empty.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}