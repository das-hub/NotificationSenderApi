using NotificationSenderApi.DataAccess;
using NotificationSenderApi.DataAccess.Enums;
using NotificationSenderApi.DataAccess.Models;
using NotificationSenderApi.Enums;
using NotificationSenderApi.Rpc;
using NotificationSenderApi.Services.SendHandlers.Abstractions;

namespace NotificationSenderApi.Services.SendHandlers;

public class IOSSendHandler : ISendHandler
{
    private readonly IDbContext _context;
    private readonly IOSNotification _notification;
    private readonly ILogger _logger;

    public IOSSendHandler(IDbContext context, IOSNotification notification, ILogger<IOSSendHandler> logger)
    {
        _context = context;
        _notification = notification;
        _logger = logger;
    }

    public async Task<SendResultRpc> ExecuteAsync()
    {
        await Task.Delay(200);
        _logger.LogInformation($"iOS Device({_notification.PushToken}): NotificationID:[{_notification.Id}] - SENDED");
        
        _notification.State = State.Delivered;

        _context.IosNotifications.Add(_notification);
        _context.RegistryNotifications.Add(new RegistryNotification
        {
            OsTypes = OSTypes.IOS,
            NotificationId = _notification.Id
        });

        return new SendResultRpc
        {
            Success = true,
            NotificationId = _notification.Id,
            State = _notification.State.ToString()
        };
    }
}