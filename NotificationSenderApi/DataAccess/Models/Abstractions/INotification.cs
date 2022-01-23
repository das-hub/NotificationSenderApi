using NotificationSenderApi.DataAccess.Enums;

namespace NotificationSenderApi.DataAccess.Models;

public interface INotification : IEntity
{
    State State { get; set; }
    DateTime CreatedAt { get; set; }
}