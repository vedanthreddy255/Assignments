using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationCaseStudy.Migrations;
using WebApplicationCaseStudy.Models;

namespace WebApplicationCaseStudy.Controllers
{
    public class HomeController : Controller
    {
        DetailsDbContext _context;

        public HomeController(DetailsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string UserName,string UserPassword)
        {
            User name=_context.Users.SingleOrDefault(item=> (item.UserName == UserName) && (item.UserPassword == UserPassword));
            
            if(name!=null)
            {
                return RedirectToAction("Index","Employee");
                
            }
            else
            {
                ViewBag.Message="Incorrect UserCredentials";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}