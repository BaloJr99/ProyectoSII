﻿using System;
using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using Foundation;
using Lottie.Forms.Platforms.Ios;
using ProyectoSII.Views;
using UIKit;
using Xamarin.Forms;

namespace ProyectoSII.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            if(Window == null)
            {
                Window = new UIWindow(frame: UIScreen.MainScreen.Bounds);
                var initialViewController = new SplashViewController();
                Window.RootViewController = initialViewController;
                Window.MakeKeyAndVisible();
                return true;
            }
            else
            {
                global::Xamarin.Forms.Forms.Init();
                AnimationViewRenderer animationView = new AnimationViewRenderer();
                animationView.Init();
                Xamarin.FormsMaps.Init();
                LoadApplication(new App());
                MessagingCenter.Subscribe<Inscripciones>(this, "SetLandscape", sender =>
                {
                    UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeLeft), new NSString("orientation"));
                });
                MessagingCenter.Subscribe<Inscripciones>(this, "RemoveLandscape", sender =>
                {
                    UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.Unknown  ), new NSString("orientation"));
                });

                return base.FinishedLaunching(app, options);
            }
        }
    }
}
