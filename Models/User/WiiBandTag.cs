namespace app_example.Models.User
{
    public class WiiBandTag
    {
        public int Id { get; set; }               // primary key (add if you have, else ignore)
        public string TagId { get; set; }         // maps to TAGID
        public string IPAddress { get; set; }     // maps to IPADDRESS
        public DateTime DateTime { get; set; }    // maps to DATETIME
        public string ScannerLoc { get; set; }    // maps to SCANNERLOC
    }
}
