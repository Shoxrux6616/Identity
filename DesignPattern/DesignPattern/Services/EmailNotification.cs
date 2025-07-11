namespace DesignPattern.Services;

public class EmailNotification : INotificationStrategy
{
    public void Send(string message)
    {
        Console.WriteLine($"[Email] Sent: {message}");
    }
}
