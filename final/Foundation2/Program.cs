using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string Name { get { return name; } }
    public string ProductId { get { return productId; } }
    public double Price { get { return price; } }
    public int Quantity { get { return quantity; } }

    public double TotalCost()
    {
        return price * quantity;
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string Street { get { return street; } }
    public string City { get { return city; } }
    public string State { get { return state; } }
    public string Country { get { return country; } }

    public bool IsUSA()
    {
        return country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name { get { return name; } }
    public Address Address { get { return address; } }

    public bool LivesInUSA()
    {
        return address.IsUSA();
    }
}

class Order
{
    private Customer customer;
    private List<Product> products;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double TotalCost()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.TotalCost();
        }
        double shippingCost = customer.LivesInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public string PackingLabel()
    {
        string label = "";
        foreach (Product product in products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"{customer.Name}\n{customer.Address}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating products
        Product product1 = new Product("Laptop", "123", 999.99, 1);
        Product product2 = new Product("Mouse", "456", 25.50, 2);
        Product product3 = new Product("Keyboard", "789", 75.00, 1);

        Product product4 = new Product("Monitor", "101", 300.00, 1);
        Product product5 = new Product("USB Cable", "102", 10.00, 3);

        // Creating addresses
        Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");

        // Creating customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Creating orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Displaying order details
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine("\nOrder 1 Shipping Label:");
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine($"\nOrder 1 Total Cost: ${order1.TotalCost():0.00}");

        Console.WriteLine("\n-----------------------------\n");

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine("\nOrder 2 Shipping Label:");
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"\nOrder 2 Total Cost: ${order2.TotalCost():0.00}");
    }
}
