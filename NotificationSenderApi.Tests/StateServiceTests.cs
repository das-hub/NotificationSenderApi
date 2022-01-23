using System;
using System.Threading.Tasks;
using NotificationSenderApi.DataAccess;
using NotificationSenderApi.DataAccess.Models;
using NotificationSenderApi.Enums;
using NotificationSenderApi.Services.Notifications.Abstractions;
using NotificationSenderApi.Services.States;
using Xunit;

namespace NotificationSenderApi.Tests;

public class StateServiceTests
{
    private readonly IStateService _stateService;
    private readonly Guid _notificationId;
    
    public StateServiceTests()
    {
        var notification = new IOSNotification();
        var entry = new RegistryNotification
        {
            NotificationId = notification.Id,
            OsTypes = OSTypes.IOS
        };

        var dbContext = new DbContext();
        dbContext.IosNotifications.Add(notification);
        dbContext.RegistryNotifications.Add(entry);

        _notificationId = notification.Id;
        _stateService = new DefaultStateService(dbContext);
    }
    
    [Fact]   
    public async Task GetStateAsync_NotExistingNotificationId_ReturnsMessageNotFound()
    {
        var notificationId = Guid.NewGuid();

        var result = await _stateService.GetStateAsync(notificationId);
        
        Assert.NotNull(result);
        Assert.False(result.Success);
        Assert.Equal("Message not found", result.Message);
    }
    
    [Fact]   
    public async Task GetStateAsync_ExistingNotificationId_ReturnsSuccessResult()
    {
        var result = await _stateService.GetStateAsync(_notificationId);
        
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.True(result.NotificationId == _notificationId);
    }
}