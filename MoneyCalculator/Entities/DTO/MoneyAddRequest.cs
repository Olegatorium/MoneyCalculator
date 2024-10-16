using System.ComponentModel.DataAnnotations;

namespace MoneyCalculator.Entities.DTO
{
    public class MoneyAddRequest
    {
        [Required(ErrorMessage = "'Адреса' не може бути пустою")]
        [MinLength(3, ErrorMessage = "Адреса має бути мінімум 3 символа")]
        public string ClientAddress { get; set; }

        [Required(ErrorMessage = "'Заробіток' не може бути пустим")]
        public decimal? Money { get; set; }

        public decimal? Сommission { get; set; }

        [Required(ErrorMessage = "Потрібно вказати дату")]
        public DateTime? Date { get; set; }
    }
}
