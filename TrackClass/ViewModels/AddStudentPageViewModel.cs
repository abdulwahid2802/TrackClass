using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using TrackClass.Models;
using TrackClass.Toolkit;
using Xamarin.Forms;

namespace TrackClass.ViewModels
{
    public class AddStudentPageViewModel : ViewModelBase
    {
        string _firstNameEntryText;
        string _familyNameEntryText;
        string _phoneNumberEntryText;
        string _emailEntryText;
        string _generatedID;

        DateTime _birthDate;

        ICommand _saveCommand;

        short _pickerSelectedIndex;

        bool _firstNameErrorOpacity;
        bool _familyNameErrorOpacity;
        bool _emailErrorOpacity;
        bool _phoneNumberErrorOpacity;

        public AddStudentPageViewModel()
        {
            BirthDate = DateTime.Now.AddYears(-20);

            PickerSelectedIndex = 3;

            _saveCommand = new Command(
                execute: () =>
            {
                GeneratedID = GenerateID();
                SaveStudent();

            }, canExecute: () =>
            {
                return PhoneErrorOpacity &&
                    EmailErrorOpacity &&
                    FirstNameErrorOpacity &&
                    FamilyNameErrorOpacity;
            });

        }


        private void SaveStudent()
        {
            var student = new Student
            {
                FirstName = FirstNameEntryText,
                FamilyName = FamilyNameEntryText,
                Email = EmailEntryText,
                PhoneNumber = PhoneNumberEntryText,
                BirthDate = this.BirthDate,
                ID = GeneratedID,
            };
            
            Variables.studentsCollection.Add(student);
        }
        
        private string GenerateID()
        {
            Random random = new Random();
            return string.Format("{0:00}{1:00}{2:00}{3:000}", Variables.subjectInits[PickerSelectedIndex],
                                 DateTime.Now.Year % 100,
                                 DateTime.Now.Month,
                                 random.Next(1000));
        }
        
        public List<string> Subjects
        {
            get { return Variables.Subjects; }
        }

        public short PickerSelectedIndex
        {
            set { SetProperty(ref _pickerSelectedIndex, value); }
            get { return _pickerSelectedIndex; }
        }

        public string FirstNameEntryText
        {
            set 
            { 
                SetProperty(ref _firstNameEntryText, value);
                FirstNameErrorOpacity = NameValidation(ref _firstNameEntryText);
                RefreshCanExecutes();
            }
            get { return _firstNameEntryText; }
        }

        public string FamilyNameEntryText
        {
            set 
            { 
                SetProperty(ref _familyNameEntryText, value);
                FamilyNameErrorOpacity = NameValidation(ref _familyNameEntryText);
                RefreshCanExecutes();
            }
            get { return _familyNameEntryText; }
        }

        public string PhoneNumberEntryText
        {
            set 
            { 
                SetProperty(ref _phoneNumberEntryText, value);
                PhoneErrorOpacity = PhoneNumberValidation(ref _phoneNumberEntryText);
                RefreshCanExecutes();
            }
            get { return _phoneNumberEntryText; }
        }

        public string EmailEntryText
        {
            set 
            { 
                SetProperty(ref _emailEntryText, value);
                EmailErrorOpacity = EmailValidation(ref _emailEntryText);
                RefreshCanExecutes();
            }
            get { return _emailEntryText; }
        }

        public string GeneratedID
        {
            get { return _generatedID; }
            private set { SetProperty(ref _generatedID, value); }
        }

        public DateTime BirthDate
        {
            set { SetProperty(ref _birthDate, value); }
            get { return _birthDate; }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
            set { SetProperty(ref _saveCommand, value); }
        }

        public DateTime MaxDate
        {
            get
            {
                return DateTime.Now.AddYears(-10);
            }
        }

        public DateTime MinDate
        {
            get
            {
                return DateTime.Now.AddYears(-40);
            }
        }

        public bool FirstNameErrorOpacity
        {
            get { return _firstNameErrorOpacity; }
            private set { SetProperty(ref _firstNameErrorOpacity, value); }
        }

        public bool FamilyNameErrorOpacity
        {
            get { return _familyNameErrorOpacity; }
            private set { SetProperty(ref _familyNameErrorOpacity, value); }
        }

        public bool PhoneErrorOpacity
        {
            get { return _phoneNumberErrorOpacity; }
            private set { SetProperty(ref _phoneNumberErrorOpacity, value); }
        }

        public bool EmailErrorOpacity
        {
            get { return _emailErrorOpacity; }
            private set { SetProperty(ref _emailErrorOpacity, value); }
        }

        bool NameValidation(ref string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            try
            {
                return Regex.IsMatch(name,
                                     @"^([a-zA-z]{4,20})+$",
                                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            }
            catch(RegexMatchTimeoutException)
            {
                return false;
            }
        }

        bool EmailValidation(ref string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                return Regex.IsMatch(email,
                                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|" +
                                    @"[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)" +
                                    @"(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|" +
                                    @"(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        bool PhoneNumberValidation(ref string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return false;
                
            try
            {
                return Regex.IsMatch(number,
                                     @"^([0-9]){10,10}+$",
                                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        void RefreshCanExecutes()
        {
            ((Command)SaveCommand).ChangeCanExecute();
        }

    }
}
