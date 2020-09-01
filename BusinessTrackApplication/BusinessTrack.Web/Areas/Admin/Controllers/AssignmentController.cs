using BusinessTrack.Business.Interfaces;
using BusinessTrack.Web.Areas.Admin.Factories;
using BusinessTrack.Web.Areas.Admin.Models.Assignments;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTrack.Web.Areas.Admin.Controllers
{
    public class AssignmentController : BaseAdminController
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IAssignmentModelFactory _assignmentModelFactory;
        private readonly IExigencyService _exigencyService;
        public AssignmentController(
            IAssignmentService assignmentService,
            IAssignmentModelFactory assignmentModelFactory,
            IExigencyService exigencyService)
        {
            _assignmentService = assignmentService;
            _assignmentModelFactory = assignmentModelFactory;
            _exigencyService = exigencyService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var assignments = _assignmentService.GetIncompleteAssignmentWithExigency();
            var assignmentListViewModel = _assignmentModelFactory.PrepareAssignmentListViewModel(assignments);
            return View(assignmentListViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var exigencies = _exigencyService.GetAll();
            var assignmentViewModel = _assignmentModelFactory.PrepareAssignmentViewModel(exigencies);
            return View(assignmentViewModel);
        }

        [HttpPost]
        public IActionResult Create(AssignmentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var assignment = _assignmentModelFactory.PrepareAssignmentEntity(model);
            _assignmentService.Insert(assignment);

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id < 0)
                return RedirectToAction(nameof(List));

            var assignment = _assignmentService.GetById(id);

            if (assignment == null)
                return RedirectToAction(nameof(List));

            var exigencies = _exigencyService.GetAll();
            var assignmentViewModel = _assignmentModelFactory.PrepareAssignmentViewModel(exigencies, assignment);

            return View(assignmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AssignmentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var assignment = _assignmentModelFactory.PrepareAssignmentEntity(model);
            _assignmentService.Update(assignment);

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id < 1)
                return RedirectToAction(nameof(List));

            var assignment = _assignmentService.GetById(id);

            if (assignment == null)
                return RedirectToAction(nameof(List));

            _assignmentService.Delete(assignment);

            return Json(null);
        }
    }
}
