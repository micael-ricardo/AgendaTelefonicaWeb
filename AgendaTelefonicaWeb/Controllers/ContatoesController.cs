using Microsoft.AspNetCore.Mvc;
using AgendaTelefonicaWeb.Services;
using AgendaTelefonicaWeb.Models;
using AgendaTelefonicaWeb.Models.ViewModels;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonicaWeb.Controllers
{
    public class ContatoesController : Controller
    {
        private readonly ContatoService _ContatoService;
        private readonly TelefoneService _TelefoneService;

        public ContatoesController(ContatoService contatoService, TelefoneService telefoneService)
        {
            _ContatoService = contatoService;
            _TelefoneService = telefoneService;
        }

        public async Task<IActionResult> Index(string searchTerm)
        {
            var contatos = await _ContatoService.FindAllAsync(searchTerm);
            ViewData["SearchTerm"] = searchTerm;
            return View(contatos);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContatoTelefoneViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (viewModel.Numeros == null || viewModel.Numeros.All(string.IsNullOrWhiteSpace))
            {
                ModelState.AddModelError("Numeros", "Informe ao menos um número de telefone válido.");
                return View(viewModel);
            }

            try
            {
                await _ContatoService.InsertAsync(viewModel.Contato, viewModel.Numeros);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(viewModel);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Console.WriteLine($"Entrouuu {id}");
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _ContatoService.FindByIdAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            var telefones = await _TelefoneService.GetByContatoIdAsync(id.Value);

            var viewModel = new ContatoTelefoneViewModel
            {
                Contato = contato,
                Numeros = telefones.Select(t => t.Numero).ToList(),
                TelefonesIds = telefones.Select(t => t.Id).ToList()
            };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContatoTelefoneViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (viewModel.Numeros == null || viewModel.Numeros.All(string.IsNullOrWhiteSpace))
            {
                ModelState.AddModelError("Numeros", "Informe ao menos um número de telefone válido.");
                return View(viewModel);
            }

            try
            {
                await _ContatoService.UpdateAsync(
                    viewModel.Contato,
                    viewModel.Numeros,
                    viewModel.TelefonesIds);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(viewModel);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _ContatoService.FindByIdAsync(id);

            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ContatoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BaixarLog()
        {
            var PastaLog = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs", "log_exclusao.txt");

            if (!System.IO.File.Exists(PastaLog))
            {
                TempData["Mensagem"] = "Nenhum log de exclusão foi encontrado.";
                return RedirectToAction(nameof(Index));
            }

            var bytes = System.IO.File.ReadAllBytes(PastaLog);
            return File(bytes, "text/plain", "log_exclusao.txt");
        }
    }
}