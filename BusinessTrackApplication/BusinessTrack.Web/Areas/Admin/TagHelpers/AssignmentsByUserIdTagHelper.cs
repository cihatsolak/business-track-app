using BusinessTrack.Business.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Text;

namespace BusinessTrack.Web.Areas.Admin.TagHelpers
{
    [HtmlTargetElement("assignmentsbyuserid")]
    public class AssignmentsByUserIdTagHelper : TagHelper
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentsByUserIdTagHelper(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        public int UserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var htmlContent = new StringBuilder();

            if (UserId > 0)
            {
                var assignments = _assignmentService.GetAssignmentsByUserId(UserId);

                if (assignments != null)
                {
                    var taskCompletedCount = assignments.Where(i => i.Status).Count();
                    var taskInCompleteCount = assignments.Where(i => !i.Status).Count();


                    htmlContent.AppendLine($"<strong>Tamamladığı Görev Sayısı: {taskCompletedCount}</strong>");
                    htmlContent.AppendLine("</br>");
                    htmlContent.AppendLine($"<strong>Çalışılan Görev Sayısı: {taskInCompleteCount}</strong>");

                    output.Content.SetHtmlContent(htmlContent.ToString());
                }
            }
        }
    }
}
