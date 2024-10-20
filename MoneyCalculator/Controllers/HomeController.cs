using AutoMapper;
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
        private readonly IMapper _mapper;

        public HomeController(IMoneyService moneyService, IMapper mapper)
        {
            _moneyService = moneyService;
            _mapper = mapper;
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

        [HttpGet]
        [Route("[action]/{moneyId}")]
        public async Task<IActionResult> Edit(Guid moneyId)
        {
            MoneyResponse moneyResponse = await _moneyService.GetMoneyRecordById(moneyId);

            if (moneyResponse == null)
            {
                return RedirectToAction("GetRecords");
            }

            MoneyUpdateRequest moneyUpdateRequest = _mapper.Map<MoneyUpdateRequest>(moneyResponse);

            return View(moneyUpdateRequest);
        }

        [HttpPost]
        [Route("[action]/{moneyId}")]
        public async Task<IActionResult> Edit(MoneyUpdateRequest moneyUpdateRequest)
        {

            if (moneyUpdateRequest == null)
            {
                return RedirectToAction("GetRecords");

            }
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View();
            }

            await _moneyService.UpdateMoneyRecord(moneyUpdateRequest);

            return RedirectToAction("GetRecords");
        }

        [HttpGet]
        [Route("[action]/{moneyId}")]
        public async Task<IActionResult> Delete(Guid moneyId)
        {
            MoneyResponse moneyResponse = await _moneyService.GetMoneyRecordById(moneyId);

            if (moneyResponse == null)
            {
                return RedirectToAction("GetRecords");
            }

            return View(moneyResponse);
        }

        [HttpPost]
        [Route("[action]/{moneyId}")]
        public async Task<IActionResult> Delete(MoneyUpdateRequest moneyUpdateRequest)
        {
            if (moneyUpdateRequest == null)
            {
                return RedirectToAction("GetRecords");
            }

            await _moneyService.DeleteMoneyRecord(moneyUpdateRequest);

            return RedirectToAction("GetRecords");
        }
    }
}
