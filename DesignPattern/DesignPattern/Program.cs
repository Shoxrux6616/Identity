using DesignPattern.Services;

namespace DesignPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose notification type (email/sms/accaunt):");
        string type = Console.ReadLine();
        type = type.ToLower();

        try
        {
            // Factory chooses the right strategy
            var strategy = NotificationFactory.CreateStrategy(type);

            // Context uses the strategy
            var notifier = new NotificationService(strategy);

            // Use the strategy
            notifier.Notify("Hello bro! You’ve got a message.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

