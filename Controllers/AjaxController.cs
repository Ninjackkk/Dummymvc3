using System.Security.Cryptography;
using Dummymvc3.Data;
using Dummymvc3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

        [HttpPost]
        public IActionResult UpdateCommit(Emp e)
        {
            var upd = db.emps.Find(e.Id);
            upd.Name = e.Name;
            upd.Email = e.Email;
            upd.Salary = e.Salary;

            db.emps.Update(upd);
            db.SaveChanges();

            return Json(upd);
        }


        public IActionResult SearchEmp(string sdata)
        {
            var data = db.emps.Where(x=>x.Name.Contains(sdata) || x.Email.Contains(sdata)||x.Salary.ToString().Contains(sdata)).ToList();
            return Json(data);
        }
    }

}
