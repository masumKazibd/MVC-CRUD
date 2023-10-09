using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDbContext db = new EmployeeDbContext();
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.deptList = new List<SelectListItem>
            {
                new SelectListItem{Text="IT", Value="IT"},
                new SelectListItem{Text="Accounts", Value="Accounts"},
                new SelectListItem{Text="HR", Value="HR"},
                new SelectListItem{Text="Production", Value="Production"},
                new SelectListItem{Text="Marketing", Value= "Marketing"},
                new SelectListItem{Text="----Select----", Value="", Selected=true}
            };
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee Emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(Emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.deptList = new List<SelectListItem>
            {
                new SelectListItem{Text="IT", Value="IT"},
                new SelectListItem{Text="Accounts", Value="Accounts"},
                new SelectListItem{Text="HR", Value="HR"},
                new SelectListItem{Text="Production", Value="Production"},
                new SelectListItem{Text="Marketing", Value= "Marketing"},
                new SelectListItem{Text="----Select----", Value="", Selected=true}
            };
            return View(Emp);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.deptList = new List<SelectListItem>
            {
                new SelectListItem{Text="IT", Value="IT"},
                new SelectListItem{Text="Accounts", Value="Accounts"},
                new SelectListItem{Text="HR", Value="HR"},
                new SelectListItem{Text="Production", Value="Production"},
                new SelectListItem{Text="Marketing", Value= "Marketing"},
                new SelectListItem{Text="----Select----", Value="", Selected=true}
            };
            return View(db.Employees.First(x=>x.Id== id));
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if(ModelState.IsValid)
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.deptList = new List<SelectListItem>
            {
                new SelectListItem{Text="IT", Value="IT"},
                new SelectListItem{Text="Accounts", Value="Accounts"},
                new SelectListItem{Text="HR", Value="HR"},
                new SelectListItem{Text="Production", Value="Production"},
                new SelectListItem{Text="Marketing", Value= "Marketing"},
                new SelectListItem{Text="----Select----", Value="", Selected=true}
            };
            return View(emp);

        }

        public ActionResult Delete(int id)
        {
            Employee emp = db.Employees.First(x => x.Id == id);
            ViewBag.deptList = new List<SelectListItem>
            {
            new SelectListItem {Text="It",Value="IT"},
            new SelectListItem {Text="HR",Value="HR"},
            new SelectListItem {Text="Marketing",Value="Marketing"},
            new SelectListItem{Text="--Select--",Value="",Selected=true}

            };

            return View(emp);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult doDelete(int id)
        {
            Employee emp = db.Employees.First(x => x.Id == id);
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}