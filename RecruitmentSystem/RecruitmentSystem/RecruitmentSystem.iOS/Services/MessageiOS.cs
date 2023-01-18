using Foundation;
using Infinity.iOS.Services;
using RecruitmentSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MessageiOS))]
namespace Infinity.iOS.Services
{
    public class MessageiOS : IMessage
    {

        const double SHORT_DELAY = 1.5;
        const double LONG_DELAY = 4.0;
        NSTimer alertDelay;
        UIAlertController alert;

        public void LongAlert(string message)
        {
            ShowAlert(message, LONG_DELAY);
        }
        public void ShortAlert(string message)
        {
            ShowAlert(message, SHORT_DELAY);
        }

        void ShowAlert(string message, double seconds)
        {
            try
            {
                if (alert == null && alertDelay == null)
                {
                    alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            DismissMessage();
                        });
                    });

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        try
                        {
                            alert = UIAlertController.Create("", message, UIAlertControllerStyle.Alert);
                            topViewControllerWithRootViewController(UIApplication.SharedApplication.KeyWindow.RootViewController).PresentViewController(alert, true, null);

                        }
                        catch (Exception ex)
                        {
                            var Error = ex.Message;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        UIViewController topViewControllerWithRootViewController(UIViewController rootViewController)
        {
            if (rootViewController is UITabBarController)
            {
                UITabBarController tabBarController = (UITabBarController)rootViewController;
                return topViewControllerWithRootViewController(tabBarController.SelectedViewController);
            }
            else if (rootViewController is UINavigationController)
            {
                UINavigationController navigationController = (UINavigationController)rootViewController;
                return topViewControllerWithRootViewController(navigationController.VisibleViewController);
            }
            else if (rootViewController.PresentedViewController != null)
            {
                UIViewController presentedViewController = rootViewController.PresentedViewController;
                return topViewControllerWithRootViewController(presentedViewController);
            }
            return rootViewController;
        }
        void DismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
                alert = null;
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
                alertDelay = null;
            }
        }

        public void ExitApp()
        {
            Thread.CurrentThread.Abort();
        }
    }
}