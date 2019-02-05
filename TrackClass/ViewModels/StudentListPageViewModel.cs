using System;
using System.Windows.Input;
using TrackClass.Models;
using Xamarin.Forms;

namespace TrackClass.ViewModels
{
    public class StudentListPageViewModel : ViewModelBase
    {
        ICommand _deleteCommand;
        ICommand _callCommand;

        string _title = "Students";

        int _pageHeight;
        int _pageWidth;

        public StudentListPageViewModel()
        {
            CallCommand = new Command<Student>((s) => CallHandler(s));
            DeleteCommand = new Command<Student>((s) => DeleteHandler(s));
        }

        private void DeleteHandler(Student student)
        {
            Variables.studentsCollection.Remove(student);

            SaveLoadStudent.SaveStudentAsync();
        }

        private void CallHandler(Student s)
        {
            //
        }

        public string Title
        {
            set { SetProperty(ref _title, value); }
            get { return _title; }
        }

        public int PageHeight
        {
            set { SetProperty(ref _pageHeight, value); }
            get { return _pageHeight; }
        }

        public int PageWidth
        {
            set { SetProperty(ref _pageWidth, value); }
            get { return _pageWidth; }
        }
        
        public double AnimationViewScale
        {
            get 
            {
                if (PageHeight > PageWidth)
                    return 1.5;

                return 5.5;
            }
        }

        public ICommand DeleteCommand
        {
            set { SetProperty(ref _deleteCommand, value); }
            get { return _deleteCommand; }
        }

        public ICommand CallCommand 
        {
            set { SetProperty(ref _callCommand, value); }
            get { return _callCommand; } 
        }
    }
}
