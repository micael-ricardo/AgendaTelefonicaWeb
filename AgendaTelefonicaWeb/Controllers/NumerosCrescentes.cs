
using Microsoft.AspNetCore.Mvc;
namespace AgendaTelefonicaWeb.Controllers
{
    public class NumerosCrescentes : Controller
    {
        // GET: NumerosCrescentes
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string numerosInput)
        {
            try
            {
                var numerosStr = numerosInput.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numerosStr.Length != 6)
                {
                    ViewBag.Mensagem = "Por favor, insira exatamente 6 números.";
                    return View();
                }
                var numeros = new int[6];
                for (int i = 0; i < 6; i++)
                {
                    if (!int.TryParse(numerosStr[i], out numeros[i]))
                    {
                        ViewBag.Mensagem = $"Valor inválido: {numerosStr[i]}. Por favor, insira apenas números.";
                        return View();
                    }
                }
                Array.Sort(numeros);
                ViewBag.NumerosOrdenados = numeros;
            }
            catch (Exception)
            {
                ViewBag.Mensagem = "Ocorreu um erro ao processar os números.";
            }
            return View();
        }

    }
}
