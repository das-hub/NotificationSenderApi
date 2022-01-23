namespace NotificationSenderApi.Rpc;

public class SendResultRpc
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string State { get; set; }
    public Guid? NotificationId { get; set; }
}