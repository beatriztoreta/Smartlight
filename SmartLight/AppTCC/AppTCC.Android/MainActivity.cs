using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using br.com.smartlight.Droid;
using Xamarin.Forms;
using SmartLight.Models;
using Android.Support.V4.App;
using Android.Content;
using System;

namespace SmartLight.Droid
{
    [Activity(Label = "SmartLight", Icon = "@drawable/slicon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            MessagingCenter.Subscribe<Mensagem>(this, "Notif", TratamentoMensagem);

            CreateNotificationChannel();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void TratamentoMensagem(Mensagem obj)
        {
            SendNotif(obj.Msg);
        }

        static readonly int NOTIFICATION_ID = 1000;
        static readonly string CHANNEL_ID = "location_notification";
        internal static readonly string COUNT_KEY = "count";

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                return;
            }

            var name = "Smart Light Error";
            var description = "Smart Light Sensor Error";
            var channel = new NotificationChannel(CHANNEL_ID, name, NotificationImportance.Default)
            {
                Description = description
            };
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        public void SendNotif(string msg)
        {
            var manager = (NotificationManager)this.GetSystemService(Context.NotificationService);

            var intent = this.PackageManager.GetLaunchIntentForPackage(this.PackageName);

            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.UpdateCurrent);

            var builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent)
                .SetContentTitle("Smart Light Error")
                .SetSmallIcon(Resource.Drawable.slicon)
                .SetContentText(msg);

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(NOTIFICATION_ID, builder.Build());
            var duration = TimeSpan.FromSeconds(2);
            Xamarin.Essentials.Vibration.Vibrate(duration);
        }
    }
}