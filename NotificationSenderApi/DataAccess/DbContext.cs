using NotificationSenderApi.DataAccess.Abstractions;
using NotificationSenderApi.DataAccess.Models;

namespace NotificationSenderApi.DataAccess;

public class DbContext : IDbContext
{
    public List<AndroidNotification> AndroidNotifications { get; set; } = new List<AndroidNotification>();
    public List<IOSNotification> IosNotifications { get; set; } = new List<IOSNotification>();
    public List<RegistryNotification> RegistryNotifications { get; set; } = new List<RegistryNotification>();
}