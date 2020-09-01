using AutoMapper;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Member.Models.Reports;
using System;

namespace BusinessTrack.Web.Areas.Member.Factories
{
    public class ReportModelFactory : IReportModelFactory
    {
        private readonly IMapper _mapper;
        public ReportModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ReportAddViewModel PrepareReportAddViewModel(Assignment assignment = null, Report report = null)
        {
            var reportAddViewModel = new ReportAddViewModel();

            if (report != null)
            {
                reportAddViewModel.Id = report.Id;
                reportAddViewModel.Detail = report.Detail;
                reportAddViewModel.Definition = report.Definition;
                reportAddViewModel.AssignmentId = report.AssignmentId;
                reportAddViewModel.AssignmentName = report.Assignment.Name;
                reportAddViewModel.AssignmentDescription = report.Assignment.Description;
                reportAddViewModel.AssignmentExigencyDefinition = report.Assignment.Exigency.Definition;

                return reportAddViewModel;
            }

            reportAddViewModel.AssignmentId = assignment.Id;
            reportAddViewModel.AssignmentName = assignment.Name;
            reportAddViewModel.AssignmentDescription = assignment.Description;
            reportAddViewModel.AssignmentExigencyDefinition = assignment.Exigency.Definition;

            return reportAddViewModel;
        }

        public Report PrepareReportEntity(ReportAddViewModel reportAddViewModel = null)
        {
            if (reportAddViewModel == null)
                throw new ArgumentNullException(nameof(reportAddViewModel));

            var report = _mapper.Map<Report>(reportAddViewModel);
            return report;
        }
    }
}
