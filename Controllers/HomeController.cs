using CrudAppUsingADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudAppUsingADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> obj = db.GetEmployees();
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {

            try
            {
                if (ModelState.IsValid==true)
                {
                    EmployeeDBContext context = new EmployeeDBContext();
                    bool check = context.AddEmployee(emp);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data has been Inserted Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}