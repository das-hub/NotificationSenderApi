using NotificationSenderApi.DataAccess.Abstractions;
using NotificationSenderApi.DataAccess.Models;
using NotificationSenderApi.Enums;
using NotificationSenderApi.Rpc;
using NotificationSenderApi.Services.Notifications.Abstractions;

namespace NotificationSenderApi.Services.States;

public class DefaultStateService : IStateService
{
    private readonly IDbContext _context;

    public DefaultStateService(IDbContext context)
    {
        _context = context;
    }

    public Task<SendResultRpc> GetStateAsync(Guid notificationId)
    {
        var registry = _context.RegistryNotifications.FirstOrDefault(r => r.NotificationId == notificationId);

        if (registry is null) return Task.FromResult(new SendResultRpc
        {
            Success = false,
            Message = $"Notification with ID=[{notificationId}] not found"
        });

        NotificationBase notification = registry.OsTypes switch
        {
            OSTypes.Android => _context.AndroidNotifications.FirstOrDefault(n => n.Id == registry.NotificationId),
            OSTypes.IOS => _context.IosNotifications.FirstOrDefault(n => n.Id == registry.NotificationId),
            _ => throw new ArgumentOutOfRangeException()
        };
        
        if (notification is null) return Task.FromResult(new SendResultRpc
        {
            Success = false,
            Message = $"Notification with ID=[{notificationId}] not found"
        });
        
        return Task.FromResult<SendResultRpc>(new SendResultRpc
        {
            Success = true,
            NotificationId = notification.Id,
            State = notification.State.ToString()
        });
    }
}