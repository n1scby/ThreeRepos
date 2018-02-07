using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThreeRepos.Controllers
{
    public class ResortController : Controller
    {
        private readonly IResortRepository _resortRepo;

        public ResortController(IResortRepository resortRepo)
        {
            _resortRepo = resortRepo;
        }

        // GET: Resort
        public ActionResult Index()
        {
            return View(_resortRepo.GetList());
        }

        // GET: Resort/Details/5
        public ActionResult Details(int id)
        {
            return View(_resortRepo.GetById(id));
        }

        // GET: Resort/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resort/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resort newResort, IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View(newResort);
            }

            try
            {
                _resortRepo.Add(newResort);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(newResort);
            }
        }

        // GET: Resort/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_resortRepo.GetById(id));
        }

        // POST: Resort/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Resort updatedResort, int id, IFormCollection collection)
        {
            try
            {
                _resortRepo.Edit(updatedResort);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(updatedResort);
            }
        }

        // GET: Resort/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_resortRepo.GetById(id));
        }

        // POST: Resort/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Resort deleteResort, int id, IFormCollection collection)
        {
            try
            {
                _resortRepo.Delete(deleteResort);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(deleteResort);
            }
        }
    }
}