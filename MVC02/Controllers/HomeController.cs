﻿using System;
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
            ViewData["Message"] = "";

            return View();
        }

        public IActionResult ContactDone(ContactVm contact)
        {
            if (ModelState.IsValid)
            {
                string path = @"C:\Project\AcceleratedLearning\MVC\MVCProject02\MVC02\Data\Textfile\Messages.txt";
                string newthing = $"Namn: {contact.Name}, Email: {contact.Email}, Subject: {contact.Subject}, Message: {contact.Message}";
                using (StreamWriter sw = System.IO.File.AppendText(path))
                {
                    sw.WriteLine(newthing);
                }

                ViewData["Message"] = "Tack för ditt meddelande, vi hör av oss.";
                return View("Contact");
            }
            else
            {
                ViewData["Message"] = "Någnoting gick fel, försök igen.";
                return View("Contact");

            }
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


        public IActionResult Messages()
        {
            string[] messages = System.IO.File.ReadAllLines(@"C:\Project\AcceleratedLearning\MVC\MVCProject02\MVC02\Data\Textfile\Messages.txt");
            List<string> newList = new List<string>();

            foreach (var item in messages)
            {
              newList.Add(item);
            }

            ViewData["Messages"] = newList;

            return View();
        }




    }
}
