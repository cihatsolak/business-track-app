using BusinessTrack.Business.Interfaces;
using BusinessTrack.Web.Factories;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTrack.Web.Areas.Admin.Controllers
{
    public class GraphController : BaseAdminController
    {
        private readonly IAppUserService _appUserService;
        private readonly IAppUserModelFactory _appUserModelFactory;
        public GraphController(IAppUserService appUserService, IAppUserModelFactory appUserModelFactory)
        {
            _appUserService = appUserService;
            _appUserModelFactory = appUserModelFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AssignmentCompleted()
        {
            var users = _appUserService.GetMostWorkCompletedWithFiveStaff();
            string jsonModel = _appUserModelFactory.PrepareDualHelperListJsonModel(users);
            return Json(jsonModel);
        }

        [HttpGet]
        public IActionResult MostEmployed()
        {
            var users = _appUserService.GetMostEmployedStaff();
            string jsonModel = _appUserModelFactory.PrepareDualHelperListJsonModel(users);
            return Json(jsonModel);
        }
    }
}
