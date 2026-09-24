using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem
{
    internal class Product
    {




        /*
         * Constructor for the Product class.
         * Initializes the product properties with default values.
         */
        internal Product()
        {
            ProductId = 0;
            Name = string.Empty;
            Price = 0.0m;
            Quantity = 0;
            Next = null;
        }

        public Product? Next { get; set; }                      // Pointer to the next product in the linked list
        public int ProductId { get; set; }                      // Unique identifier for the product
        public string Name { get; set; }                        // Name of the product
        public decimal Price { get; set; }                      // Price of the product
        public int Quantity { get; set; }                       // Quantity of the product in stock

        // Method to display product information at a specific console position
        internal void DisplayProductInfo(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write($"Product ID: {ProductId}");
            Console.SetCursorPosition(x + 10, y);
            Console.Write($"Name: {Name}");
            Console.SetCursorPosition(x + 30, y);
            Console.Write($"Price: {Price:C}");
            Console.SetCursorPosition(x + 35, y + 1);
            Console.Write($"Quantity: {Quantity}");
        }
        


    }
}
