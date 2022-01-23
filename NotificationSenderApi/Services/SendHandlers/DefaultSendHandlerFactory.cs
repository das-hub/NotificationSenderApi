using NotificationSenderApi.DataAccess.Abstractions;
using NotificationSenderApi.DataAccess.Models;
using NotificationSenderApi.Services.SendHandlers.Abstractions;

namespace NotificationSenderApi.Services.SendHandlers;

public class DefaultSendHandlerFactory : ISendHandlerFactory
{
    private readonly IDbContext _dbContext;
    private readonly ILoggerFactory _loggerFactory;

    public DefaultSendHandlerFactory(IDbContext dbContext, ILoggerFactory loggerFactory)
    {
        _dbContext = dbContext;
        _loggerFactory = loggerFactory;
    }

    public ISendHandler GetHandler(NotificationBase notification)
    {
        return notification switch
        {
            AndroidNotification androidNotification => new AndroidSendHandler(_dbContext, androidNotification, _loggerFactory.CreateLogger<AndroidSendHandler>()),
            IOSNotification iosNotification => new IOSSendHandler(_dbContext, iosNotification, _loggerFactory.CreateLogger<IOSSendHandler>()),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}