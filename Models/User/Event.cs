public class Event
{
    public int Id { get; set; }                   // generated ID
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Date { get; set; }            // date part
    public TimeSpan Time { get; set; }            // time part
    public int Duration { get; set; }             // in hours (1, 2, 3)
    public int Jumpers { get; set; }
    public int Socks { get; set; }

    // Add-ons
    public bool EInvitation { get; set; }
    public bool GameCoach { get; set; }
    public bool WaterBottle { get; set; }
    public bool MelonaIC { get; set; }

    public int TrampolineGames { get; set; }

    // Party Area
    public bool PartyArea { get; set; }           // if selected
    public int? PartyGuest { get; set; }          // nullable, only if PartyArea is true
    public int? PartyHours { get; set; }

    // Party Decorations
    public bool PartyDecorationsEnabled { get; set; }  // if selected
    public string? PartyDecorations { get; set; }      // "HalfDeck", "WholeDeck", "Premium"
    public bool FoodCart { get; set; }                 // if include food cart
    public int? ElecFoodCart { get; set; }             // fixed value: 1000

    // Party Equipment
    public bool PartyEquipment { get; set; }           // if selected
    public int? PartyEquipCD { get; set; }             // chafing dish qty
    public int? PartyEquipUtils { get; set; }          // utensils sets

    // Computed
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    // You already had this; keep it if you use serialized extra data
    public string? AddonsData { get; set; }
}
