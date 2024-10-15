namespace MoneyCalculator.Entities.DTO
{
    public class MoneyResponse
    {
        public Guid Id { get; set; }
        public string ClientAddress { get; set; }
        public decimal Money { get; set; }
        public bool IsСommission { get; set; }
    }
}
