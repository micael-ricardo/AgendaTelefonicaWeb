using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonicaWeb.Models.ViewModels
{
    public class ContatoTelefoneViewModel
    {
        public Contato Contato { get; set; }

        [Required(ErrorMessage = "Informe pelo menos um número de telefone.")]
        public List<string> Numeros { get; set; } = new List<string>();
        public List<int> TelefonesIds { get; set; } = new List<int>();
    }
}
