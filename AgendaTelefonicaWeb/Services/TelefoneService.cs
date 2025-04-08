

using AgendaTelefonicaWeb.Data;
using AgendaTelefonicaWeb.Models;

namespace AgendaTelefonicaWeb.Services
{
    public class TelefoneService
    {
        private readonly AgendaTelefonicaWebContext _context;

        public TelefoneService(AgendaTelefonicaWebContext context)
        {
            _context = context;
        }

        public List<Telefone> FindAll()
        {
            return _context.Telefone.ToList();
        }

        public async Task InsertAsync(List<Telefone> telefones)
        {
            await _context.AddRangeAsync(telefones);
            await _context.SaveChangesAsync();
        }

    }
}
