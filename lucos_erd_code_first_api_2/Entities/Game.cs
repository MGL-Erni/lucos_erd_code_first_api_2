using System.ComponentModel.DataAnnotations;

namespace lucos_erd_code_first_api_2
{ 
    public class Game
    {
        [Key]
        public int GameNumber { get; set; }
        public DateOnly GameDate { get; set; }

        // Foreign Keys
        public Guid PlayerWId { get; set; }
        public Guid PlayerBId { get; set; }
        public string OpeningPlayedId { get; set; }

        // Navigation Properties
        public Player PlayerW { get; set; }
        public Player PlayerB { get; set; }
        public Opening OpeningPlayed { get; set; }

        public string Result { get; set; }
    }
}