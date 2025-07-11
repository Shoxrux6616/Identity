using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Services;

public static class NotificationFactory
{
    public static INotificationStrategy CreateStrategy(string type)
    {
        return type.ToLower() switch
        {
            "email" => new EmailNotification(),
            "sms" => new SmsNotification(),
            "accaunt" => new AccauntNotification(),
            _ => throw new ArgumentException("Unsupported notification type")
        };
    }
}

