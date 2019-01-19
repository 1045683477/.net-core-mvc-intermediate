using System.Collections.Generic;
using System.Linq;
using TutorialStudy.Data;
using TutorialStudy.Model;

namespace TutorialStudy.Services
{
    public class EfCoreRepository:IRepository<Student>
    {
        private readonly DataContext _context;

        public EfCoreRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int studentId)
        {
            return _context.Students.Find(studentId);
        }

        public Student Add(Student student)
        {
            //这里就不需要maxId,因为在数据库中Id属性是自增的
            var model=new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                Gender = student.Gender
            };
            _context.Students.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}
