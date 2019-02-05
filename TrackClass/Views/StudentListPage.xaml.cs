using System;
using System.Collections.Generic;
using Lottie.Forms;
using TrackClass.Models;
using TrackClass.ViewModels;
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

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var student = (sender as MenuItem).CommandParameter as Student;

            if (student == null)
            {
                DisplayAlert("Null", "Student is Null", "OK");
                return;
            }

            Variables.studentsCollection.Remove(student);
        }

        void Handle_AddClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddStudentPage());
        }

    }
}
