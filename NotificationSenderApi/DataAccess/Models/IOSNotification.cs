namespace NotificationSenderApi.DataAccess.Models;

public class IOSNotification : NotificationBase
{
    public string PushToken { get; set; }
    public string Alert { get; set; }
    public int Priority { get; set; } = 10;
    public bool IsBackground { get; set; } = true;
}