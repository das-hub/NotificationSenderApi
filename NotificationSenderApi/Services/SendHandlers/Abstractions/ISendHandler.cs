using NotificationSenderApi.Rpc;

namespace NotificationSenderApi.Services.SendHandlers.Abstractions;

public interface ISendHandler
{
    public Task<SendResultRpc> ExecuteAsync();
}