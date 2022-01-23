using System;
using Microsoft.Extensions.Logging.Abstractions;
using NotificationSenderApi.DataAccess;
using NotificationSenderApi.DataAccess.Models;
using NotificationSenderApi.Services.SendHandlers;
using NotificationSenderApi.Services.SendHandlers.Abstractions;
using Xunit;

namespace NotificationSenderApi.Tests;

public class SendHandlerFactoryTests
{
    private readonly ISendHandlerFactory _factory;

    public SendHandlerFactoryTests()
    {
        _factory = new DefaultSendHandlerFactory(new DbContext(), new NullLoggerFactory());
    }

    [Fact]
    public void GetHandler_PushAndroidNotification_ReturnsAndroidSendHandler()
    {
        var model = new AndroidNotification();

        var handler = _factory.GetHandler(model);
        
        Assert.NotNull(handler);
        Assert.IsType<AndroidSendHandler>(handler);
    }
    
    [Fact]
    public void GetHandler_PushIOSNotification_ReturnsIosSendHandler()
    {
        var model = new IOSNotification();

        var handler = _factory.GetHandler(model);
        
        Assert.NotNull(handler);
        Assert.IsType<IOSSendHandler>(handler);
    }
    
    [Fact]
    public void GetHandler_PushAnyObject_ThrowArgumentOutOfRangeException()
    {
        var model = new EmailNotification();
        
        Assert.Throws<ArgumentOutOfRangeException>(() => _factory.GetHandler(model));
    }
}