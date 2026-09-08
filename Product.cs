using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem
{
    internal class Product
    {
        internal Product()
        {
            ProductId = 0;
            Name = string.Empty;
            Price = 0.0m;
            Quantity = 0;
            Next = null;
        }

        public Product? Next { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


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
