using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models;

namespace Web_Application.Controllers
{
    public class ExampleController : Controller
    {
        private AppDbContext _db;
        

        public ExampleController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Loadata()
        {
            var dbdata = _db.StudentInfos.ToList();
            var data = dbdata.Select(d => new StudentInfo
            {
                StudentId = d.StudentId,
                StudentName = d.StudentName,
                Department = d.Department,
                Address = d.Address
            }).ToList(); 

            //return Json(data);
            return Json(new { data = data });
        }
    }
}
