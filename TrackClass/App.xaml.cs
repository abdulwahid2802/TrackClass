using System;
using TrackClass.Models;
using TrackClass.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TrackClass
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CustomAddStudentPage())
            {
                BarBackgroundColor = Color.FromHex("f93795"),
                BarTextColor = Color.White

            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            SaveLoadStudent.LoadStudentAsync();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            SaveLoadStudent.SaveStudentAsync();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
