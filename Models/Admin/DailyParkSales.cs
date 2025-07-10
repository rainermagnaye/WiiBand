namespace app_example.Models.Admin
{
    public class DailyParkSales
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string DayOfWeek { get; set; }

        public int GeneralAdmission { get; set; }
        public int ExtendedHour { get; set; }
        public int PWDGeneralAdmission { get; set; }
        public int EarlyJump { get; set; }

        public int OverallPaxQty { get; set; }
        public decimal OverallPaxAmount { get; set; }


    }

}
