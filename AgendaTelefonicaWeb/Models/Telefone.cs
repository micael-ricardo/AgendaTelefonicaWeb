using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaTelefonicaWeb.Models
{
    public class Telefone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [RegularExpression(@"^[0-9]{8,20}$",
        ErrorMessage = "Deve conter apenas números (8-20 dígitos)")]
        [Required(ErrorMessage = "Número é obrigatorio")]
        public string Numero { get; set; }

        public int ContatoId { get; set; }  
    }
}
