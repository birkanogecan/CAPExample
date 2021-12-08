using CAPExample.UI.Events;
using CAPExample.UI.Models;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CAPExample.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICapPublisher _capBus;
        private readonly AppDbContext _dbContext;


        public HomeController(ILogger<HomeController> logger, ICapPublisher capPublisher, AppDbContext dbContext)
        {
            _logger = logger;
            _capBus = capPublisher;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult ProduceTest()
        {
            using (_dbContext.Database.BeginTransaction(_capBus, autoCommit: true))
            {
                Person person = new Person() { Name = "Test Testoglu" };

                _dbContext.Person.Add(person);
                _dbContext.SaveChanges();

                PersonCreated p = new PersonCreated()
                {
                    Id = person.Id,
                    Name = person.Name
                };

                _capBus.Publish(nameof(PersonCreated), p);

            }

            return View("Index");
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