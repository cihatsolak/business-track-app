using BusinessTrack.Business.Interfaces;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Admin.Models.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        private readonly IAssignmentService _assignmentService;
        private readonly INotificationService _notificationService;
        private readonly IReportService _reportService;
        public HomeController(
            IAssignmentService assignmentService, 
            INotificationService notificationService,
            UserManager<AppUser> userManager,
            IReportService reportService): base(userManager)
        {
            _assignmentService = assignmentService;
            _notificationService = notificationService;
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await CurrentUser();

            var cardsViewModel = new CardsViewModel
            {
                NumberOfTasksNotAssigned = _assignmentService.GetUnAssignedTaskCount(),
                NumberOfTasksCompleted = _assignmentService.GetCompletedTaskCount(),
                UnreadNotifications = _notificationService.GetUnreadNotificationsCountByUserId(user.Id),
                TotalReportCount = _reportService.GetAllReportCount()
            };

            return View(cardsViewModel);
        }
    }
}
