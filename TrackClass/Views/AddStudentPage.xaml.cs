using System;
using System.Collections.Generic;
using TrackClass.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackClass.Views
{
    public partial class AddStudentPage : ContentPage
    {

        public AddStudentPage()
        {
            InitializeComponent();

            var viewModel = new AddStudentPageViewModel();

            BindingContext = viewModel;
        }

        void Handle_SaveClicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
