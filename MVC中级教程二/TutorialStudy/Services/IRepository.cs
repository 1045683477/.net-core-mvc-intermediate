using System.Collections.Generic;
using TutorialStudy.Model;

namespace TutorialStudy.Services
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int studentId);
        T Add(Student student);
    }
}
