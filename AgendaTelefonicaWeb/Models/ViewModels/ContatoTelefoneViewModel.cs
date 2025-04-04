using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonicaWeb.Models.ViewModels
{
    public class ContatoTelefoneViewModel
    {
        public Contato Contato { get; set; }
        public required int Numero { get; set; }
    }
}
