using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ThreeRepos.Models;

namespace ThreeRepos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResortRepository _resortRepo;

            public HomeController(IResortRepository resortRepo)
        {
            _resortRepo = resortRepo;  
        }

        public IActionResult Index()
        {
            return View(_resortRepo.GetList());
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


        public IActionResult Resort(int id)
        {
            return View(_resortRepo.GetById(id));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
