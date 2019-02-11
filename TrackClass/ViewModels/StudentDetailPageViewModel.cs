using System;
using System.Collections.ObjectModel;
using TrackClass.Models;
using Xamarin.Forms;

namespace TrackClass.ViewModels
{
    public class StudentDetailPageViewModel : ViewModelBase
    {

        string _firstNameText;
        string _lastNameText;
        string _classNameText;
        string _ageText;
        string _idText;
        string _phoneText;
        string _emailText;

        ObservableCollection<DateTime> unpaid = new ObservableCollection<DateTime>();

        Command _callCommand;
        Command _emailCommand;

        Command _attendCommand;
        Command _payCommand;

        Command _loadHistoryCommand;

        Student _student;

        public StudentDetailPageViewModel(Student student)
        {
            _student = student;

            AgeText = ((DateTime.Now - student.BirthDate).Days / 365 ).ToString();
            FirstNameText = student.FirstName;
            LastNameText = student.FamilyName;
            PhoneText = student.PhoneNumber;
            EmailText = student.Email;
            IDText = student.ID;
            ClassNameText = Variables.Subjects[student.ClassId];
        }

        public string FirstNameText
        {
            set { SetProperty(ref _firstNameText, value); }
            get { return _firstNameText; }
        }

        public string LastNameText
        {
            set { SetProperty(ref _lastNameText, value); }
            get { return _lastNameText; }
        }

        public string ClassNameText
        {
            set { SetProperty(ref _classNameText, value); }
            get { return _classNameText; }
        }

        public string AgeText
        {
            set { SetProperty(ref _ageText, value); }
            get { return _ageText; }
        }

        public string IDText
        {
            set { SetProperty(ref _idText, value); }
            get { return _idText; }
        }

        public string PhoneText
        {
            set { SetProperty(ref _phoneText, value); }
            get { return _phoneText; }
        }
        public string EmailText
        {
            set { SetProperty(ref _emailText, value); }
            get { return _emailText; }
        }


    }
}
