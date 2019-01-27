using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TrackClass.Toolkit
{
    public class FamilyNameValidationBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey isValidPropertyKey =
            BindableProperty.CreateReadOnly("IsValid",
                                            typeof(bool),
                                            typeof(EmailValidationBehavior),
                                            false);

        public static readonly BindableProperty IsValidProperty =
            isValidPropertyKey.BindableProperty;


        public bool IsValid
        {
            set { SetValue(isValidPropertyKey, value); }
            get { return (bool)GetValue(IsValidProperty); }
        }

        public static bool IsValidFamilyName = false;

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

            IsValid = IsValidName(entry.Text);

            if(entry.Text.Contains(" "))
            {
                entry.Text.Replace(" ", "");
            }

            IsValidFamilyName = IsValid;
        }

        private bool IsValidName(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length < 4)
                return false;

            try
            {
                return Regex.IsMatch(text,
                                    @"^[a-zA-Z]+$",
                                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
