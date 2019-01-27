using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TrackClass.Toolkit
{
    public class PhoneValidationBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey isValidPropertyKey =
            BindableProperty.CreateReadOnly("IsValid",
                                            typeof(bool),
                                            typeof(EmailValidationBehavior),
                                            true);

        public static readonly BindableProperty IsValidProperty =
            isValidPropertyKey.BindableProperty;

        public static bool IsValidPhoneNumber = false;


        public bool IsValid
        {
            set { SetValue(isValidPropertyKey, value); }
            get { return (bool)GetValue(IsValidProperty); }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += Entry_TextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= Entry_TextChanged;

            base.OnDetachingFrom(entry);
        }

        void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;

            IsValid = IsValidNumber(entry.Text);

            IsValidPhoneNumber = IsValid;

            // add space after two digits
            if (entry.Text.Length == 2 && !e.OldTextValue.EndsWith(" "))
                entry.Text += " ";

            // delete space and next digit 
            if(e.OldTextValue != null)
                if (e.OldTextValue.Length > e.NewTextValue.Length && e.NewTextValue.Length == 2)
                    entry.Text = entry.Text.Substring(0, entry.Text.Length - 1);

        }

        private bool IsValidNumber(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length < 10)
                return false;

            try
            {
                return Regex.IsMatch(text,
                                    @"^[0-9 ]",
                                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
