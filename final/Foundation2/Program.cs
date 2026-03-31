class Program
{
    static void Main(string[] args)
    {
        //Order 1: Local customer
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Homer Simpson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-1042", 29.99, 1));
        order1.AddProduct(new Product("USB-C Hub", "UC-2201", 45.00, 2));
        order1.AddProduct(new Product("Laptop Stand", "LS-0887", 35.50, 1));

        Console.WriteLine("============================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Order Total: ${order1.GetTotalPrice():F2}");
        Console.WriteLine("(Includes $5.00 domestic shipping)");

        Console.WriteLine();

        //Order 2: International customer
        Address address2 = new Address("10 Downing Street", "London", "England", "UK");
        Customer customer2 = new Customer("James Bennett", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "MK-5530", 89.99, 1));
        order2.AddProduct(new Product("Monitor Light Bar", "ML-3301", 42.00, 1));

        Console.WriteLine("============================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Order Total: ${order2.GetTotalPrice():F2}");
        Console.WriteLine("(Includes $35.00 international shipping)");
    }
}