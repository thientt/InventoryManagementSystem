/* How to create a Product Entity with properties like Id, Name, Price, and Quantity in C#.
With: Id is Auto-Implemented Property of type int */
public class Product
{
    public int Id { get; set; }  // Auto-Implemented Property for Product ID
    public string Name { get; set; }  // Property for Product Name
    public decimal Price { get; set; }  // Property for Product Price
    public int Quantity { get; set; }  // Property for Product Quantity

    // Constructor to initialize a Product
    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    // Method validateing the product details
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Name) && Price >= 0 && Quantity >= 0;
    }
}