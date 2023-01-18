using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Infinity.Droid.Native;
using Plugin.CurrentActivity;
using RecruitmentSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace Infinity.Droid.Native
{
    public class MessageAndroid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast toast = Toast.MakeText(Application.Context, message, ToastLength.Long);
            toast.SetGravity(GravityFlags.Bottom, 0, -10);
            toast.Show();
            //Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast toast = Toast.MakeText(Application.Context, message, ToastLength.Short);
            toast.SetGravity(GravityFlags.Bottom, 0, -10);
            toast.Show();
            //Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }

        public void ExitApp()
        {
            CrossCurrentActivity.Current.Activity.Finish();
        }
    }
}