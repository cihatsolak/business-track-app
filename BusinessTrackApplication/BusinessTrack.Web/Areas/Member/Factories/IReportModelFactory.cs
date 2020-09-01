using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Member.Models.Reports;

namespace BusinessTrack.Web.Areas.Member.Factories
{
    public interface IReportModelFactory
    {
        ReportAddViewModel PrepareReportAddViewModel(Assignment assignment = null, Report report = null);
        Report PrepareReportEntity(ReportAddViewModel reportAddViewModel = null);

    }
}
