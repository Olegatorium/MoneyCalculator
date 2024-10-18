﻿using AutoMapper;
using Entities;
using Microsoft.EntityFrameworkCore;
using MoneyCalculator.Entities;
using MoneyCalculator.Entities.DTO;
using MoneyCalculator.Models;
using MoneyCalculator.ServiceContracts;

namespace MoneyCalculator.Services
{
    public class MoneyService : IMoneyService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public MoneyService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> Create(MoneyAddRequest moneyAddRequest)
        {
            MoneyData moneyDomain = _mapper.Map<MoneyData>(moneyAddRequest);

            moneyDomain.Id = Guid.NewGuid();

            await _db.AddAsync(moneyDomain);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<CalculatedResults> GetResultsForDateRange(DateTime startDate, DateTime endDate) 
        {
            List<MoneyData> moneyRecords = await _db.MoneyData
             .Where(x=> x.Date >= startDate && x.Date <= endDate)
             .ToListAsync();

            CalculatedResults results = new CalculatedResults();

            foreach (var item in moneyRecords)
            {
                results.TotalAmount += item.Money * item.WorkDuration;

                results.Commission += (item.Сommission ?? 0) * item.WorkDuration;
            }

            return results;
        }
        public async Task<List<MoneyResponse>> GetRecords() 
        {

            List<MoneyData> moneyDomain = await _db.MoneyData
            .OrderByDescending(m => m.Date)
            .Take(30)
            .ToListAsync();

            List<MoneyResponse> moneyResponses = _mapper.Map<List<MoneyResponse>>(moneyDomain);

            return moneyResponses;
        }

    }
}
