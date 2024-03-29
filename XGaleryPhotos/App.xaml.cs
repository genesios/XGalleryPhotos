﻿using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XGaleryPhotos.Views;
using XGaleryPhotos.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XGaleryPhotos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Views
            Globals.NavegacionPageInstance = new NavigationPage();
            Globals.PhotoDisplayPageInstance = new PhotoDisplayPage(new PhotoDisplayViewModel());

            FlowListView.Init();

            if (!Globals.AuthenticateService.IsUserAuthenticated())
            {
                Globals.NavegacionPageInstance.PushAsync(new AuthenticationPage(new AuthenticationViewModel()));
            }
            else
            {
                Globals.NavegacionPageInstance.PushAsync(new FlujoPage(
                    new FlujoViewModel(Globals.AuthenticateService.AuthenticatedUser)));
            }

            this.MainPage = Globals.NavegacionPageInstance;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
