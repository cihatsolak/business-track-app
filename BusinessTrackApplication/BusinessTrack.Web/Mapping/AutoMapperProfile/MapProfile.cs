using AutoMapper;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Admin.Models.Assignments;
using BusinessTrack.Web.Areas.Admin.Models.Exigencies;
using BusinessTrack.Web.Areas.Admin.Models.Logs;
using BusinessTrack.Web.Areas.Admin.Models.Reports;
using BusinessTrack.Web.Areas.Member.Models.Reports;
using BusinessTrack.Web.Models.Notifications;
using BusinessTrack.Web.Models.Users;

namespace BusinessTrack.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Exigency Mapping
            CreateMap<ExigencyViewModel, Exigency>();
            CreateMap<Exigency, ExigencyViewModel>();
            #endregion

            #region Notification Mapping
            CreateMap<Notification, NotificationViewModel>();
            CreateMap<NotificationViewModel, Notification>();
            #endregion

            #region Report Mapping
            CreateMap<Report, Areas.Admin.Models.Reports.ReportViewModel>();
            CreateMap<Areas.Admin.Models.Reports.ReportViewModel, Report>();
            CreateMap<Report, ReportAddViewModel>();
            CreateMap<ReportAddViewModel, Report>();
            CreateMap<Areas.Member.Models.Reports.ReportViewModel, Report>();
            CreateMap<Report, Areas.Member.Models.Reports.ReportViewModel>();
            CreateMap<ReportPdfModel, Report>();
            CreateMap<Report, ReportPdfModel>();
            #endregion

            #region AppUser Mapping
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppUserViewModel, AppUser>();
            #endregion

            #region Assignment Mapping
            CreateMap<Assignment, AssignmentViewModel>();
            CreateMap<AssignmentViewModel, Assignment>();
            #endregion

            #region Log Mapping
            CreateMap<LogViewModel, Log>();
            CreateMap<Log, LogViewModel>();
            #endregion
        }
    }
}
