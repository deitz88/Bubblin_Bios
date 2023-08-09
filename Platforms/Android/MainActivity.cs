using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Microsoft.Maui;

namespace Bubblin_Bios
{
    [Activity(Theme = "@style/Maui.SplashTheme",
              MainLauncher = false,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
              ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : MauiAppCompatActivity
    {
    }

    [Activity(Label = "SplashActivity", MainLauncher = true, NoHistory = true, Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splash_activity);

            var videoView = FindViewById<VideoView>(Resource.Id.videoView);

            var videoPath = "android.resource://" + PackageName + "/" + Resource.Raw.test;
            videoView.SetVideoURI(Android.Net.Uri.Parse(videoPath));
            videoView.Start();

            videoView.Completion += (sender, e) =>
            {
                StartActivity(typeof(MainActivity)); // Proceed to your main activity
            };

            IWindowManager windowManager = GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            videoView.SetOnPreparedListener(new OnVideoPreparedListener(videoView, windowManager));
        }
    }

    public class OnVideoPreparedListener : Java.Lang.Object, MediaPlayer.IOnPreparedListener
    {
        private readonly VideoView _videoView;
        private readonly IWindowManager _windowManager;

        public OnVideoPreparedListener(VideoView videoView, IWindowManager windowManager)
        {
            _videoView = videoView;
            _windowManager = windowManager;
        }

        public void OnPrepared(MediaPlayer mp)
        {
            DisplayMetrics metrics = new DisplayMetrics();
            _windowManager.DefaultDisplay.GetMetrics(metrics);
            int screenHeight = metrics.HeightPixels;
            int screenWidth = metrics.WidthPixels;

            _videoView.LayoutParameters.Width = screenWidth;
            _videoView.LayoutParameters.Height = screenHeight;
        }
    }
}
