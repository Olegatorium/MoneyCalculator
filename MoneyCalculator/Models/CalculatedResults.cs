namespace MoneyCalculator.Models
{
    public class CalculatedResults
    {
        // Загальна сума
        public decimal TotalAmount { get; set; }

        // Комісія
        public decimal Commission { get; set; }

        // Чисті (Чистий дохід після вирахування комісії)
        public decimal NetAmount
        {
            get
            {
                return TotalAmount - Commission;
            }
        }
    }

}
