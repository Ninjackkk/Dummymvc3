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
       





    }
}
