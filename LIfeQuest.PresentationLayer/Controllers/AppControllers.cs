using Microsoft.AspNetCore.Mvc;

namespace LIfeQuest.PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    public class ChallengesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        [Route("Challenges/Join-Challenge")]
        [Route("Challenges/Join")]
        public IActionResult Join()
        {
            return View();
        }

        [Route("Challenges/Daily-CheckIn")]
        [Route("Challenges/DailyCheckIn")]
        public IActionResult DailyCheckIn()
        {
            return View();
        }
    }

    public class AnalyticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
