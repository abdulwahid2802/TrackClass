using System;
using System.Collections.Generic;
using TrackClass.Models;
using Xamarin.Forms;

namespace TrackClass.Views
{
    public partial class StudentListPage : ContentPage
    {
        public StudentListPage()
        {
            InitializeComponent();
            
            studentListView.ItemsSource = Variables.studentsCollection;
        }

        void Handle_AddClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddStudentPage());
        }
    }
}
