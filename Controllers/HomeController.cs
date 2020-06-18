using firstApp.Model;
using firstApp.Services;
using firstApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRespository<Student> _respository;
        public HomeController(IRespository<Student> respository)
        {
            _respository = respository;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = _respository.GetAll();
            var vms=students.Select(s =>
                new StudentViewModel()
                {
                    FullName = $"{s.FirstName}{s.LastName}",//s.FirstName + s.LastName,
                    Id = s.Id,
                    Age = DateTime.Now.Subtract(s.Birthday).Days/365,
                    gender = s.gender
                }
           );
            var vm = new HomeIndexModel()
            {
                Students = vms
            };
            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            var student = _respository.Detail(id);
            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newStu = new Student()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Birthday = viewModel.BirthDay,
                    gender = viewModel.gender
                };
                var stuModel = _respository.Add(newStu);
                return RedirectToAction(nameof(Detail), new { id = newStu.Id });
            }
            else
            {
                return View();
            }
            
            //return RedirectToAction("Detail");
            //return View("Detail",stuModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id,EditViewModel editViewModel) 
        {
            var stu = _respository.Detail(id);
            if (stu != null)
            {
                stu.FirstName = editViewModel.FirstName;
                stu.LastName = editViewModel.LastName;
                stu.Birthday = editViewModel.BirthDay;
                stu.gender = editViewModel.gender;
                return RedirectToAction(nameof(Detail), new { id = stu.Id });
            }
            return View(stu);
        }
    }
}
