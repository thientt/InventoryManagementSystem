/*
    entity this will container all Product related information
    Example: Add Product, Remove Product, Update Product (only Quantity), Get All Products
*/

public class Inventory
{
    private readonly List<Product> products;

    public Inventory()
    {
        products = [];
    }

    public int Count => products.Count;

    // Method to add a product to the inventory
    public Response AddProduct(Product product)
    {
        if (product.IsValid())
        {
            // Assign a new Id
            product.Id = products.Count > 0 ? products[^1].Id + 1 : 1;
            products.Add(product);
            return new Response(true, "Product added successfully.");
        }
        return new Response(false, "Invalid product details.");
    }

    // Method to remove a product from the inventory by Id
    public Response RemoveProduct(int productId)
    {
        var product = products.Find(p => p.Id == productId);
        if (product != null)
        {
            products.Remove(product);
            return new Response(true, "Product removed successfully.");
        }
        return new Response(false, "Product not found.");
    }

    // Method to update the quantity of a product
    public Response UpdateProductQuantity(int productId, int newQuantity)
    {
        var product = products.Find(p => p.Id == productId);
        if (product != null && newQuantity >= 0)
        {
            product.Quantity = newQuantity;
            return new Response(true, "Product quantity updated successfully.");
        }
        return new Response(false, "Product not found or invalid quantity.");
    }
    // Method to get all products in the inventory
    public List<Product> GetAllProducts() => [.. products];
}