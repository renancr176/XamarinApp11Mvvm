using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp11Mvvm.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinApp11Mvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new InicioView();
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
