using Audit.Client.Data.Repositories;
using Audit.Client.Data.Services.LogChangesBettwenTwoEntityDomain;
using Audit.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Audit.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository repository;
        private readonly ILogChangesBettwenTwoEntity logChangesBettwenTwoEntity;

        public HomeController(ILogger<HomeController> logger, IRepository repository, ILogChangesBettwenTwoEntity logChangesBettwenTwoEntity)
        {
            _logger = logger;
            this.repository = repository;
            this.logChangesBettwenTwoEntity = logChangesBettwenTwoEntity;
        }

        public async Task<IActionResult> Index()
        {
            var result = await repository.Get();
            return View(result.OrderByDescending(p => p.InsertDateTime));
        }
        public async Task<IActionResult> Test()
        {
            var oldValue = new TestDTO() { A = 1, B = 2, C = 3 };
            var newValue = new TestDTO() { A = 10, B = 12, C = 11 };
            await logChangesBettwenTwoEntity.LogInformation(User.Identity.Name, "1", "TestDTO", oldValue, newValue);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client.Data.Models.Audit model)
        {
            await repository.Add(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await repository.Delete(id);

            return RedirectToAction("Index");
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
