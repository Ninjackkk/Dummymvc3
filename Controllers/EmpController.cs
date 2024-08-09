using Dummymvc3.Data;
using Dummymvc3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dummymvc3.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext db;
        public EmpController(ApplicationDbContext db)
        {
            this.db = db;
        }



        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            db.emps.Add(e);
            db.SaveChanges();
            TempData["msg"] = "Emp Added Successfully";
            return RedirectToAction("Index");
        }


        public IActionResult ViewData()
        {
            var obj=db.emps.ToList();
            return View(obj);
        }
    }
}
