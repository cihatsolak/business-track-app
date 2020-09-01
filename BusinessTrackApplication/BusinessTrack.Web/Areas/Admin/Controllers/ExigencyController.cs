using BusinessTrack.Business.Interfaces;
using BusinessTrack.Web.Areas.Admin.Factories;
using BusinessTrack.Web.Areas.Admin.Models.Exigencies;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTrack.Web.Areas.Admin.Controllers
{
    public class ExigencyController : BaseAdminController
    {
        private readonly IExigencyService _exigencyService;
        private readonly IExigencyModelFactory _exigencyModelFactory;
        public ExigencyController(IExigencyService exigencyService, IExigencyModelFactory exigencyModelFactory)
        {
            _exigencyService = exigencyService;
            _exigencyModelFactory = exigencyModelFactory;
        }

        [HttpGet]
        public IActionResult List()
        {
            var exigencies = _exigencyService.GetAll();
            var exigencyListViewModel = _exigencyModelFactory.PrepareExigencyListviewModel(exigencies);
            return View(exigencyListViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExigencyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var exigency = _exigencyModelFactory.PrepareExigencyEntity(model);
            _exigencyService.Insert(exigency);

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id < 0)
                return View(nameof(List));

            var exigency = _exigencyService.GetById(id);

            if (exigency == null)
                return View(nameof(List));

            var exigencyViewModel = _exigencyModelFactory.PrepareExigencyViewModel(exigency);

            return View(exigencyViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ExigencyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var exigency = _exigencyModelFactory.PrepareExigencyEntity(model);
            _exigencyService.Update(exigency);

            return RedirectToAction(nameof(List));
        }
    }
}
