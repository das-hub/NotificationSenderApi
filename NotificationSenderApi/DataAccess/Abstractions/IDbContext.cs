﻿using NotificationSenderApi.DataAccess.Models;

namespace NotificationSenderApi.DataAccess.Abstractions;

public interface IDbContext
{
    List<AndroidNotification> AndroidNotifications { get; set; }
    List<IOSNotification> IosNotifications { get; set; }
    List<RegistryNotification> RegistryNotifications { get; set; }
}