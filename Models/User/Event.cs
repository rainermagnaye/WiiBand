using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_example.Models.User
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }  // full DateTime now

        [Required]
        [Range(1, 8)]
        public int Duration { get; set; }

        [Required]
        [Range(1, 100)]
        public int Jumpers { get; set; }

        [Required]
        [Range(1, 100)]
        public int Socks { get; set; }

        public bool EInvitation { get; set; }
        public bool GameCoach { get; set; }
        public bool WaterBottle { get; set; }
        public bool MelonaIC { get; set; }

        public int EquipChafingQty { get; set; }
        public int EquipPlatesQty { get; set; }
        public int EquipSpoonForkQty { get; set; }
        public int EquipGlassQty { get; set; }

        [StringLength(500)]
        public string? Addons { get; set; }

        [Range(1, 10)]
        public int TrampolineGames { get; set; }

        [Range(0, 200)]
        public int PartyGuest { get; set; }

        [Range(0, 12)]
        public int PartyHours { get; set; }

        [StringLength(50)]
        public string? PartyDecorations { get; set; }

        public int ElecFoodCart { get; set; }

        [Range(0, 20)]
        public int PartyEquipCD { get; set; }

        [Range(0, 200)]
        public int PartyEquipUtils { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        // Computed properties
        [NotMapped]
        public decimal TotalCost => CalculateTotalCost();

        [NotMapped]
        public DateTime EndDateTime => Date.AddHours(Duration);  // ✅ now just add hours to Date

        [NotMapped]
        public bool IsCompleted => DateTime.Now > EndDateTime;

        [NotMapped]
        public List<string> AddonsList =>
            string.IsNullOrEmpty(Addons)
                ? new List<string>()
                : Addons.Split(',').Select(a => a.Trim()).ToList();

        private decimal CalculateTotalCost()
        {
            decimal baseCost = 499m * Jumpers * Duration;
            decimal totalCost = baseCost;

            if (EInvitation) totalCost += 3000m;
            if (GameCoach) totalCost += 1500m;
            if (WaterBottle) totalCost += Jumpers * 50m;
            if (MelonaIC) totalCost += Jumpers * 80m;

            totalCost += TrampolineGames * 200m;

            if (!string.IsNullOrEmpty(PartyDecorations))
            {
                totalCost += PartyDecorations switch
                {
                    "HalfDeck" => 8000m,
                    "WholeDeck" => 15000m,
                    "Premium" => 25000m,
                    _ => 0m
                };
            }

            totalCost += PartyEquipCD * 500m;
            totalCost += PartyEquipUtils * 100m;
            totalCost += ElecFoodCart;

            return totalCost;
        }
    }

    // DTO for calendar display
    public class CalendarEventDto
    {
        public string Title { get; set; } = string.Empty;
        public string Start { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Addons { get; set; } = string.Empty;
        public int Jumpers { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Id { get; set; }
    }

    // DTO for recommending packages
    public class PackageRecommendationDto
    {
        public decimal Budget { get; set; }
        public int NumPeople { get; set; }
        public int Duration { get; set; }
        public int Jumpers { get; set; }
        public int Socks { get; set; }
        public bool EInvitation { get; set; }
        public bool GameCoach { get; set; }
        public bool WaterBottle { get; set; }
        public bool MelonaIC { get; set; }
        public string? PartyDecorations { get; set; }
    }
}