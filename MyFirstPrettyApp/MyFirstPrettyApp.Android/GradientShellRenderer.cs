using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(MyFirstPrettyApp.Droid.GradientShellRenderer))]
namespace MyFirstPrettyApp.Droid
{
    public class GradientShellRenderer : ShellRenderer
    {
        bool _disposed;
        public GradientShellRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementSet(Shell shell)
        {
            base.OnElementSet(shell);
        }

        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
        {
            var renderer = base.CreateShellSectionRenderer(shellSection);
            return (IShellSectionRenderer)renderer;
        }

        protected override IShellFlyoutRenderer CreateShellFlyoutRenderer()
        {
            var flyout = base.CreateShellFlyoutRenderer();
            return flyout;
        }

        protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer()
        {
            var flyout = base.CreateShellFlyoutContentRenderer();

            try
            {
                GradientDrawable gradient = new GradientDrawable(
                    GradientDrawable.Orientation.TopBottom,
                    new Int32[]
                    {
                        ((Color) App.Current.Resources["FlyoutGradientStart"]).ToAndroid(),
                        ((Color) App.Current.Resources["FlyoutGradientEnd"]).ToAndroid()
                    }
                );

                var cl = ((CoordinatorLayout)flyout.AndroidView);
                cl.SetBackground(gradient);

                var g = (AppBarLayout)cl.GetChildAt(0);
                g.SetBackgroundColor(Color.Transparent.ToAndroid());
                g.OutlineProvider = null;

                var header = g.GetChildAt(0);
                header.SetBackgroundColor(Color.Transparent.ToAndroid());
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return flyout;
        }

        protected override void Dispose(bool disposing)
        {
            if(_disposed)
            {
                return;
            }

            if(disposing  && Element != null)
            {
                Element.PropertyChanged -= OnElementPropertyChanged;
                Element.SizeChanged -= (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), this, "OnElementSizeChanged");
            }

            _disposed = true;
        }
    }
}