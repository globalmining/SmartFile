using FileManagementApp.Data;
using FileManagementApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context,ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            TempData["msg"] = "Welcome Naresh Bhoyar To SmartFile.";
            ViewBag.TotalItems = _context.Items.LongCount();
            ViewBag.TotalSubGroups = _context.SubGroups.Count();
            ViewBag.TotalFiles = _context.PdfFiles.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
       
        public JsonResult UserEmail(string id)
        {
            UserEmail email = new UserEmail();
            bool IsAvailable = _context.UserEmail.Any(m => m.Emailid == id);
            if (!IsAvailable)
            {
                email.Emailid = id;
                email.CreatedDate = DateTime.Now;
                _context.UserEmail.Add(email);
                _context.SaveChanges();
                return Json(true);
            }
            else
            {
                return Json(false);
            }
            
        }        
        
    }
}
