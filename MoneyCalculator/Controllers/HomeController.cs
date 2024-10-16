using Microsoft.AspNetCore.Mvc;
using MoneyCalculator.Entities.DTO;
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
    }
}
