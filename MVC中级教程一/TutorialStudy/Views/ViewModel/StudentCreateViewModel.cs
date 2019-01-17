using System;
using TutorialStudy.Model;

namespace TutorialStudy.Views.ViewModel
{
    public class StudentCreateViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
