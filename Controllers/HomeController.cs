using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using wandaTechIntern.Data;
using wandaTechIntern.Models;

namespace wandaTechIntern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Deliveries()
        {
            // select * FROM deliveies, DeliveryPoints on a.==d
            var allDeliveries = context.Deliveries
                .Include(t=> t.DeliveryPoints).ToList();

            var allDelToday = context.Deliveries
                .Where(x => x.PostedTime.Date == DateTime.Now.Date).ToList();
            return View(allDeliveries);

            // INSERT
            //context.Deliveries.Add(new Data.Models.Delivery
            //{
            //    TimeOfDelivery = 123123
            //})
            //context.SaveChangesAsync();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}