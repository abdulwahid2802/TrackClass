using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using TrackClass.FileServices;

namespace TrackClass.Models
{
    public class SaveLoadStudent
    {
        static FileHelper fileHelper = new FileHelper();

        public SaveLoadStudent()
        {
            fileHelper = new FileHelper();
        }

        public static void SaveStudentAsync()
        {
            var jsonFile = JsonConvert.SerializeObject(Variables.studentsCollection);

            fileHelper.WriteTextAsync("students.json", jsonFile);
        }

        public static async void LoadStudentAsync()
        {
            var exists = await fileHelper.ExistsAsync("students.json");
            if (!exists)
                return;

            var jsonFile = await fileHelper.ReadTextAsync("students.json");

            var collection = JsonConvert.DeserializeObject<ObservableCollection<Student>>(jsonFile);

            foreach (var student in collection)
                Variables.studentsCollection.Add(student);
        }

    }
}
