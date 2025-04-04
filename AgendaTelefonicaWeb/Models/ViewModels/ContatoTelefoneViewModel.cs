using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonicaWeb.Models.ViewModels
{
    public class ContatoTelefoneViewModel
    {
        public Contato Contato { get; set; }

        [Required(ErrorMessage = "Número é obrigatorio")]
        [Range(10000000, 999999999999, ErrorMessage = "Número invalido")]
        public required int Numero { get; set; }
    }
}
