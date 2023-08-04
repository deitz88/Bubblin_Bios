using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace Bubblin_Bios;

[Activity(Theme = "@style/Maui.SplashTheme",
          MainLauncher = true,
          ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
          ScreenOrientation = ScreenOrientation.Landscape)]
public class MainActivity : MauiAppCompatActivity
{
}


//[Activity(Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
//public class MainActivity : Activity
//{
//    protected override void OnCreate(Bundle savedInstanceState)
//    {
//        base.OnCreate(savedInstanceState);

//        SetContentView(Resource.Layout.Main);

//        var videoView = FindViewById<VideoView>(Resource.Id.videoView);

//        var uri = Android.Net.Uri.Parse($"android.resource://{PackageName}/Resources/test.mp4");
//        videoView.SetVideoURI(uri);

//        videoView.Start();

//        videoView.Completion += (s, e) =>
//        {
//            StartActivity(new Intent(this, typeof(MainActivity)));

//            Finish();
//        };
//    }
//}

