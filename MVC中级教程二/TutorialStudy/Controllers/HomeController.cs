using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TutorialStudy.Model;
using TutorialStudy.Services;
using TutorialStudy.Views.ViewModel;

namespace TutorialStudy.Controllers
{
    public class HomeController:Controller
    {
        private readonly IRepository<Student> _repository;

        public HomeController(IRepository<Student> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _repository.GetAll();

            var vms = list.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Name = $"{x.FirstName}{x.LastName}",
                Age = DateTime.Now.Subtract(x.BirthDate).Days / 365,
                Gender = x.Gender
            });

            var vm=new HomeIndexViewModel
            {
                Students = vms
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var student = _repository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            var student=new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                Gender = model.Gender
            };
            _repository.Add(student);
            return View("Detail",student);
        }
    }
}
