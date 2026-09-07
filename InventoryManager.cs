using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem
{
    internal class InventoryManager
    {
        private static int productIdCounter = 1;
        private static List<Product> inventory = new List<Product>();


        internal static void AddProduct(Product productToAdd)
        {

            if (inventory.Contains(productToAdd))
            {

                
            }

            productToAdd.ProductId = productIdCounter++;
            inventory.Add(productToAdd);
        }


        internal static void DeleteProduct(Product productToDelete)
        {
            inventory.Remove(productToDelete);
        }


        internal static void UpdateProduct(Product productToUpdate)
        {

        }

        internal static void ViewProducts()
        {

        }

        internal static void GenerateReport()
        {

        }
    }
}
