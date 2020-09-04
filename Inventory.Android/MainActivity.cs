﻿using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using FreshMvvm;

namespace Inventory.Droid
{
    [Activity(Label = "Inventory", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private IScanner _scanner = null;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var repository = new Repository(FileAccessHelper.GetLocalFilePath("items.db3"));
            FreshIOC.Container.Register(repository);

            _scanner = new Scanner_Android();
            FreshIOC.Container.Register(_scanner);

            LoadApplication(new App());
        }

    }
}

