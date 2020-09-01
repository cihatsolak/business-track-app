using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Member.Models.Works;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Member.Factories
{
    public interface IWorkModelFactory
    {
        AssignedJobListViewModel PrepareAssignedJobListViewModel(List<Assignment> assignments = null);
    }
}
