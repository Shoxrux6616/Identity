namespace DesignPattern.Services;

public class SmsNotification : INotificationStrategy
{
    public void Send(string message)
    {
        Console.WriteLine($"[SMS] Sent: {message}");
    }
}
