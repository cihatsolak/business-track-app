using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.Areas.Admin.Models.Exigencies;
using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Factories
{
    public partial interface IExigencyModelFactory
    {
        ExigencyListViewModel PrepareExigencyListviewModel(List<Exigency> exigencies = null);
        Exigency PrepareExigencyEntity(ExigencyViewModel exigencyViewModel = null);
        ExigencyViewModel PrepareExigencyViewModel(Exigency exigency = null);
    }
}
