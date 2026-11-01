using System;

// ISP: Small, focused interface with a single contract
public interface INotification
{
    void Send(string message);
}

// SRP & OCP: Individual implementations extending behavior safely
public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[Email Gateway]: {message}");
}

public class SmsNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[SMS Gateway]: {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[Push Notification Service]: {message}");
}

// DIP: Depends strictly on INotification abstraction, never on concrete channels
public class NotificationService
{
    private readonly INotification _notificationChannel;

    public NotificationService(INotification notificationChannel)
    {
        _notificationChannel = notificationChannel;
    }

    public void NotifyUser(string message)
    {
        _notificationChannel.Send(message);
    }
}

// Execution Driver
class Program
{
    static void Main()
    {
        // Testing runtime substitution across all principles
        INotification channel = new SmsNotification();
        NotificationService service = new NotificationService(channel);
        
        service.NotifyUser("Your final year project defense schedule has been updated.");
    }
}