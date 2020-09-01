namespace BusinessTrack.Web.Areas.Admin.Models.Home
{
    public class CardsViewModel
    {
        public int NumberOfTasksNotAssigned { get; set; }
        public int NumberOfTasksCompleted { get; set; }
        public int UnreadNotifications { get; set; }
        public int TotalReportCount { get; set; }
    }
}
