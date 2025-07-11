namespace DesignPattern.Services;

public class AccauntNotification : INotificationStrategy
{
    public void Send(string message)
    {
        Console.WriteLine($"[Accaunt Notification] Sent: {message}");
    }
}