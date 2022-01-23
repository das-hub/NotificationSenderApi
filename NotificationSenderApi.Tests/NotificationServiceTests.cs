using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using NotificationSenderApi.DataAccess;
using NotificationSenderApi.DataAccess.Models;
using NotificationSenderApi.Services.Notifications;
using NotificationSenderApi.Services.Notifications.Abstractions;
using NotificationSenderApi.Services.SendHandlers;
using NotificationSenderApi.Services.States;
using Xunit;

namespace NotificationSenderApi.Tests;

public class NotificationServiceTests
{
    private readonly INotificationService _notificationService;

    public NotificationServiceTests()
    {
        var dbContext = new DbContext();

        var handlerFactory = new DefaultSendHandlerFactory(dbContext, new NullLoggerFactory());
        var stateService = new DefaultStateService(dbContext);

        _notificationService = new DefaultNotificationService(handlerFactory, stateService);
    }

    [Fact]
    public async Task SendAsync_PushAndroidNotification_ReturnsSuccessResult()
    {
        var notification = new AndroidNotification();

        var result = await _notificationService.SendAsync(notification);
        
        Assert.True(result.Success);
        Assert.Equal("Delivered", result.State);
        Assert.True(result.NotificationId == notification.Id);
    }
    
    [Fact]
    public async Task SendAsync_PushIOSNotification_ReturnsSuccessResult()
    {
        var notification = new IOSNotification();

        var result = await _notificationService.SendAsync(notification);
        
        Assert.True(result.Success);
        Assert.Equal("Delivered", result.State);
        Assert.True(result.NotificationId == notification.Id);
    }
    
    [Fact]
    public void SendAsync_PushEmailNotification_ThrowArgumentOutOfRangeException()
    {
        var notification = new EmailNotification();

        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _notificationService.SendAsync(notification));
    }
    
    [Fact]
    public async Task SendAsync_GetStateAsync_ResultsSame()
    {
        var notification = new AndroidNotification();

        var sendResult = await _notificationService.SendAsync(notification);
        var getStateResult = await _notificationService.GetStateAsync(notification.Id);
        
        Assert.True(sendResult.Success);
        Assert.True(getStateResult.Success);
        
        Assert.True(sendResult.NotificationId == getStateResult.NotificationId);
        Assert.True(sendResult.State == getStateResult.State);
        Assert.True("Delivered" == sendResult.State);
    }
}