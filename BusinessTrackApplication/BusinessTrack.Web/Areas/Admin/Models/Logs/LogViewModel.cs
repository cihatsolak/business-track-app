using BusinessTrack.Web.Models;
using System;

namespace BusinessTrack.Web.Areas.Admin.Models.Logs
{
    public class LogViewModel : BaseEntityModel<int>
    {
        public string Path { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string CreatedOn { get; set; }
    }
}
