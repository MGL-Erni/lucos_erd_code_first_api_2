using System.ComponentModel.DataAnnotations;

namespace lucos_erd_code_first_api_2
{
    public class Opening
    {
        [Key]
        public string OpeningCode { get; set; }
        public string OpeningName { get; set; }
    }
}