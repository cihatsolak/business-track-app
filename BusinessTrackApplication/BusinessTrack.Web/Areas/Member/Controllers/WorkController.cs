using BusinessTrack.Business.Interfaces;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Member.Factories;
using BusinessTrack.Web.Areas.Member.Models.Reports;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Areas.Member.Controllers
{
    public class WorkController : BaseMemberController
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IWorkModelFactory _workModelFactory;
        private readonly IReportService _reportService;
        private readonly IReportModelFactory _reportModelFactory;
        private readonly INotificationService _notificationService;

        public WorkController(
            IAssignmentService assignmentService,
            IWorkModelFactory workModelFactory,
            UserManager<AppUser> userManager,
            IReportService reportService,
            IReportModelFactory reportModelFactory,
            INotificationService notificationService):base(userManager)
        {
            _notificationService = notificationService;
            _reportService = reportService;
            _assignmentService = assignmentService;
            _workModelFactory = workModelFactory;
            _reportModelFactory = reportModelFactory;
        }

        [HttpGet]
        public async Task<IActionResult> AssignedWork()
        {
            var user = await CurrentUser();
            var assigments = _assignmentService.GetAllWithAssociatedTablesByUserId(user.Id);
            var assignedJobListViewModel = _workModelFactory.PrepareAssignedJobListViewModel(assigments);
            return View(assignedJobListViewModel);
        }

        [HttpGet]
        public IActionResult CreateReport(int workId)
        {
            var assignment = _assignmentService.GetAssignmentWithExigencyById(workId);
            var reportAddViewModel = _reportModelFactory.PrepareReportAddViewModel(assignment);
            return View(reportAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport(ReportAddViewModel reportAddViewModel)
        {
            if (!ModelState.IsValid)
                return View(reportAddViewModel);

            var report = _reportModelFactory.PrepareReportEntity(reportAddViewModel);
            _reportService.Insert(report);

            var currentUser = await CurrentUser();
            var administrators = await _userManager.GetUsersInRoleAsync("Admin");

            _notificationService.SendNotificationsManagers(currentUser, "yeni bir rapor yazdı.", administrators.ToList());

            return RedirectToAction(nameof(AssignedWork));
        }

        [HttpGet]
        public IActionResult EditReport(int id)
        {
            if (id < 1)
                return RedirectToAction(nameof(AssignedWork));

            var report = _reportService.GetReportWithAssignment(id);
            var reportAddViewModel = _reportModelFactory.PrepareReportAddViewModel(null, report);
            return View(reportAddViewModel);
        }

        [HttpPost]
        public IActionResult EditReport(ReportAddViewModel reportAddViewModel)
        {
            if (!ModelState.IsValid)
                return View(reportAddViewModel);

            var report = _reportService.GetById(reportAddViewModel.Id);

            if (report == null)
                return RedirectToAction(nameof(AssignedWork));

            report = _reportModelFactory.PrepareReportEntity(reportAddViewModel);
            _reportService.Update(report);

            return RedirectToAction(nameof(AssignedWork));
        }

        [HttpGet]
        public async Task<IActionResult> AssignedCompleted(int assignmentId)
        {
            if (assignmentId < 1)
                return RedirectToAction(nameof(AssignedWork));

            var assignment = _assignmentService.GetById(assignmentId);

            if (assignment == null)
                return RedirectToAction(nameof(AssignedWork));

            assignment.Status = true;
            _assignmentService.Update(assignment);

            var currentUser = await CurrentUser();
            _notificationService.SendNotificationsManagers(currentUser, "vermiş olduğunuz bir görevi tamamladı.");

            return Json(null);
        }
    }
}
