using NotificationSenderApi.DataAccess.Enums;
using NotificationSenderApi.DataAccess.Models.Abstractions;

namespace NotificationSenderApi.DataAccess.Models;

public abstract class NotificationBase : INotification
{
    public virtual Guid Id { get; set; } = Guid.NewGuid();
    public virtual State State { get; set; } = State.NotDelivered;
    public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
}