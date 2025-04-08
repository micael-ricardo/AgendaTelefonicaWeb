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


        public async Task UpdateAsync(Contato contato, List<string> numerosTelefone, List<int> telefonesIds = null)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var contatoExistente = await _context.Contato
                    .Include(c => c.Telefones)
                    .FirstOrDefaultAsync(c => c.Id == contato.Id);
                if (contatoExistente == null)
                {
                    throw new KeyNotFoundException("Contato não encontrado");
                }

                _context.Entry(contatoExistente).CurrentValues.SetValues(contato);

                if (numerosTelefone != null)
                {
                    await GerenciarTelefonesAsync(contatoExistente, numerosTelefone, telefonesIds ?? new List<int>());
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private async Task GerenciarTelefonesAsync(Contato contato, List<string> numeros, List<int> telefonesIds)
        {
            var telefonesParaRemover = contato.Telefones
                .Where(t => !telefonesIds.Contains(t.Id))
                .ToList();

            _context.Telefone.RemoveRange(telefonesParaRemover);

            for (int i = 0; i < numeros.Count; i++)
            {
                if (i < telefonesIds.Count && telefonesIds[i] != 0)
                {
                    var telefoneExistente = contato.Telefones.FirstOrDefault(t => t.Id == telefonesIds[i]);
                    if (telefoneExistente != null)
                    {
                        telefoneExistente.Numero = numeros[i];
                    }
                }
                else
                {
                    contato.Telefones.Add(new Telefone
                    {
                        Numero = numeros[i],
                        ContatoId = contato.Id
                    });
                }
            }
        }

    }
}

