using NotificationSenderApi.Enums;

namespace NotificationSenderApi.DataAccess.Models;

public class RegistryNotification : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public OSTypes OsTypes { get; set; }
    public Guid NotificationId { get; set; }
}