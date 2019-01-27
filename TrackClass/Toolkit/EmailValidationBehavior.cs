using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TrackClass.Toolkit
{
    public class EmailValidationBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey isValidPropertyKey =
            BindableProperty.CreateReadOnly("IsValid",
                                            typeof(bool),
                                            typeof(EmailValidationBehavior),
                                            false);

        public static readonly BindableProperty IsValidProperty = 
            isValidPropertyKey.BindableProperty;


        public static bool IsValidEmail = false;

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

            IsValid = IsValidEmailText(entry.Text);

            IsValidEmail = IsValid;
        }

        private bool IsValidEmailText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            try
            {
                return Regex.IsMatch(text,
                                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|" +
                                    @"[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)" +
                                    @"(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|" +
                                    @"(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch(RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
