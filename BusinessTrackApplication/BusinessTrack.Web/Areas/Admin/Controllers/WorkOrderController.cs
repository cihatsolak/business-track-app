using AutoMapper;
using BusinessTrack.Business.Interfaces;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Admin.Factories;
using BusinessTrack.Web.Areas.Admin.Models.Assignments;
using BusinessTrack.Web.Areas.Admin.Models.Reports;
using BusinessTrack.Web.Constants;
using iTextSharp.text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrack.Web.Areas.Admin.Controllers
{
    public class WorkOrderController : BaseAdminController
    {
        private readonly IFileService _fileService;
        private readonly IAppUserService _appUserService;
        private readonly IAssignmentService _assignmentService;
        private readonly IAssignmentModelFactory _assignmentModelFactory;
        private readonly IReportService _reportService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public WorkOrderController(
            IFileService fileService,
            IAppUserService appUserService,
            IAssignmentService assignmentService,
            IAssignmentModelFactory assignmentModelFactory,
            UserManager<AppUser> userManager,
            IReportService reportService,
            INotificationService notificationService, 
            IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;
            _fileService = fileService;
            _appUserService = appUserService;
            _assignmentService = assignmentService;
            _assignmentModelFactory = assignmentModelFactory;
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var assignments = _assignmentService.GetAllWithAssociatedTables();
            var assignmentListAllViewModel = _assignmentModelFactory.PrepareAssignmentListAllViewModel(assignments);
            return View(assignmentListAllViewModel);
        }

        [HttpGet]
        public IActionResult Detail(int assignmentId)
        {
            if (assignmentId < 1)
                return RedirectToAction(nameof(List));

            var assignment = _assignmentService.GetAssignmentWithReports(assignmentId);

            if (assignment == null)
                return RedirectToAction(nameof(List));

            var assignmentReportsViewModel = _assignmentModelFactory.PrepareAssignmentReportsViewModel(assignment);
            return View(assignmentReportsViewModel);
        }

        [HttpGet]
        public IActionResult UserAssignList(int assignmentId, string s, int pageIndex = 1)
        {
            if (assignmentId < 1)
                return RedirectToAction(nameof(List));

            var assignment = _assignmentService.GetAssignmentWithExigencyById(assignmentId);

            if (assignment == null)
                return RedirectToAction(nameof(List));

            var users = _appUserService.GetAllMember(out int totalCount, pageIndex, s);

            if (users == null)
                return RedirectToAction(nameof(List));

            var assignmentAppUserViewModel =
                _assignmentModelFactory.PrepareAssignmentAppUserViewModel(assignment, users, pageIndex, totalCount);

            assignmentAppUserViewModel.SearchKeyword = s;

            return View(assignmentAppUserViewModel);
        }

        [HttpGet]
        public IActionResult UserAssign(int userId, int assignmentId)
        {
            if (userId < 1 || assignmentId < 1)
                return RedirectToAction(nameof(List));

            var user = _userManager.Users.FirstOrDefault(i => i.Id == userId);

            if (user == null)
                return RedirectToAction(nameof(List));

            var assignment = _assignmentService.GetAssignmentWithExigencyById(assignmentId);

            if (assignment == null)
                return RedirectToAction(nameof(List));

            var assignUserViewModel = _assignmentModelFactory.PrepareAssignUserViewModel(user, assignment);

            return View(assignUserViewModel);
        }

        [HttpPost]
        public IActionResult UserAssign(AssignUserViewModel model)
        {
            var assignment = _assignmentService.GetById(model.AssignmentId);
            assignment.AppUserId = model.UserId;
            _assignmentService.Update(assignment);

            _notificationService.Insert(new Notification
            {
                AppUserId = model.UserId,
                Message = $"{assignment.Name} adlı iş için görevlendirildiniz."
            });

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> ExportExcel(int assignmentId)
        {
            if (assignmentId < 1)
                return RedirectToAction(nameof(List));

            var reports = _reportService.GetReportsByAssignmentId(assignmentId);

            if (reports == null)
                return RedirectToAction(nameof(List));

            var reportPdfModel = _mapper.Map<List<ReportPdfModel>>(reports);

            var byteExcelFile = await _fileService.ExportExcel(reportPdfModel, DateTime.Now.ToShortDateString());

            return File(byteExcelFile, FileInfo.Excel, $"{Guid.NewGuid()}.xlsx");
        }

        [HttpGet]
        public IActionResult ExportPdf(int assignmentId)
        {
            if (assignmentId < 1)
                return RedirectToAction(nameof(List));

            var reports = _reportService.GetReportsByAssignmentId(assignmentId);

            if (reports == null)
                return RedirectToAction(nameof(List));

            var reportPdfModel = _mapper.Map<List<ReportPdfModel>>(reports);

            var path = _fileService.ExportPdf(reportPdfModel);

            return File(path, FileInfo.Pdf, $"{Guid.NewGuid()}.pdf");
        }
    }
}
