using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ThreeRepos.Controllers
{
    [Authorize]
    public class ResortController : Controller
    {
        private readonly IResortRepository _resortRepo;
        private readonly ILogger _logger;

        public ResortController(IResortRepository resortRepo, ILogger<ResortController> logger)
        {
            _resortRepo = resortRepo;
            _logger = logger;
        }

        // GET: Resort
        [AllowAnonymous]
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
                _logger.LogWarning("Model State is Invalid: {Id}", newResort.Id);
                return View(newResort);
            }
            
            try
            {
                _resortRepo.Add(newResort);
                _logger.LogInformation("New Resort Added. Id: {id}  Name: {name}", newResort.Id, newResort.Name);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
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
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

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
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

                return View(deleteResort);
            }
        }
    }
}