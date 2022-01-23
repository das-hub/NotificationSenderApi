using System.ComponentModel.DataAnnotations;

namespace NotificationSenderApi.Rpc;

public class CreateAndroidNotificationRpc
{
    [Required]
    [MaxLength(50)]
    public string DeviceToken { get; set; }
    
    [Required]
    [MaxLength(2000)]
    public string Message { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    
    public string Condition { get; set; }
}