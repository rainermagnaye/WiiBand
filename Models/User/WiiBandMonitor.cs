namespace app_example.Models.User
{
    public class WiiBandMonitor
    {
        public int Id { get; set; }               // primary key (add if you have, else ignore)
        public string WiiBandTag { get; set; }    // maps to wiibandtag
        public string WiiBandIp { get; set; }     // maps to wiibandip
        public DateTime StartTime { get; set; }   // maps to starttime
        public DateTime? EndTime { get; set; }    // maps to endtime (nullable)
    }
}
