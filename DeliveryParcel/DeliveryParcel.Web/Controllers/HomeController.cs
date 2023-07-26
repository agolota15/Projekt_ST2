using DeliveryParcel.Models;
using DeliveryParcel.Service.Interfaces;
using DeliveryParcel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeliveryParcel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;
        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orderResponse = await _orderService.GetAllOrdesAsync();
            return View(orderResponse.Result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orderResponse = await _orderService.GetAllOrdesAsync();
            return Json(new { Data = orderResponse.Result });
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateVm createVm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(createVm);

                var orderResponse = await _orderService.MakeOrderAsync(createVm);
                if (orderResponse.IsSuccess)
                {
                    TempData["success"] = "Zamówienie dodane!";
                    return RedirectToAction(nameof(Index));
                }

                TempData["error"] = "Zamówienie nie dodane!";
                return View(createVm);
            }
            catch (Exception ex)
            {
                _logger.LogError("Wystąpił błąd przy dodawaniu zamówienia.", ex);
                return View(nameof(Error));
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}