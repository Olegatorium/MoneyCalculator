using MoneyCalculator.Entities.DTO;
using MoneyCalculator.Models;

namespace MoneyCalculator.ServiceContracts
{
    public interface IMoneyService
    {
        Task<bool> Create(MoneyAddRequest moneyAddRequest);
        Task<CalculatedResults> GetResultsForDateRange(DateTime startDate, DateTime endDate);
        Task<List<MoneyResponse>> GetRecords();
        Task<MoneyResponse> GetMoneyRecordById(Guid moneyId);
        Task UpdateMoneyRecord(MoneyUpdateRequest moneyUpdateRequest);
        Task DeleteMoneyRecord(MoneyUpdateRequest moneyUpdateRequest);
    }
}
