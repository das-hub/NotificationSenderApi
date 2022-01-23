using NotificationSenderApi.DataAccess.Enums;

namespace NotificationSenderApi.DataAccess.Models;

public class NotificationBase : INotification
{
    public virtual Guid Id { get; set; } = Guid.NewGuid();
    public virtual State State { get; set; } = State.NotDelivered;
    public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
}