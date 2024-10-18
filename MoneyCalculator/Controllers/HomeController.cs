using Microsoft.AspNetCore.Mvc;
using MoneyCalculator.Entities.DTO;
using MoneyCalculator.Models;
using MoneyCalculator.ServiceContracts;

namespace MoneyCalculator.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IMoneyService _moneyService;
        public HomeController(IMoneyService moneyService)
        {
            _moneyService = moneyService;
        }

        [Route("[action]")]
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        [Route("/")]
        [HttpPost]
        public async Task<IActionResult> Index(MoneyAddRequest moneyAddRequest)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View();
            }

            bool isCreated = await _moneyService.Create(moneyAddRequest);

            if (isCreated) 
            {
                ViewBag.Message = "Дані завантажено";
            }

            return View();
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetCalculatedResults()
        {
            // Инициализация диапазона дат за последнюю неделю
            var model = new DateRange
            {
                StartDate = DateTime.Today.AddDays(-7), // 7 дней назад
                EndDate = DateTime.Today                // Сегодня
            };

            model.Results = await _moneyService.GetResultsForDateRange(model.StartDate, model.EndDate);

            return View(model);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> GetCalculatedResults(DateRange model)
        {
            if (model.StartDate > model.EndDate)
            {
                ViewBag.Error = "Початкова дата не може бути пізнішою ніж кінцева дата";
                return View();
            }

            model.Results = await _moneyService.GetResultsForDateRange(model.StartDate, model.EndDate);

            return View(model);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<List<MoneyResponse>>> GetRecords()
        {
            List<MoneyResponse> moneyResponses = await _moneyService.GetRecords();

            return View(moneyResponses);
        }
    }
}
