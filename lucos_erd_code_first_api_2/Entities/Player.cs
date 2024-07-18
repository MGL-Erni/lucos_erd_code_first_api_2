using System.ComponentModel.DataAnnotations;

namespace lucos_erd_code_first_api_2
{
    public class Player
    {
        [Key]
        public Guid PlayerId { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public int PlayerRating { get; set; }
    }
}