using System.ComponentModel.DataAnnotations;

namespace MoneyCalculator.Entities
{
    public class MoneyData
    {
        [Key]
        public Guid Id { get; set; }
        public string ClientAddress { get; set; }
        public decimal Money { get; set; }
        public int WorkDuration { get; set; }
        public decimal? Сommission { get; set; }
        public DateTime Date { get; set; }
    }
}
