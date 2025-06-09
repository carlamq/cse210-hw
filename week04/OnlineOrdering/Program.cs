using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Texas", "TX", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Eyelash", "L002", 99.99, 5));
        order1.AddProduct(new Product("Lipstick", "L003", 19.99, 2));
        order1.AddProduct(new Product("Foundation", "L004", 29.99, 1));

        Address address2 = new Address("456 Elm St", "Quebec", "QC", "Canada");
        Customer customer2 = new Customer("John Doe", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mascara", "L005", 24.99, 3));
        order2.AddProduct(new Product("Nail Polish", "L006", 14.99, 4));

        Console.Clear();
        Console.WriteLine("New orders have been placed!\n");
        Console.WriteLine("******************************************");
        Console.WriteLine();
        Console.WriteLine("Order 1:");
        PrintOrderDetails(order1);
        Console.WriteLine("******************************************");
        Console.WriteLine("Order 2:");
        PrintOrderDetails(order2);
    }

    static void PrintOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine($"Total Products: {order.GetTotalCost() - (order.GetCustomer().LivesInUSA() ? 5 : 35)}");
        Console.WriteLine($"Total Shipping: ${(order.GetCustomer().LivesInUSA() ? 5 : 35)}");
        Console.WriteLine($"TOTAL COST: ${order.GetTotalCost():F2}");
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
    }

}