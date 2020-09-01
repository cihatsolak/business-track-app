namespace BusinessTrack.Business.Tools.Settings
{
    public class CookieSettings
    {
        public string Name { get; set; }
        public bool HttpOnly { get; set; }
        public int ExpireTimeSpanMinute { get; set; }
    }
}
