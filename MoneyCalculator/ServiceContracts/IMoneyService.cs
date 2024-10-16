﻿using MoneyCalculator.Entities.DTO;
using MoneyCalculator.Models;

namespace MoneyCalculator.ServiceContracts
{
    public interface IMoneyService
    {
        Task<bool> Create(MoneyAddRequest moneyAddRequest);
        Task<CalculatedResults> GetResultsForDateRange(DateTime startDate, DateTime endDate);
    }
}
