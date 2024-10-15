using AutoMapper;
using Entities;
using MoneyCalculator.Entities;
using MoneyCalculator.Entities.DTO;
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
            if (moneyAddRequest == null)
                return false;

            MoneyData moneyDomain = _mapper.Map<MoneyData>(moneyAddRequest);

            moneyDomain.Id = Guid.NewGuid();

            await _db.AddAsync(moneyDomain);

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
