using System;
using System.Collections.Generic;
using TrackClass.Models;
using TrackClass.ViewModels;
using Xamarin.Forms;

namespace TrackClass.Views
{
    public partial class StudentDetailPage : ContentPage
    {
        public StudentDetailPage()
        {
            InitializeComponent();
        }


        public StudentDetailPage(Student student)
        {
            InitializeComponent();

            BindingContext = new StudentDetailPageViewModel(student);
        }
    }
}
