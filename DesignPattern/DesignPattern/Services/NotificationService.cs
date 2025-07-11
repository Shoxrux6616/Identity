using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Services;

public class NotificationService
{
    private readonly INotificationStrategy _notificationStrategy;

    public NotificationService(INotificationStrategy notificationStrategy)
    {
        _notificationStrategy = notificationStrategy;
    }

    public void Notify(string message)
    {
        _notificationStrategy.Send(message);
    }
}