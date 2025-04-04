using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaTelefonicaWeb.Models
{
    public class Telefone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Número é obrigatorio")]
        public long Numero { get; set; }

        public int ContatoId { get; set; }  
    }
}
