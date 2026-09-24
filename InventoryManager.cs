using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem
{
    internal class InventoryManager
    {
        internal static int productIdCounter = 1;  // Counter for generating unique product IDs not the same as how many products are in the inventory
        private static Product? firstProduct = null;         // First product in linked list
        private static Product? lastProduct = null;          // Last product in linked list
        internal static bool isDirty = false;               // Shows if the inventory has been modified since last ViewProducts or SaveToFile

        internal static int productCount = 0; // Counter for the number of products

        

        /*
         * AddProduct method adds a new product to the inventory.
         * It checks if a product with the same name already exists.
         * If not, it adds the product to the inventory and returns a success message.
         * If a product with the same name already exists, it returns an error message.
         */
        internal static string AddProduct(Product productToAdd)
        {
            if (CheckForDuplicateProductName(productToAdd.Name))
            {

                return "Error: A product with the same name already exists.";
            }
            else
            {
                if(productToAdd.ProductId == 0) // If the product ID is not set, assign a new unique ID
                {
                    productToAdd.ProductId = productIdCounter++;
                }
                else if (productToAdd.ProductId >= productIdCounter) // Ensure the counter is always ahead of any manually set IDs
                {
                    productIdCounter = productToAdd.ProductId + 1;
                }
                if (firstProduct == null)
                {
                    firstProduct = productToAdd;
                    lastProduct = productToAdd;
                }
                else
                {
                    lastProduct?.Next = productToAdd;
                    lastProduct = productToAdd;
                }
                productCount++; // Increment the product count
              

                isDirty = true;
                return productToAdd.Name + " has been added to the inventory.";
            }
        }

        /*
         * DeleteProduct method removes a product from the inventory based on its ID.
         * It searches for the product in the linked list and removes it if found.
         * If the product is not found, it returns an error message.
         */
        internal static void DeleteProduct(int productId)
        {
            Product? currentProduct = firstProduct;
            bool productFound = false;
            if (currentProduct?.ProductId == productId)
            {
                firstProduct = currentProduct.Next;
                productCount--;     // Decrement the product count
                isDirty = true;
                productFound = true;
                if (firstProduct == null)
                {

                    lastProduct = null; // List is now empty

                }

            }
            else
            {
                while (currentProduct?.Next != null)
                {
                    if (currentProduct.Next.ProductId == productId)
                    {
                        if (currentProduct.Next == lastProduct)
                        {
                            lastProduct = currentProduct; // Update lastProduct if we're deleting the last product
                        }
                        else
                        {
                            currentProduct.Next = currentProduct.Next.Next;
                        }

                        productCount--;     // Decrement the product count
                        isDirty = true;
                        productFound = true;

                    }
                    currentProduct = currentProduct.Next;
                }
            }
            if (productFound)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Product found and deleted."); // Product not found
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product not found."); // Product not found
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /*
         * DeleteProduct method removes a product from the inventory based on its name.
         * It searches for the product in the linked list and removes it if found.
         * If the product is not found, it returns an error message.
         */
        internal static void DeleteProduct(string productName)
        {
            Product? currentProduct = firstProduct;
            bool productFound = false;
            if (currentProduct!=null && currentProduct.Name.Equals(productName, StringComparison.OrdinalIgnoreCase))
            {
                firstProduct = currentProduct.Next;
                productCount--;     // Decrement the product count
                isDirty = true;
                productFound = true;
                if (firstProduct == null)
                {
                    lastProduct = null; // List is now empty
                }

            }
            else
            {
                while (currentProduct?.Next != null)
                {
                    if (currentProduct.Next.Name == productName)
                    {
                        if (currentProduct.Next == lastProduct)
                        {
                            lastProduct = currentProduct; // Update lastProduct if we're deleting the last product

                        }
                        else
                        {
                            currentProduct.Next = currentProduct.Next.Next;
                        }
                        productCount--;     // Decrement the product count
                        isDirty = true;
                        productFound = true;


                    }
                    currentProduct = currentProduct.Next;
                }
            }

            if (productFound)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Product found and deleted."); // Product not found
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product not found."); // Product not found
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }


        /*
         * UpdateProduct method updates a product's details by its ID.
         * It searches for the product in the linked list and updates its details if found.
         * If the product is not found, it returns an error message.
         */
        internal static bool UpdateProduct(Product updatedProduct)
        {
            Product? currentProduct = firstProduct;
            while (currentProduct != null)
            {
                if (currentProduct.ProductId == updatedProduct.ProductId)
                {
                    currentProduct.Name = updatedProduct.Name;
                    currentProduct.Price = updatedProduct.Price;
                    currentProduct.Quantity = updatedProduct.Quantity;

                    isDirty = true;
                    return true; // Product found and updated
                }
                currentProduct = currentProduct.Next;

            }
            
            return false;  // Product not found
        }

        
        /*
         * ViewProducts method displays all products in the inventory.
         * It prints the product details at the specified x and y coordinates in the console.
         */
        internal static void ViewProducts(int x, int y)
        {
            Product? currentProduct = firstProduct;
            Console.SetCursorPosition(x, y);
            Console.Write("ProductId");
            Console.SetCursorPosition(x + 10, y);
            Console.Write("| Name");
            Console.SetCursorPosition(x + 30, y);
            Console.Write("| Price");
            Console.SetCursorPosition(x + 40, y);
            Console.Write("| Quantity");
            y++; // Move to the next line for product details

            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine("                                                           ");
            }

            while (currentProduct != null)
            {

                Console.SetCursorPosition(x, y);
                Console.Write(currentProduct.ProductId);
                Console.SetCursorPosition(x + 10, y);
                Console.Write("| " + currentProduct.Name);
                Console.SetCursorPosition(x + 30, y);
                Console.Write("| " + currentProduct.Price);
                Console.SetCursorPosition(x + 40, y);
                Console.Write("| " + currentProduct.Quantity);

                y++; // Move to the next line
                currentProduct = currentProduct.Next;
            }

            isDirty = false; // Reset the dirty flag after viewing products
        }


        /*
         * ViewProduct method displays a single product's details at the specified x and y coordinates in the console.
         */
        internal static void ViewProduct(int x, int y, Product product)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("ProductId");
            Console.SetCursorPosition(x + 10, y);
            Console.Write("| Name");
            Console.SetCursorPosition(x + 30, y);
            Console.Write("| Price");
            Console.SetCursorPosition(x + 40, y);
            Console.Write("| Quantity");

            y++; // Move to the next line for product details
            Console.SetCursorPosition(x, y);
            Console.Write(product.ProductId);
            Console.SetCursorPosition(x + 10, y);
            Console.Write("| " + product.Name);
            Console.SetCursorPosition(x + 30, y);
            Console.Write("| " + product.Price);
            Console.SetCursorPosition(x + 40, y);
            Console.Write("| " + product.Quantity);


        }


        /*
         * GenerateReport method generates a report of all products in the inventory and saves it to a file.
         * It calculates the total value of the inventory and appends it to the report.
         */
        internal static void GenerateReport()
        {
            // Implementation for saving to a file

            Product currentProduct = firstProduct;
            int totalValue = 0;
            string productData;
            if (System.IO.File.Exists("generated_report.txt"))
            {
                System.IO.File.Delete("generated_report.txt");
            }
            while (currentProduct != null)
            {
                totalValue += (int)(currentProduct.Price * currentProduct.Quantity);

                productData = $"ProductId: {currentProduct.ProductId}, \tProductName: {currentProduct.Name}, \tProductPrice: {currentProduct.Price}, \tProductQuantity: {currentProduct.Quantity}";
              
                System.IO.File.AppendAllText("generated_report.txt", productData + Environment.NewLine);

                currentProduct = currentProduct.Next;
            }
            System.IO.File.AppendAllText("generated_report.txt", "Total Value: " + totalValue + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Report generated.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }


        /*
         * SaveToFile method saves the current inventory to a file.
         * It writes each product's details to the file in a comma-separated format.
         */
        internal static void SaveToFile()
        {

            Product currentProduct = firstProduct;
            string productData;

            // create code that deletes the file if it already exists before saving the new data
            if (System.IO.File.Exists("inventory.txt"))
            {
                System.IO.File.Delete("inventory.txt");
            }

            while (currentProduct != null)
            {

                productData = $"{currentProduct.ProductId},{currentProduct.Name},{currentProduct.Price},{currentProduct.Quantity}";

                System.IO.File.AppendAllText("inventory.txt", productData + Environment.NewLine);

                currentProduct = currentProduct.Next;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Inventory saved to file.");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();  
            Console.ForegroundColor = ConsoleColor.White;

        }

        /*
         * LoadFromFile method loads the inventory from a file.
         * It reads each line from the file and creates a new product for each line.
         * If a product with the same ID or name already exists, it skips adding that product.
         */
        internal static void LoadFromFile()
        {
            // Implementation for loading from a file
            if (System.IO.File.Exists("inventory.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines("inventory.txt");
                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');
                    if (fields.Length == 4)
                    {
                        Product newProduct = new Product();
                        newProduct.ProductId = int.Parse(fields[0]);
                        newProduct.Name = fields[1];
                        newProduct.Price = decimal.Parse(fields[2]);
                        newProduct.Quantity = int.Parse(fields[3]);
                        if(InventoryManager.CheckForDuplicateProductId(newProduct.ProductId) || InventoryManager.CheckForDuplicateProductName(newProduct.Name))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Duplicate Product {newProduct.ProductId} found in file.");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue; // Skip adding this product
                        }
                        AddProduct(newProduct);
                        // Create a new product and add it to the inventory
                        // Add the new product to the linked list
                        // (Assuming there's a method to add a product to the linked list)
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Inventory loaded from file.");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }


        /*
         * GetProductById method gets a product by its ID.
         * It searches for the product in the linked list and returns it if found.
         * If the product is not found, it returns null.
         * This method is used to retrieve a product's information for the user to update or delete a product.
         */
        internal static Product GetProductById(int productId)
        {
            Product? currentProduct = firstProduct;
            while (currentProduct != null)
            {
                if (currentProduct.ProductId == productId)
                {
                    return currentProduct; // Product found
                }
                currentProduct = currentProduct.Next;
            }
            return null; // Product not found
        }


        /*
         * GetProductByName method gets a product by its name.
         * It searches for the product in the linked list and returns it if found.
         * If the product is not found, it returns null.
         * This method is used to retrieve a product's information for the user to update or delete a product.
         */
        internal static Product GetProductByName(string productName)
        {
            Product? currentProduct = firstProduct;
            while (currentProduct != null)
            {
                if (currentProduct.Name.Equals(productName, StringComparison.OrdinalIgnoreCase))
                {
                    return currentProduct; // Product found
                }
                currentProduct = currentProduct.Next;
            }
            return null; // Product not found
        }



        /*
         * CheckForDuplicateProductName method checks if a product with the same name already exists in the inventory.
         * It searches for the product in the linked list and returns true if found.
         * If the product is not found, it returns false.
         * This method is used to prevent adding duplicate products to the inventory.
         */
        internal static bool CheckForDuplicateProductName(string productName)
        {
            Product? currentProduct = firstProduct;

            while (currentProduct != null)
            {
                if (currentProduct.Name.Equals(productName, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Duplicate found
                }
                currentProduct = currentProduct.Next; // Move to the next product in the linked list
            }

            return false;
        }

        /*
         * CheckForDuplicateProductId method checks if a product with the same ID already exists in the inventory.
         * It searches for the product in the linked list and returns true if found.
         * If the product is not found, it returns false.
         * This method is used to prevent adding duplicate products to the inventory.
         */
        internal static bool CheckForDuplicateProductId(int productId)
        {
            Product? currentProduct = firstProduct;

            while (currentProduct != null)
            {
                if (currentProduct.ProductId == productId)
                {
                    return true; // Duplicate found
                }
                currentProduct = currentProduct.Next; // Move to the next product in the linked list
            }

            return false;
        }

        /*
         * UpdateInventoryValue method calculates the total value of the inventory.
         * It iterates through the linked list of products and sums up the value of each product (Price * Quantity).
         * It returns the total value as a decimal.
         */
        internal static decimal UpdateInventoryValue()
        {
            decimal totalValue = 0;

            Product? currentProduct = firstProduct;
            while (currentProduct != null)
            {
                totalValue += currentProduct.Price * currentProduct.Quantity;
                currentProduct = currentProduct.Next;
            }

            return totalValue;
        }
    }
}
