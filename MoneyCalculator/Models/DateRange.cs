namespace MoneyCalculator.Models
{
    public class DateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CalculatedResults? Results { get; set; }
    }
}
