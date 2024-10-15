using System.ComponentModel.DataAnnotations;

namespace MoneyCalculator.Entities
{
    public class MoneyData
    {
        [Key]
        public Guid Id { get; set; }
        public string ClientAddress { get; set; }
        public decimal Money { get; set; }
        public bool IsСommission { get; set; }
    }
}
