﻿using Android.App;
using Xamarin.Forms;
using XGaleryPhotos.Droid.Services;
using XGaleryPhotos.Interfaces;

[assembly: Dependency(typeof(CloseApplication))]
namespace XGaleryPhotos.Droid.Services
{
    public class CloseApplication : ICloseApplicatonService
    {
        void ICloseApplicatonService.CloseApplication()
        {
            //var activity = (Activity) Forms.Context;
            var activity = MainActivity.Instance;
            activity.Finish();
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}