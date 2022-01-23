using NotificationSenderApi.DataAccess.Models;
using NotificationSenderApi.Rpc;
using NotificationSenderApi.Services.Notifications.Abstractions;
using NotificationSenderApi.Services.SendHandlers.Abstractions;

namespace NotificationSenderApi.Services.Notifications;

public class DefaultNotificationService : INotificationService
{
    private readonly ISendHandlerFactory _handlerFactory;
    private readonly IStateService _stateService;

    public DefaultNotificationService(ISendHandlerFactory handlerFactory, IStateService stateService)
    {
        _handlerFactory = handlerFactory;
        _stateService = stateService;
    }

    public async Task<SendResultRpc> SendAsync(NotificationBase notification)
    {
        var handler = _handlerFactory.GetHandler(notification);

        return await handler.ExecuteAsync();
    }

    public async Task<SendResultRpc> GetStateAsync(Guid notificationId)
    {
        return await _stateService.GetStateAsync(notificationId);
    }
}