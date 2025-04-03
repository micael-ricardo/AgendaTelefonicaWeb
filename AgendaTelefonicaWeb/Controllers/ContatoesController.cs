using Microsoft.AspNetCore.Mvc;
using AgendaTelefonicaWeb.Services;
using AgendaTelefonicaWeb.Models;
using AgendaTelefonicaWeb.Models.ViewModels;

namespace AgendaTelefonicaWeb.Controllers
{
    public class ContatoesController : Controller
    {
        private readonly ContatoService _ContatoService;
        private readonly TelefoneService _TelefoneService;

        public ContatoesController(ContatoService contatoService , TelefoneService telefoneService)
        {
            _ContatoService = contatoService;
            _TelefoneService = telefoneService;
        }

        public IActionResult Index()
        {
            var list = _ContatoService.FindAll();

            return View(list);  
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contato contato)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ContatoService.Insert(contato);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao salvar: " + ex.Message);
                    return View(contato);
                }
            }
            return View(contato);
        }



        /*  private readonly AgendaTelefonicaWebContext _context;

          public ContatoServiceContatoService(AgendaTelefonicaWebContext context)
          {
              _context = context;
          }

          // GET: Contatoes
          public async Task<IActionResult> Index()
          {
              return View(await _context.Contato.ToListAsync());
          }

          // GET: Contatoes/Details/5
        /*  public async Task<IActionResult> Details(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var contato = await _context.Contato
                  .FirstOrDefaultAsync(m => m.Id == id);
              if (contato == null)
              {
                  return NotFound();
              }

              return View(contato);
          }

          // GET: Contatoes/Create
          public IActionResult Create()
          {
              return View();
          }

          // POST: Contatoes/Create
          // To protect from overposting attacks, enable the specific properties you want to bind to.
          // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Create([Bind("ContatoId,Nome,Idade")] Contato contato)
          {
              if (ModelState.IsValid)
              {
                  _context.Add(contato);
                  await _context.SaveChangesAsync();
                  return RedirectToAction(nameof(Index));
              }
              return View(contato);
          }

          // GET: Contatoes/Edit/5
          public async Task<IActionResult> Edit(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var contato = await _context.Contato.FindAsync(id);
              if (contato == null)
              {
                  return NotFound();
              }
              return View(contato);
          }

          // POST: Contatoes/Edit/5
          // To protect from overposting attacks, enable the specific properties you want to bind to.
          // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Edit(int id, [Bind("ContatoId,Nome,Idade, TelefoneId")] Contato contato)
          {
              if (id != contato.Id)
              {
                  return NotFound();
              }

              if (ModelState.IsValid)
              {
                  try
                  {
                      _context.Update(contato);
                      await _context.SaveChangesAsync();
                  }
                  catch (DbUpdateConcurrencyException)
                  {
                      if (!ContatoExists(contato.Id))
                      {
                          return NotFound();
                      }
                      else
                      {
                          throw;
                      }
                  }
                  return RedirectToAction(nameof(Index));
              }
              return View(contato);
          }

          // GET: Contatoes/Delete/5
          public async Task<IActionResult> Delete(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var contato = await _context.Contato
                  .FirstOrDefaultAsync(m => m.Id == id);
              if (contato == null)
              {
                  return NotFound();
              }

              return View(contato);
          }

          // POST: Contatoes/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> DeleteConfirmed(int id)
          {
              var contato = await _context.Contato.FindAsync(id);
              if (contato != null)
              {
                  _context.Contato.Remove(contato);
              }

              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }

          private bool ContatoExists(int id)
          {
              return _context.Contato.Any(e => e.Id == id);
          }*/
    }
}
