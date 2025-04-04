using System.Text.Json;
using AgendaTelefonicaWeb.Data;
using AgendaTelefonicaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonicaWeb.Services
{
    public class ContatoService
    {
        private readonly AgendaTelefonicaWebContext _context;
        private readonly TelefoneService _telefoneService;


        public ContatoService(AgendaTelefonicaWebContext context, TelefoneService telefoneService)
        {
            _context = context;
            _telefoneService = telefoneService;
        }

        public async Task<List<Contato>> FindAllAsync()
        {
            return await _context.Contato
                        .Include(c => c.Telefones)
                        .ToListAsync();
        }

        public async Task InsertAsync(Contato obj, string numeroTelefone)
        {

            if (string.IsNullOrWhiteSpace(numeroTelefone))
            {
                throw new ArgumentException("Número de telefone é obrigatório.");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                Console.WriteLine($"Aqui chegaa Numeroooo--: {numeroTelefone}");
                await _context.AddAsync(obj);
                await _context.SaveChangesAsync();
                Console.WriteLine($"Contato salvo com ID: {obj.Id}");
                int id = obj.Id;

                var telefone = new Telefone
                {
                    Numero = numeroTelefone,
                    ContatoId = id
                };

                await _telefoneService.InsertAsync(telefone);

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine($"Erro ao salvar: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task<Contato> FindByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _context.Contato
                                 .Include(c => c.Telefones) 
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }



        public async Task RemoveAsync(int id) 
        {
            var obj = _context.Contato.Find(id);
            _context.Contato.Remove(obj);
            _context.SaveChangesAsync();    
        }

        public async Task UpdateAsync(Contato obj)
        {
            bool TemDados = await _context.Contato.AnyAsync(X =>  X.Id == obj.Id);
            
            if(!TemDados)
            {
                throw new DirectoryNotFoundException("Contato não encontrado");
            }
            try
            {
                _context.Contato.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

