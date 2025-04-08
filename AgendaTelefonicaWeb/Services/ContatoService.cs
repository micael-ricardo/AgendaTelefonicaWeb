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

        public async Task InsertAsync(Contato contato, List<string> numerosTelefone)
        {
            if (numerosTelefone == null || !numerosTelefone.Any())
            {
                throw new ArgumentException("É necessário informar ao menos um número de telefone.");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.AddAsync(contato);
                await _context.SaveChangesAsync();

                var telefones = numerosTelefone
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .Select(numero => new Telefone
                    {
                        Numero = numero,
                        ContatoId = contato.Id
                    }).ToList();

                await _telefoneService.InsertAsync(telefones); 

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
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
            var contato = await _context.Contato
                .Include(c => c.Telefones) 
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contato == null)
                return;

            var DiretorioDolog = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");
            var PastaLog = Path.Combine(DiretorioDolog, "log_exclusao.txt");

            if (!Directory.Exists(DiretorioDolog))
                Directory.CreateDirectory(DiretorioDolog);

            var MensagemLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Contato excluído: Nome = {contato.Nome}," +
                $" Idade = {contato.Idade}";

            if (contato.Telefones != null && contato.Telefones.Any())
            {
                var telefones = string.Join(", ", contato.Telefones.Select(t => t.Numero));
                MensagemLog += $", Telefones = {telefones}";
            }

            MensagemLog += Environment.NewLine;

            await File.AppendAllTextAsync(PastaLog, MensagemLog);

            _context.Contato.Remove(contato);
            await _context.SaveChangesAsync();
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

