using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using NotificationSenderApi.DataAccess;
using NotificationSenderApi.DataAccess.Models;
using NotificationSenderApi.Services.SendHandlers;
using NotificationSenderApi.Services.SendHandlers.Abstractions;
using Xunit;

namespace NotificationSenderApi.Tests;

public class SendHandlerTests
{
    private readonly ISendHandlerFactory _factory;
    
    public SendHandlerTests()
    {
        _factory = new DefaultSendHandlerFactory(new DbContext(), new NullLoggerFactory());
    }
    
    [Fact]
    public async Task ExecuteAsync_PushAndroidNotification_ReturnsSuccessResult()
    {
        var model = new AndroidNotification();

        var handler = _factory.GetHandler(model);
        var result = await handler.ExecuteAsync();
        
        Assert.NotNull(handler);
        Assert.IsType<AndroidSendHandler>(handler);
        Assert.True(result.Success);
    }
    
    [Fact]
    public async Task ExecuteAsync_PushIOSNotification_ReturnsSuccessResult()
    {
        var model = new IOSNotification();

        var handler = _factory.GetHandler(model);
        var result = await handler.ExecuteAsync();
        
        Assert.NotNull(handler);
        Assert.IsType<IOSSendHandler>(handler);
        Assert.True(result.Success);
    }
}