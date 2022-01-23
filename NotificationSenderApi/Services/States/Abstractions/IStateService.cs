using NotificationSenderApi.Rpc;

namespace NotificationSenderApi.Services.Notifications.Abstractions;

public interface IStateService
{
    Task<SendResultRpc> GetStateAsync(Guid notificationId);
}