using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem
{
    internal class MyInventorySystem
    {

        private bool isRunning = true;




        internal MyInventorySystem()
        {


        }

        internal void Run()
        {

            while (isRunning)
            {
                Menu();
            }


        }

        internal void Menu()
        {
            Console.Clear();
            Console.WriteLine(" Welcome to the Inventory Management System!");
            Console.WriteLine(" Please select an option:\n");
            Console.WriteLine(" 1. Add Product");
            Console.WriteLine(" 2. Update Product");
            Console.WriteLine(" 3. Delete Product");
            Console.WriteLine(" 4. View Inventory");
            Console.WriteLine(" 5. Generate Report\n");
            Console.WriteLine(" 9. Exit\n");

            Console.Write(" Menu choice: ");
            string choice = Console.ReadLine()?.Trim() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateProduct();
                    break;
                case "3":
                    DeleteProduct();
                    break;
                case "4":
                    ViewProducts();
                    break;
                case "5":
                    GenerateReport();
                    break;
                case "9":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Menu();
                    break;
            }



            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        internal void AddProduct()
        {
            Product newProduct = new Product();

            Console.WriteLine("Enter product name:");
            newProduct.Name = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.WriteLine("Enter product price:");
            newProduct.Price = decimal.Parse(Console.ReadLine()?.Trim() ?? "0");

            Console.WriteLine("Enter product quantity:");
            newProduct.Quantity = int.Parse(Console.ReadLine()?.Trim() ?? "0");

            InventoryManager.AddProduct(newProduct);

        }

        internal void UpdateProduct()
        {
        }

        internal void DeleteProduct()
        {
        }

        internal void ViewProducts()
        {
        }

        internal void GenerateReport()
        {



        }


        private string NameFormatting(string nameInput)
        {
            Console.WriteLine("Enter product name:");
            if (string.IsNullOrWhiteSpace(nameInput))
            {
                Console.WriteLine("Product name cannot be empty. Please try again.");
            }

            return nameInput;
        }
    }
}
