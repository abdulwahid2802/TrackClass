using System;
namespace TrackClass.Models
{
    public class Student
    {
        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public string ID { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public short UnpayedCount { get; set; }

    }
}
