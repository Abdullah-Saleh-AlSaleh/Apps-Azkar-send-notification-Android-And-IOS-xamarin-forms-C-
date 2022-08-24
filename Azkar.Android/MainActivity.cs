﻿
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Azkar.Models;
using Xamarin.Forms;
using Android.Content.PM;
using Android.Provider;
namespace Azkar.Droid
{
    [Activity(Label = "أذكار", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        Intent serviceIntent;
        private const int RequestCode = 5469;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            serviceIntent = new Intent(this, typeof(AndroidAzkarService));
            SetServiceMethods();

            //if (Build.VERSION.SdkInt >= BuildVersionCodes.M && !Android.Provider.Settings.CanDrawOverlays(this))
            //{
            //    var intent = new Intent(Android.Provider.Settings.ActionManageOverlayPermission);
            //    intent.SetFlags(ActivityFlags.NewTask);
            //    this.StartActivity(intent);
            //}

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void SetServiceMethods()
        {
            MessagingCenter.Subscribe<StartServiceMessage>(this, "ServiceStarted", message => {
                if (!IsServiceRunning(typeof(AndroidAzkarService)))
                {
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                    {
                        StartForegroundService(serviceIntent);
                    }
                    else
                    {
                        StartService(serviceIntent);
                    }
                }
            });

            MessagingCenter.Subscribe<StopServiceMessage>(this, "ServiceStopped", message => {
                if (IsServiceRunning(typeof(AndroidAzkarService)))
                    StopService(serviceIntent);
            });
        }

        private bool IsServiceRunning(System.Type cls)
        {
            ActivityManager manager = (ActivityManager)GetSystemService(Context.ActivityService);
            foreach (var service in manager.GetRunningServices(int.MaxValue))
            {
                if (service.Service.ClassName.Equals(Java.Lang.Class.FromType(cls).CanonicalName))
                {
                    return true;
                }
            }
            return false;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == RequestCode)
            {
                if (Settings.CanDrawOverlays(this))
                {

                }
            }

            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}
