/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1

        // Scenario: When trying to add a new customer, the queue is full
        // Expected Result: Display an error
        Console.WriteLine("Test 1");
        
        var queue = new CustomerService(2);
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        // Defect(s) Found: We should have seen Maximum number of customers in the queue

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Dequeue the customer and display the details
        // Expected Result: Display the details
        Console.WriteLine("Test 2");
        queue = new CustomerService(4);
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        queue.AddNewCustomer();

        queue.ServeCustomer();
        queue.ServeCustomer();
        queue.ServeCustomer();
        queue.ServeCustomer();
        

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        //Test 3
        //Scenario:  The queue is empty when trying to serve the customer (the dequeue)
        //Expected result: Display an error
        Console.WriteLine("Test 3");
        queue = new CustomerService(6);
        queue.ServeCustomer();

        Console.WriteLine("=================");

        // Defect(s) Found: 

        Console.WriteLine("=================");
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
        if (_queue.Count > _maxSize) {
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
        _queue.RemoveAt(0);
        var customer = _queue[0];
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