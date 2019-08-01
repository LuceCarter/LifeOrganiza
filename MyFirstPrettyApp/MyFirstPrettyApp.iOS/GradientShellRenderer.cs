using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(MyFirstPrettyApp.iOS.GradientShellRenderer))]
namespace MyFirstPrettyApp.iOS
{
    public class GradientShellRenderer : ShellRenderer
    {
        private CAGradientLayer _flyoutBackground = null;

        protected override void OnElementSet(Shell element)
        {
            base.OnElementSet(element);
        }

        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
        {
            var renderer =  base.CreateShellSectionRenderer(shellSection);
            if (renderer == null) return null;

            if(renderer is ShellSectionRenderer r)
            {
                r.NavigationBar.ShadowImage = new UIImage();
            }

            return (IShellSectionRenderer)renderer;
        }

        protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer()
        {
            var flyout = base.CreateShellFlyoutContentRenderer();
            flyout.WillAppear += OnFlyoutWillAppear;

            var tv = (UITableView)flyout.ViewController.View.Subviews[0];
            tv.ScrollEnabled = false;

            return flyout;
        }

        private void OnFlyoutWillAppear(object sender, EventArgs e)
        {
            if(_flyoutBackground == null && sender != null && sender is IShellFlyoutContentRenderer flyout)
            {
                var view = flyout.ViewController.View;

                _flyoutBackground = new CAGradientLayer
                {
                    Frame = new CGRect(0, 0, view.Bounds.Width, view.Bounds.Height),
                    Colors = new []
                    {
                        ((Color) App.Current.Resources["FlyoutGradientStart"]).ToCGColor(),
                        ((Color) App.Current.Resources["FlyoutGradientEnd"]).ToCGColor()
                    }

                };

                flyout.ViewController.View.Layer.InsertSublayer(_flyoutBackground, 0);
                flyout.WillAppear -= OnFlyoutWillAppear;
            }
        }
    }
}