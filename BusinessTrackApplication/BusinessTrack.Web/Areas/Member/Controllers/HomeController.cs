using BusinessTrack.Business.Interfaces;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Member.Models.Home.Cards;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Areas.Member.Controllers
{
    public class HomeController : BaseMemberController
    {
        private readonly IReportService _reportService;
        private readonly IAssignmentService _assignmentService;
        private readonly INotificationService _notificationService;
        public HomeController(
            IReportService reportService,
            UserManager<AppUser> userManager,
            IAssignmentService assignmentService,
            INotificationService notificationService) : base(userManager)
        {
            _notificationService = notificationService;
            _reportService = reportService;
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await CurrentUser();

            var cardsViewModel = new CardsViewModel()
            {
                TotalNumberOfReports = _reportService.GetReportCountByUserId(user.Id),
                NumberOfTasksCompleted = _assignmentService.GetCompletedTaskCountByUserId(user.Id),
                NumberOfMissionsCompleted = _assignmentService.GetInCompletedTaskCountByUserId(user.Id),
                UnreadNotifications = _notificationService.GetUnreadNotificationsCountByUserId(user.Id)
            };

            return View(cardsViewModel);
        }
    }
}
