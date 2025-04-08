

using AgendaTelefonicaWeb.Data;
using AgendaTelefonicaWeb.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Telefone>> GetByContatoIdAsync(int contatoId)
        {
            return await _context.Telefone
                               .Where(t => t.ContatoId == contatoId)
                               .ToListAsync();
        }

    }
}
