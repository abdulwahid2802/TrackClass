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


        public StudentListPageViewModel()
        {
            CallCommand = new Command<Student>((s) => CallHandler(s));
            DeleteCommand = new Command<Student>((s) => DeleteHandler(s));
        }

        private void DeleteHandler(Student student)
        {
            Variables.studentsCollection.Remove(student);
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
