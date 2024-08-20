using System.Security.Cryptography;
using Dummymvc3.Data;
using Dummymvc3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dummymvc3.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ApplicationDbContext db;
        public AjaxController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            db.emps.Add(e);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult GetEmp()
        {
            var data = db.emps.ToList();

            return Json(data);
        }

        public IActionResult DeleteEmp(int eid)
        {
            var data = db.emps.Find(eid);
            db.emps.Remove(data);
            db.SaveChanges();
            return Json(data);
        }

        public IActionResult UpdateEmp(int eid)
        {
            var data = db.emps.Find(eid);
            return Json(data);
        }

        //[HttpPost]
        //public IActionResult UpdateEmp(Emp e)
        //{
        //    db.emps.Update(e);
        //    db.SaveChanges();
        //    return Json(""); 
        //}



    }
}
