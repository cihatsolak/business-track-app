using BusinessTrack.Business.Interfaces;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Admin.Factories;
using BusinessTrack.Web.Areas.Member.Factories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Areas.Member.Controllers
{
    public class TaskController : BaseMemberController
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IWorkModelFactory _workModelFactory;

        public TaskController(
            IAssignmentService assignmentService,
            UserManager<AppUser> userManager,
            IWorkModelFactory workModelFactory) : base(userManager)
        {
            _assignmentService = assignmentService;
            _workModelFactory = workModelFactory;
        }

        [HttpGet]
        public async Task<IActionResult> List(int pageIndex = 1)
        {
            var user = await CurrentUser();

            var assignments = _assignmentService.GetAllInCompleteWithRelationships(out int totalPageCount, user.Id, pageIndex);
            var assignedJobListViewModel = _workModelFactory.PrepareAssignedJobListViewModel(assignments);

            ViewBag.TotalPageCount = totalPageCount;
            ViewBag.ActivePage = pageIndex;

            return View(assignedJobListViewModel);
        }
    }
}
