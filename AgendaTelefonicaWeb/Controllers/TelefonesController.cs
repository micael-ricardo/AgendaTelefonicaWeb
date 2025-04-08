using AgendaTelefonicaWeb.Models;
using AgendaTelefonicaWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonicaWeb.Controllers
{
    public class TelefonesController : Controller
    {
        private readonly TelefoneService _telefoneService;

        public TelefonesController(TelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }
        public IActionResult Index()
        {
            var list = _telefoneService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();  
        }
    }
}
