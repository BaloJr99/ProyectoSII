using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using ProyectoSII.Views;
using Android;
using Acr.UserDialogs;

namespace ProyectoSII.Droid
{
    [Activity(Label = "ProyectoSII", Icon = "@drawable/itpnlogo", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;
        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation,
        };

        protected override void OnStart()
        {
            base.OnStart();
            if((int)Build.VERSION.SdkInt >= 23)
            {
                if(CheckSelfPermission(Manifest.Permission.AccessFineLocation) == Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    //Already Granted
                }
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            LoadApplication(new App());

            MessagingCenter.Subscribe<Inscripciones>(this, "SetLandscape", sender =>
            {
                RequestedOrientation = ScreenOrientation.SensorLandscape;
            });
            MessagingCenter.Subscribe<Inscripciones>(this, "RemoveLandscape", sender =>
            {
                RequestedOrientation = ScreenOrientation.Unspecified;
            });
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            if(requestCode == RequestLocationId) 
            {
                if((grantResults.Length == 1) && grantResults[0] == (int)Permission.Granted)
                {
                    //Permissions granted
                }
                else
                {
                    //Permissions denied
                }
            }
            else
            {
                Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}