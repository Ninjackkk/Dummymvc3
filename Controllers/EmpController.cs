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
        public IActionResult Create()
        {
            return RedirectToAction("AddEmp");
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
            return RedirectToAction("AddEmp");
        }


        public IActionResult ViewData()
        {
            var obj=db.emps.ToList();
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            // var data = db.emps.Where(a=>a.Id.Equals(id)).SingleOrDefault();
            var data = db.emps.Find(id);
            db.emps.Remove(data);
            TempData["dmsg"] = "Emp Deleted Successfully";
            db.SaveChanges();
            return RedirectToAction("AddEmp");
        }

        public IActionResult Edit(int id)
        {
           var data=db.emps.Find(id);
            return View(data);  
        }
        [HttpPost]
        public IActionResult Edit(Emp e)
        {
            
            var data = db.emps.Update(e);
            db.SaveChanges();
            TempData["umsg"] = "Emp Updated Successfully";
            return RedirectToAction("AddEmp");
        }
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            var data = db.emps.Where(a => a.Name.Contains(name)).ToList();
            return View("ViewData", data); 
        }


        public IActionResult DeleteSelected()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSelected(IEnumerable<int> Empbyid)
        {
            foreach (var id in Empbyid)
            {
                var emp = db.emps.Single(s => s.Id == id);

                db.emps.Remove(emp);
            }
            db.SaveChanges();
            return RedirectToAction("AddEmp");

        }



    }
}
