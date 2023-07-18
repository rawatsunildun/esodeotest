using esoSampleProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace esoSampleProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }
        public IActionResult Index()
        {
            //SecretKeys objSecretKey = new SecretKeys();
            ViewBag.firstName = _config["firstname01"].ToString();
            ViewBag.lastName = _config["lastname01"].ToString();
           
            return View();
        }
    }
}
