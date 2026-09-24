namespace InventoryManagementSystem
{
    internal class Program
    {

        
        /*
         * Main method is the entry point of the application.
         * It creates an instance of the MyInventorySystem class and calls its Run method to start the application.
         */
        static void Main(string[] args)
        {
            MyInventorySystem myInventorySystem = new MyInventorySystem();
            myInventorySystem.Run();



        }
    }
}
