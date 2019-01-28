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

            //IsValid = IsValidNumber(entry.Text);

            if(e.NewTextValue.Length == 2 || e.NewTextValue.Length == 6)
            {
                if(e.OldTextValue.Length > e.NewTextValue.Length)
                {
                    entry.Text = e.NewTextValue.Substring(0, e.NewTextValue.Length - 1);
                }
                else
                {
                    entry.Text += " ";
                }
            }

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
