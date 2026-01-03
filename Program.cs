internal class Program
{
    private static void Main(string[] args)
    {
        bool exit = false;
        List<string> tasks = [];
        Inventory inventory = new();

        while (!exit)
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Stock");
            Console.WriteLine("3. View all Products");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the product name: ");
                        string name = Console.ReadLine() ?? "";
                        Console.Write("Enter the product price: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal price))
                        {
                            Console.Write("Enter the product quantity: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity))
                            {
                                Product product = new(name, price, quantity);
                                Response response = inventory.AddProduct(product);
                                Console.WriteLine(response.Message);
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid price.");
                        }
                        break;
                    case 2:
                        // Update Stock
                        if (inventory.Count == 0)
                        {
                            Console.WriteLine("No products available.");
                        }
                        else
                        {
                            Console.Write("Enter the product ID to update: ");
                            if (int.TryParse(Console.ReadLine(), out int productId))
                            {
                                Console.Write("Enter the new quantity: ");
                                if (int.TryParse(Console.ReadLine(), out int newQuantity))
                                {
                                    Response response = inventory.UpdateProductQuantity(productId, newQuantity);
                                    Console.WriteLine(response.Message);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid quantity.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid product ID.");
                            }
                        }
                        break;
                    case 3:
                        //view all Products
                        List<Product> allProducts = inventory.GetAllProducts();
                        // print all products
                        foreach (var prod in allProducts)
                        {
                            Console.WriteLine($"Name: {prod.Name}, Price: {prod.Price}, Quantity: {prod.Quantity}");
                        }
                        break;
                    case 4:
                        // Remove Product
                        Console.Write("Enter the product ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeProductId))
                        {
                            Response response = inventory.RemoveProduct(removeProductId);
                            Console.WriteLine(response.Message);
                        }
                        else
                        {
                            Console.WriteLine("Invalid product ID.");
                        }
                        break;
                    case 5:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}