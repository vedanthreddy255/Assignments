using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCaseStudy.Models;

namespace WebApplicationCaseStudy.Controllers
{
    public class EmployeeController : Controller
    {

        DetailsDbContext dbcontext;
        public EmployeeController(DetailsDbContext context)
        {
            dbcontext = context;
        }

        public IActionResult Index()
        {
            return View(dbcontext.Employees.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            dbcontext.Employees.Add(obj);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee obj = dbcontext.Employees.Find(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = dbcontext.Employees.Find(id);
            return View(obj);
        }
       
        [HttpGet]
        public IActionResult DepartmentDetails()
        {
            List<string> uniqueDepartmentNames=dbcontext.Employees.Select(i=>i.Department).Distinct().ToList();

            ViewBag.UniqueDepartmentNames = uniqueDepartmentNames;
            return View();
        }

        [HttpGet]
        public IActionResult Dept(string id)
        {
            List<Employee> dep = dbcontext.Employees.Where(opt => opt.Department == id).ToList();

            if (dep == null)
            {
                return NotFound(new { result = "Not available" });
            }
            else
            {
                return View(dep);
            }
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            dbcontext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = dbcontext.Employees.Find(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            Employee obj = dbcontext.Employees.Find(int.Parse(id));
            dbcontext.Employees.Remove(obj);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
