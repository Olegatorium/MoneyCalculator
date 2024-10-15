using MoneyCalculator.Entities.DTO;

namespace MoneyCalculator.ServiceContracts
{
    public interface IMoneyService
    {
        Task<bool> Create(MoneyAddRequest moneyAddRequest);
    }
}
