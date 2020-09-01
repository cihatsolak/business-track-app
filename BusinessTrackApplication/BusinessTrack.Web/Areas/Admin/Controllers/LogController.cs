using AutoMapper;
using BusinessTrack.Business.Interfaces;
using BusinessTrack.Web.Areas.Admin.Models.Logs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Controllers
{
    public class LogController : BaseAdminController
    {
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;
        public LogController(ILoggerService loggerService, IMapper mapper)
        {
            _loggerService = loggerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var logs = _loggerService.GetAll();

            var logListViewModel = new List<LogViewModel>();

            if (logs == null)
                return View(logListViewModel);

            foreach (var log in logs)
            {
                logListViewModel.Add(new LogViewModel
                {
                    Id = log.Id,
                    Message = log.Message,
                    Path = log.Path,
                    Source = log.Source,
                    CreatedOn = log.CreatedOn.ToLongDateString()
                });
            }

            return View(logListViewModel);
        }
    }
}
