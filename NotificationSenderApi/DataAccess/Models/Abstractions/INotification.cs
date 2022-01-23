using NotificationSenderApi.DataAccess.Enums;

namespace NotificationSenderApi.DataAccess.Models.Abstractions;

public interface INotification : IEntity
{
    State State { get; set; }
    DateTime CreatedAt { get; set; }
}