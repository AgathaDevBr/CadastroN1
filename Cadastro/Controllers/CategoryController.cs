using Cadastro.Interfaces;
using Cadastro.Services;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryViewModelService _categoryViewModelService;

        public CategoryController(ICategoryViewModelService categoryViewModelService)
        {
            _categoryViewModelService = categoryViewModelService;
        }

        // GET: CagController
        public ActionResult Index()
        {
            var list = _categoryViewModelService.GetAll();
            return View(list);
        }

        // GET: CagController/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = _categoryViewModelService.Get(id);
            return View(viewModel);
        }

        // GET: CagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _categoryViewModelService.Insert(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: CagController/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = _categoryViewModelService.Get(id);
            return View();
        }

        // POST: CagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryViewModelService.Update(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: CagController/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _categoryViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: CagController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _categoryViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _categoryViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
