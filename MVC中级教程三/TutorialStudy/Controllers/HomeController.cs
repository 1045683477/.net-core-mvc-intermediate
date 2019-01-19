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
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentCreateViewModel model)
        {
            //判断model是否符合StudentCreateViewModel中DATA ANNOTAIONS的约束
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate,
                    Gender = model.Gender
                };
                var newstudent = _repository.Add(student);
                //这么些利于重构
                return RedirectToAction("Detail", new { id = newstudent.Id });
            }
            
            ModelState.AddModelError(string.Empty,"model不可为空");
            return View();
        }
    }
}
