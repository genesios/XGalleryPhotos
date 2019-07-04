﻿using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XGaleryPhotos.Interfaces;
using XGaleryPhotos.Services;
using XGaleryPhotos.Views;
using XGaleryPhotos.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XGaleryPhotos
{
    public partial class App : Application
    {
        #region Static Members

        // Services
        public static IAuthenticateService AuthenticateService { get; set; }
        public static IMultiMediaPickerService MultiMediaPickerService { get; set; }
        public static INavigationService NavigationService { get; set; }
        public static IRepositoryService RepositoryService { get; set; }

        // Views
        public static AuthenticationPage AuthenticationPage { get; set; }
        public static FlujoPage FlujoPage { get; set; }                 // MainPage
        public static NavigationPage NavegacionPage { get; set; }       // Navigation
        public static PhotoDisplayPage PhotoDisplayPage { get; set; }

        // ViewModels
        public static FlujoViewModel FlujoViewModel { get; set; }
        public static PhotoDisplayViewModel PhotoDisplayViewModel { get; set; }

        static App()
        {
            // Services
            AuthenticateService = new AuthenticateService();
            NavigationService = new NavigationService();
            RepositoryService = new RepositoryService();

        }

        #endregion

        public App()
        {
            InitializeComponent();

            // ViewModels
            FlujoViewModel = new FlujoViewModel();
            PhotoDisplayViewModel = new PhotoDisplayViewModel();

            // Views
            AuthenticationPage = new AuthenticationPage();
            FlujoPage = new FlujoPage();
            NavegacionPage = new NavigationPage();
            PhotoDisplayPage = new PhotoDisplayPage();

            FlowListView.Init();
            App.NavegacionPage.PushAsync(FlujoPage);
            this.MainPage = NavegacionPage;
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
