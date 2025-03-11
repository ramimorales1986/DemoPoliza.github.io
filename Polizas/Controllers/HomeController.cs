using Microsoft.AspNetCore.Mvc;
using Polizas.Models;
using System.Diagnostics;
using Newtonsoft.Json;
namespace Polizas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(string Mensaje = "")
        {
            ViewBag.estado = Mensaje;
            return View();
        }

        public IActionResult Principal(string username, string password)
        {
            if (username == "Admin" && password == "123")
            {
                return RedirectToAction("DetallePoliza", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home", new { Mensaje = "ERROR" });
            }

        }
        public IActionResult Notificaciones()
        {
            ModeloPoliza _model = new();
            StreamReader json = new StreamReader(@"InformacionPoliza.json");
            string jsonString = json.ReadToEnd();
            _model.DetallePolizaResponse = JsonConvert.DeserializeObject<DetallePolizaResponse>(jsonString)!;
            return View(_model);
        }

        public IActionResult DetallePoliza(string Mensaje="")
        {
            ViewBag.estado = Mensaje;
            ModeloPoliza _model = new();
            StreamReader json = new StreamReader(@"InformacionPoliza.json");
            string jsonString = json.ReadToEnd();
            _model.DetallePolizaResponse = JsonConvert.DeserializeObject<DetallePolizaResponse>(jsonString)!;
            return View(_model);
        }
        [Route("Home/RenovarPoliza/{poliza}")]
        public IActionResult RenovarPoliza(string poliza)
        {
            ModeloPoliza _model = new();
            StreamReader json = new StreamReader(@"InformacionPoliza.json");
            string jsonString = json.ReadToEnd();
            DetallePolizaResponse datos = JsonConvert.DeserializeObject<DetallePolizaResponse>(jsonString)!;
            _model.DetalleCliente = (DetallePoliza?)datos.DetallePolizas?.Find(m => m.NumeroPoliza == poliza);
            return View(_model);
        }

        public IActionResult Renovar()
        {
            return RedirectToAction("DetallePoliza", "Home", new { Mensaje = "OK" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
