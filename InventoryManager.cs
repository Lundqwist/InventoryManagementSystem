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
        internal static bool isDirty = false;

        internal static int productCount = 0; // Counter for the number of products

        


        // Add a new product to the inventory
        internal static string AddProduct(Product productToAdd)
        {
            if (CheckForDuplicateProductName(productToAdd.Name))
            {

                return "Error: A product with the same name already exists.";
            }
            else
            {
                productToAdd.ProductId = productIdCounter++;
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


        // Delete a product by its ID
        internal static string  DeleteProduct(int productId)
        {
            Product? currentProduct = firstProduct;
            if (currentProduct?.ProductId == productId)
            {
                firstProduct = currentProduct.Next;
                productCount--;     // Decrement the product count
                isDirty = true;
                if (firstProduct == null)
                {

                    lastProduct = null; // List is now empty
                    return "Last product found and deleted. \nList is now empty.";        // Product found and deleted
                }
                return "Product found and deleted.";        // Product found and deleted
            }

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
                    return "Product found and deleted.";        // Product found and deleted
                }
            }


            return "Product not found."; // Product not found
        }

        // if deletion by product name is needed, this method can be used
        internal static string DeleteProduct(string productName)
        {
            Product? currentProduct = firstProduct;

            if (currentProduct!=null && currentProduct.Name.Equals(productName, StringComparison.OrdinalIgnoreCase))
            {
                firstProduct = currentProduct.Next;
                productCount--;     // Decrement the product count
                isDirty = true;
                if (firstProduct == null)
                {

                    lastProduct = null; // List is now empty
                    return "Last product found and deleted. \nList is now empty.";        // Product found and deleted
                }
                return "Product found and deleted.";        // Product found and deleted
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

                        return "Product found and deleted.";        // Product found and deleted
                    }
                    currentProduct = currentProduct.Next;
                }
            }

            return "Product not found."; // Product not found
        }

       


        // Update a product's details by its ID
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

        
        
        // View all products in the inventory and print them at given x and y coordinates in the console
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



        internal static void GenerateReport()
        {

        }

        
        // Get a product by its ID. as information for the user to update or delete a product
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


        // Check for duplicate product name
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
