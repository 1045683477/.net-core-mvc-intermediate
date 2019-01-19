using System;
using System.Collections.Generic;
using System.Linq;
using TutorialStudy.Model;

namespace TutorialStudy.Services
{
    public class InMemoryRepository:IRepository<Student>
    {
        private readonly List<Student> _student;

        public InMemoryRepository()
        {
           _student=new List<Student>
           {
               new Student
               {
                   Id=1,
                   FirstName = "龙",
                   LastName = "族",
                   BirthDate = new DateTime(1998,10,14),
                   Gender = Gender.男士
               },
               new Student
               {
                   Id=2,
                   FirstName = "醉",
                   LastName = "人",
                   BirthDate = new DateTime(1998,10,14),
                   Gender = Gender.男士
               },
               new Student
               {
                   Id=3,
                   FirstName = "东方",
                   LastName = "不败",
                   BirthDate = new DateTime(2008,2,14),
                   Gender = Gender.女士
               }
           };

        }

        public IEnumerable<Student> GetAll()
        {
            return _student;
        }

        public Student GetById(int studentId)
        {
            return _student.FirstOrDefault(x => x.Id == studentId);
        }

        public Student Add(Student student)
        {
            var maxId = _student.Max(x => x.Id);
            student.Id = ++maxId;
            _student.Add(student);
            return student;
        }
    }
}
