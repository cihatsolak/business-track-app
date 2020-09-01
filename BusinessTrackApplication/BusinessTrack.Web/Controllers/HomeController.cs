using BusinessTrack.Business.Interfaces;
using BusinessTrack.Entities.Concrete;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BusinessTrack.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoggerService _loggerService;
        public HomeController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        [HttpGet]
        public IActionResult StatusCode(int? code)
        {
            ViewBag.Code = code;

            ViewBag.Message = code switch
            {
                404 => "Aradığınız sayfa bulunamadı.",
                _ => "Belirlenemeyen bir hata oluştu.",
            };
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Message = exception.Error.Message;
            ViewBag.Path = exception.Path;

            _loggerService.Insert(new Log
            {
                Message = exception.Error.Message,
                Source = exception.Error.Source,
                StackTrase = exception.Error.StackTrace,
                Path = exception.Path,
                CreatedOn = DateTime.Now
            });

            return View();
        }

        [HttpGet]
        public IActionResult Hata()
        {
            throw new ArgumentNullException("bir hata oluştu");
        }       
    }
}
