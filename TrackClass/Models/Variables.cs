using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace TrackClass.Models
{
    public class Variables
    {
        public static ObservableCollection<Student> studentsCollection = new ObservableCollection<Student>();

        public static List<string> Subjects = new List<string>(new string[]
        {   "C#",
            "Java",
            "Python",
            "C++",
            "C",
            "Xamarin Forms",
            "Android",
            "iOS",
            "WPF",
            "Unity"
        });

        public static List<string> subjectInits = new List<string>(new string[]
        {   "CS",
            "JV",
            "PY",
            "CP",
            "CC",
            "XF",
            "AN",
            "IO",
            "WP",
            "UN"
        });
    }
}
