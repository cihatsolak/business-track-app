using System.Collections.Generic;

namespace BusinessTrack.Web.Areas.Admin.Models.Exigencies
{
    public class ExigencyListViewModel
    {
        public List<ExigencyViewModel> ExigencyViewModels { get; set; }

        public ExigencyListViewModel()
        {
            ExigencyViewModels = new List<ExigencyViewModel>();
        }
    }
}
