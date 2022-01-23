namespace NotificationSenderApi.DataAccess.Models
{
    public class AndroidNotification : NotificationBase
    {
        public string DeviceToken { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string Condition { get; set; }
    }
}
