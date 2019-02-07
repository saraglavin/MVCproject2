using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC02.Models;
using MVC02.Models.ViewModels;
using System.IO;
using System.Text;


namespace MVC02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult ContactDone(ContactVm contact)
        {


            string path = @"C:\Project\AcceleratedLearning\MVC\MVCProject02\MVC02\Data\Textfile\Messages.txt";
            string newthing = $"Namn: {contact.Name}, Email: {contact.Email}, Subject: {contact.Subject}, Message: {contact.Message} \n";
            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine(newthing);
            }

            return View("Contact");
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
    }
}
