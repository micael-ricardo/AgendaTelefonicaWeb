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

        public async Task<IActionResult> Index()
        {
            var list = await _ContatoService.FindAllAsync();


            return View(list);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContatoTelefoneViewModel viewModel, string Numero)
        {
            Console.WriteLine($"Dados recebidos: {JsonSerializer.Serialize(viewModel)}");

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                var contato = new Contato
                {
                    Nome = viewModel.Contato.Nome,
                    Idade = viewModel.Contato.Idade
                };
                await _ContatoService.InsertAsync(contato, Numero);

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
            return View(contato);
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
        /*
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contato = await _ContatoService.FindAsync(id);
            if (contato != null)
            {
                _ContatoService.Remove(contato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        /*private async Task<bool> ContatoExists(int id)
        {
            return await _ContatoService.Any(e => e.Id == id);
        }*/

    }
}