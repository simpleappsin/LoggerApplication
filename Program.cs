namespace LoggerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the username: ");
            string username = Console.ReadLine();
            LoggerManagement lm = new LoggerManagement(username);
        }
    }
}
