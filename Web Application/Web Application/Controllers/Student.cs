using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models;

namespace Web_Application.Controllers
{
    public class Student : Controller
    {
        private AppDbContext _db;
        public Student(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
       
        }
        public IActionResult Display()
        {
            ViewBag.dbdata = _db.StudentInfos.ToList();
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(StudentInfo Stu)
        {
            _db.StudentInfos.Add(Stu);
            _db.SaveChanges();

            return Redirect("/example/index");
        }
        [HttpGet]
        public IActionResult Edit( int id)
        {
            var data = _db.StudentInfos.FirstOrDefault( random => random.StudentId == id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(StudentInfo Stu) {

            var previous_data = _db.StudentInfos.FirstOrDefault(p => p.StudentId == Stu.StudentId);

            previous_data.StudentName = Stu.StudentName;
            previous_data.Department = Stu.Department;
            previous_data.Address = Stu.Address;

            _db.StudentInfos.Update(previous_data);
            _db.SaveChanges();
            return Redirect("/example/index");

        }

        
        public IActionResult Delete(int id)
        {
            var d = _db.StudentInfos.FirstOrDefault( r => r.StudentId == id);
            _db.StudentInfos.Remove(d);
            _db.SaveChanges();
            return Redirect("/example/index");
        }
    }
}
