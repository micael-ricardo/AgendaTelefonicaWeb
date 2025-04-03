using AgendaTelefonicaWeb.Data;
using AgendaTelefonicaWeb.Models;

namespace AgendaTelefonicaWeb.Services
{
    public class ContatoService
    {
        private readonly AgendaTelefonicaWebContext _context;


        public ContatoService(AgendaTelefonicaWebContext context)
        {
            _context = context;
        }

        public List<Contato> FindAll()
        {
            return _context.Contato.ToList();
        }

        public void Insert(Contato obj) 
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
