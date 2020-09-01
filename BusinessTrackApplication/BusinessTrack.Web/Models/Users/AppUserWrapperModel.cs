namespace BusinessTrack.Web.Models.Users
{
    public class AppUserWrapperModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public bool IsAdmin { get; set; }
        public int UnreadMessageCount { get; set; }
    }
}
