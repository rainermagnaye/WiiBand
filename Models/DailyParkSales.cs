using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_example.Models
{
    public class DailyParkSales
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(20)]
        public DayOfWeek DayOfWeek { get; set; }

        public int GeneralAdmission { get; set; }

        public int ExtendedHour { get; set; }

        public int PwdGA { get; set; }

        public int EarlyJump { get; set; }

        public int OverallPaxQty { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OverallPaxAmount { get; set; }

        public int TenHourMultipass { get; set; }

        public int TwentyHourMultipass { get; set; }
    }

}
