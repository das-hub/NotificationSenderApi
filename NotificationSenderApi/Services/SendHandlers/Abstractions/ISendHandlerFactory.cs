using NotificationSenderApi.DataAccess.Models;

namespace NotificationSenderApi.Services.SendHandlers.Abstractions;

public interface ISendHandlerFactory
{
    ISendHandler GetHandler(NotificationBase notification);
}