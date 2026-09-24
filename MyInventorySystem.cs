using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventoryManagementSystem
{
    internal class MyInventorySystem
    {

        private bool isRunning = true;                      // Flag to control the main loop of the inventory management system

        /*
         * Run method is the main entry point of the inventory management system.
         * It runs a loop that displays the menu and processes user input until the user chooses to exit.
         * The method calls the Menu method to display the menu and handle user input.
         */
        internal void Run()
        {

            while (isRunning)
            {
                Menu();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue... \nThe program will now exit.");
            Console.ReadKey();
        }

        /*
         * Menu method displays the main menu of the inventory management system.
         * It shows the current status of the product list, number of products, and total inventory value.
         * The user can select an option to add, update, delete, view products, generate a report, save to file, load from file, or exit the program.
         * 
         * The method uses a switch statement to handle user input and call the appropriate methods for each option.
         * Invalid input is handled by displaying an error message and prompting the user to try again.
         */
        internal void Menu()
        {

            //Console.Clear();
            for (int y = 0; y < 27; y++)
            {
                Console.SetCursorPosition(0, y);

                Console.WriteLine("                                             |");
            }


            Console.SetCursorPosition(47, 0);
            if (InventoryManager.isDirty)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Productlist is changed. ");
            
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Productlist is current. ");

            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(80, 0);
            Console.Write("products:     ");
            if (InventoryManager.productCount == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.SetCursorPosition(90, 0);
            Console.Write(InventoryManager.productCount);

            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(95, 0);
            Console.Write("Inventory Value:       ");
            if (InventoryManager.UpdateInventoryValue() <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;

            }
            Console.SetCursorPosition(112, 0);

            Console.WriteLine(InventoryManager.UpdateInventoryValue());
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(47, 1);
            Console.WriteLine("Current productlist.");


            Console.SetCursorPosition(0, 0);
            Console.WriteLine(" Welcome to the Inventory Management System!");
            Console.WriteLine(" Please select an option:\n");
            Console.WriteLine(" 1. Add Product");
            Console.WriteLine(" 2. Update Product");
            Console.WriteLine(" 3. Delete Product");
            Console.WriteLine(" 4. View Inventory");
            Console.WriteLine(" 5. Generate Report");
            Console.WriteLine(" 6. Save to File");
            Console.WriteLine(" 7. Load from File");

            Console.WriteLine(" 9. Exit\n");


            Console.SetCursorPosition(1, 11);
            Console.Write("Menu choice: ");
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

                case "6":
                    SaveToFile();
                    break;
                case "7":
                    LoadFromFile();
                    break;
                case "9":
                    isRunning = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;
                    Menu();
                    break;
            }

        }



        /*AddProduct . 
         * This method allows the user to add a new product to the inventory.
         * It prompts the user for the product's name, price, and quantity.
         * The input is validated and then added to the inventory.
         * 
         * Checks productname for duplication and prompts user to enter a new name if duplicate is found.
         * Sets price and quantity to 0 if user enters invalid input.
         * Checks price input for negative values and prompts user to enter a new price if negative value is found.
         * Checks quantity input for negative values and prompts user to enter a new quantity if negative value is found.
         * 
         */


        internal void AddProduct()
        {
            Product newProduct = new Product();
            bool newInput = false;

            // Input name
            while (!newInput)
            {
                newInput = true;
                Console.SetCursorPosition(0, 13);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("                                       ");
                }
                Console.SetCursorPosition(0, 13);
                Console.Write("Enter product name:");

                Console.SetCursorPosition(25, 13);
                string tmpName = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;


                // Check for duplicate product name and ensure it's not empty
                if (InventoryManager.CheckForDuplicateProductName(tmpName) == false && tmpName != string.Empty)
                {
                    tmpName = char.ToUpper(tmpName[0]) + tmpName.Substring(1); // Capitalize the first letter of the product name
                    newProduct.Name = tmpName;
                }
                else if (string.Empty == tmpName)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Product name is empty. \nPlease enter a different name.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    newInput = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Product name already exists. \nPlease enter a different name.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    newInput = false;
                }
            }

            // Input Price
            newInput = false;
            while (!newInput)
            {
                newInput = true;
                Console.SetCursorPosition(0, 13);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("                                       ");
                }
                
                Console.SetCursorPosition(0, 13);
                Console.Write("Enter product price:");
                Console.SetCursorPosition(25, 13);
                string tmpPrice = Console.ReadLine()?.Trim()?.Trim() ?? string.Empty;

                if (tmpPrice == string.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Price cannot be empty. \nPlease enter a valid price.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();

                    newInput = false;
                }
                else
                {
                    // Validate price input
                    try
                    {
                        decimal tmpPriceValue = decimal.Parse(tmpPrice ?? "0");

                        if (tmpPriceValue > 0)
                        {
                            newProduct.Price = tmpPriceValue;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Price cannot be negative. \nPlease enter a valid price.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey();
                            newInput = false;
                            return;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid price format. \nPlease enter a valid decimal number.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        newInput = false;
                    }
                }
            }

            // Input quantity
            newInput = false;
            while (!newInput)
            {
                newInput = true;
                Console.SetCursorPosition(0, 13);
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("                                       ");
                }
                Console.SetCursorPosition(0, 13);
                Console.Write("Enter product quantity:");
                Console.SetCursorPosition(25, 13);
                string tmpQuantity = Console.ReadLine()?.Trim() ?? string.Empty;

                // Validate quantity input
                try
                {
                    int tmpQuantityValue = int.Parse(tmpQuantity ?? "0");
                    if (tmpQuantityValue > 0)
                    {
                        newProduct.Quantity = tmpQuantityValue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Quantity cannot be negative. \nPlease enter a valid quantity.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        newInput = false;
                        return;
                    }

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid quantity format. \nPlease enter a valid integer.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    newInput = false;
                }
            }
            InventoryManager.AddProduct(newProduct);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product added successfully.");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;

        }


        /*UpdateProduct method allows the user to update an existing product in the inventory.
         * It prompts the user for the product's ID or name, retrieves the product, and displays its current details.
         * The user can then enter new values for the product's name, price, and quantity.
         * The input is validated and then updated in the inventory.
         * 
         * Checks for duplicate product name and prompts user to enter a new name if duplicate is found.
         * Sets price and quantity to 0 if user enters invalid input.
         * Checks price input for negative values and prompts user to enter a new price if negative value is found.
         * Checks quantity input for negative values and prompts user to enter a new quantity if negative value is found.
         */
        internal void UpdateProduct()
        {

            Product? productToChange = null;
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("Enter the ID or name of Product:");
            string input = Console.ReadLine()?.Trim() ?? string.Empty;
            if (input != string.Empty && InventoryManager.productCount != 0)
            {
                if (input.All(char.IsDigit))
                {
                    int productId = int.Parse(input);
                    productToChange = InventoryManager.GetProductById(productId);

                }
                else
                {
                    productToChange = InventoryManager.GetProductByName(input);

                }
                if (productToChange != null)
                {




                    if (productToChange != null)
                    {
                        InventoryManager.ViewProduct(0, 20, productToChange); // Display the product details before updating

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Product not found.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();

                    }

                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("Enter new value - empty = keep value");
                    bool newInput = false;
                    while (!newInput)
                    {
                        newInput = true;
                        Console.SetCursorPosition(0, 13);
                        Console.Write("Enter new name: ");
                        Console.SetCursorPosition(25, 13);
                        string tmpName = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;


                        // Check for duplicate product name and ensure it's not empty
                        if (tmpName.Length == 0)
                        {
                            // Nothing changes - no overwrite
                        }
                        else if (InventoryManager.CheckForDuplicateProductName(tmpName) == false)
                        {
                            if (tmpName.Length > 0)
                            {
                                tmpName = char.ToUpper(tmpName[0]) + tmpName.Substring(1); // Capitalize the first letter of the product name
                                productToChange?.Name = tmpName;

                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Product name already exists. \nPlease enter a different name.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey();
                            newInput = false;
                        }
                    }

                    newInput = false;
                    while (!newInput)
                    {
                        newInput = true;
                        Console.SetCursorPosition(0, 13);
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("                                       ");
                        }

                        Console.SetCursorPosition(0, 13);
                        Console.Write("Enter product price:");

                        Console.SetCursorPosition(25, 13);
                        string tmpPrice = Console.ReadLine()?.Trim()?.Trim() ?? string.Empty;

                        if (tmpPrice.Length > 0)
                        {
                            // Validate price input
                            try
                            {
                                decimal tmpPriceValue = decimal.Parse(tmpPrice ?? "0");

                                if (tmpPriceValue > 0)
                                {
                                    productToChange?.Price = tmpPriceValue;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Price cannot be negative. \nPlease enter a valid price.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadKey();
                                    newInput = false;
                                    return;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid price format. \nPlease enter a valid decimal number.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nPress any key to continue.");
                                Console.ReadKey();
                                newInput = false;
                            }
                        }
                    }

                    newInput = false;
                    while (!newInput)
                    {
                        newInput = true;
                        Console.SetCursorPosition(0, 13);
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("                                       ");
                        }

                        Console.SetCursorPosition(0, 13);
                        Console.Write("Enter product quantity:");

                        Console.SetCursorPosition(25, 13);
                        string tmpQuantity = Console.ReadLine()?.Trim() ?? string.Empty;

                        // Validate quantity input
                        if (tmpQuantity.Length > 0)
                        {

                            try
                            {
                                int tmpQuantityValue = int.Parse(tmpQuantity ?? "0");
                                if (tmpQuantityValue > 0)
                                {
                                    productToChange?.Quantity = tmpQuantityValue;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Quantity cannot be negative. \nPlease enter a valid quantity.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadKey();
                                    newInput = false;
                                    return;
                                }

                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid quantity format. \nPlease enter a valid integer.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nPress any key to continue.");
                                Console.ReadKey();
                                newInput = false;
                            }
                        }
                    }
                    InventoryManager.UpdateProduct(productToChange);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, 23);
                    Console.WriteLine("New product information: ");
                    InventoryManager.ViewProduct(0, 24, productToChange); // Display the product details before updating
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\nPress any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Product not found.");
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;

                }

                Console.SetCursorPosition(0, 20);
                for (int i = 0; i < 8; i++)
                {
                    Console.SetCursorPosition(0, 20 + i);

                    Console.WriteLine("                                                         ");
                }

            }
        }


        /*DeleteProduct method allows the user to delete an existing product from the inventory.
         * It prompts the user for the product's ID or name, retrieves the product, and deletes it from the inventory.
         * The input is validated and then deleted from the inventory.
         * 
         * If the input is empty, it will not delete anything and will display a message indicating that nothing was deleted.
         */
        internal void DeleteProduct()
        {

            Console.WriteLine("Delete product");
            Console.Write("Enter the ID or name:");
            string input = Console.ReadLine()?.Trim() ?? string.Empty;
            if (input != string.Empty)
            {
                if (input.All(char.IsDigit))
                {
                    int productId = int.Parse(input);
                    InventoryManager.DeleteProduct(productId);
                }
                else
                {
                    InventoryManager.DeleteProduct(input);
                }
            }
            else
            {
                input = "Nothing was deleted.";
            }

        }


        /*ViewProducts method displays the list of products in the inventory.
         * It calls the InventoryManager.ViewProducts method to display the products.
         * The products are displayed in a tabular format with their ID, name, price, and quantity.
         */
        internal void ViewProducts()
        {
            InventoryManager.ViewProducts(47, 3);
        }


        /*GenerateReport method generates a report of the products in the inventory.
         * It calls the InventoryManager.GenerateReport method to generate the report.
         * The report is displayed in a tabular format with their ID, name, price, and quantity.
         */
        internal void GenerateReport()
        {

            InventoryManager.GenerateReport();

        }


        /*SaveToFile method saves the current state of the inventory to a file.
         * It calls the InventoryManager.SaveToFile method to save the inventory to a file.
         * The file is saved in the current directory with the name "inventory.txt".
         */
        internal void SaveToFile()
        {
            InventoryManager.SaveToFile();
        }


        /*LoadFromFile method loads the inventory from a file.
         * It calls the InventoryManager.LoadFromFile method to load the inventory from a file.
         * The file is loaded from the current directory with the name "inventory.txt".
         */
        internal void LoadFromFile()
        {
            InventoryManager.LoadFromFile();
        }


        // An attempt at temporary error-messages that got removed after a while.
        // Not used because it also changes the current cursor position.
        void PrintErrorMessage(int x, int y, string message, TimeSpan delay, CancellationToken ct = default)
        {
            int xOld = Console.GetCursorPosition().Left;
            int yOld = Console.GetCursorPosition().Top;
            _ = Task.Run(async () =>
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(message);
                Console.SetCursorPosition(xOld, yOld);
                try
                {
                    await Task.Delay(delay, ct);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                Console.SetCursorPosition(x, y);
                Console.WriteLine("                                                                       ");
                Console.WriteLine("                                                                       ");

                Console.SetCursorPosition(xOld, yOld);
            });



        }




    }
}
