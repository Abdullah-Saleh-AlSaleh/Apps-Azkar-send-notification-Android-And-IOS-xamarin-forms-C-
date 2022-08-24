using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using AndroidX.Core.App;
using Android.Graphics;
using Android.Content.Res;
using Azkar.Apps_Interface;
using Android;
using Application = Android.App.Application;

[assembly: Dependency(typeof(Azkar.Droid.AndroidNotification))]
namespace Azkar.Droid
{
    public class AndroidNotification : ICustomNotification
    {
        const string channel_id = "default";
        const string channel_name = "Azkar";
        int notify_index = 0;

        public void send(string title, string message)
        {
            NotificationManager manager = (NotificationManager) Application.Context.GetSystemService(Application.NotificationService);

            var channelNameJava = new Java.Lang.String(channel_name);
            var channel = new NotificationChannel(channel_id, channelNameJava, NotificationImportance.High)
            {
                Description = "Azkar Service Notification"
            };

            manager.CreateNotificationChannel(channel);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(Application.Context, channel_id)

                .SetContentTitle(title)
                .SetContentText(message)
                .SetLargeIcon(BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.azkars))
                .SetSmallIcon(Resource.Drawable.azkarto)
                .SetPriority((int)NotificationPriority.High)
                .SetVisibility((int)NotificationVisibility.Public)
                .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate);
   
            Notification notification = builder.Build();
            manager.Notify(notify_index++, notification);
        }
    }
}