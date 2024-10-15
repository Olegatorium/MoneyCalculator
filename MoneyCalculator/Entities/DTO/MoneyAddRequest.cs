using System.ComponentModel.DataAnnotations;

namespace MoneyCalculator.Entities.DTO
{
    public class MoneyAddRequest
    {
        [Required]
        [MinLength(3, ErrorMessage = "Address has to be a minimum of 3 characters")]
        public string ClientAddress { get; set; }

        [Required]
        public decimal Money { get; set; }

        [Required]
        public bool IsСommission { get; set; }
    }
}
