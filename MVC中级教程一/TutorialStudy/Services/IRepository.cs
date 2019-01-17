using System.Collections.Generic;

namespace TutorialStudy.Services
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int studentId);
        T Add(int i);
    }
}
