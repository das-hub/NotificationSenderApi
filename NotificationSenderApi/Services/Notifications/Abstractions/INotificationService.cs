using NotificationSenderApi.DataAccess.Models;
using NotificationSenderApi.Rpc;

namespace NotificationSenderApi.Services.Notifications.Abstractions;

public interface INotificationService
{
    Task<SendResultRpc> SendAsync(NotificationBase notification);
    Task<SendResultRpc> GetStateAsync(Guid notificationId);
}