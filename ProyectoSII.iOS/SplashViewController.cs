using Airbnb.Lottie;
using UIKit;

namespace ProyectoSII.iOS
{
    public partial class SplashViewController : UIViewController
    {
        public SplashViewController():base() { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var viewAnimation = LOTAnimationView.AnimationNamed("103985-brown-bear222");
            View.AddSubview(viewAnimation);
            View.BackgroundColor = UIColor.White;
            viewAnimation.Center = View.Center;
            viewAnimation.ContentMode = UIViewContentMode.ScaleAspectFit;
            viewAnimation.Frame = View.Bounds;
            viewAnimation.PlayWithCompletion((finished) =>
            {
                UIApplication.SharedApplication.Delegate.FinishedLaunching
                (UIApplication.SharedApplication, new Foundation.NSDictionary());
            });
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}