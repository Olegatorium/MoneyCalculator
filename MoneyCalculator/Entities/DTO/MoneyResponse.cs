namespace MoneyCalculator.Entities.DTO
{
    public class MoneyResponse
    {
        public Guid Id { get; set; }
        public string ClientAddress { get; set; }
        public decimal Money { get; set; }
        public int WorkDuration { get; set; }
        public decimal? Сommission { get; set; }
        public DateTime Date { get; set; }
    }
}
