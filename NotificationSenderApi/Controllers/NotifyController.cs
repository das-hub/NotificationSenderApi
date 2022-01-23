using Microsoft.AspNetCore.Mvc;
using NotificationSenderApi.DataAccess.Models;
using NotificationSenderApi.Rpc;
using NotificationSenderApi.Services.Notifications.Abstractions;

namespace NotificationSenderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class NotifyController : ControllerBase
{
    private readonly INotificationService _service;
    private readonly ILogger<NotifyController> _logger;

    public NotifyController(ILogger<NotifyController> logger, INotificationService service)
    {
        _logger = logger;
        _service = service;
    }
    
    [HttpPost]
    [Route("android")]
    public async Task<IActionResult> NotifyAndroidAsync([FromBody] CreateAndroidNotificationRpc rpc)
    {
        var model = new AndroidNotification
        {
            Condition = rpc.Condition,
            Message = rpc.Message,
            Title = rpc.Title,
            DeviceToken = rpc.DeviceToken
        };

        var result = await _service.SendAsync(model);
        
        return Ok(result);
    }
    
    [HttpPost]
    [Route("ios")]
    public async Task<IActionResult> NotifyIosAsync([FromBody] CreateIosNotificationRpc rpc)
    {
        var model = new IOSNotification
        {
            Alert = rpc.Alert,
            PushToken = rpc.PushToken,
            Priority = rpc.Priority,
            IsBackground = rpc.IsBackground
        };

        var result = await _service.SendAsync(model);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{notificationId:guid}")]
    public async Task<IActionResult> GetStateAsync(Guid notificationId)
    {
        var result = await _service.GetStateAsync(notificationId);
        
        return Ok(result);
    }
}