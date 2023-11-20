using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class NotificationManager : Singleton<NotificationManager>
{
    AndroidNotificationChannel notifChannel;

    void Start()
    {
        //Opcional a usar
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        AndroidNotificationCenter.CancelAllScheduledNotifications();
        //por si quieren calcelar notificaciopnes a futuro salir o que ya salieron

        notifChannel = new AndroidNotificationChannel()
        {
            Id = "reminder_notif_ch",
            Name = "Reminder Notification",
            Description = "Reminder to login",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notifChannel);

        DisplayNotification("VUELVE!!!!", "Te necesito, necesito que me juegues", DateTime.Now.AddHours(36));
    }

    public int DisplayNotification(string title, string text, DateTime fireTime)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = fireTime;

        return AndroidNotificationCenter.SendNotification(notification, notifChannel.Id);
    }

    public void CancelNotification(int id)
    {
        AndroidNotificationCenter.CancelScheduledNotification(id);
    }
}
