using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaTelefonicaWeb.Models
{
    public class Telefone
    {
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Contato")]
        [Column("IdContato")]
        public int ContatoId { get; set; }
        public virtual required Contato Contato { get; set; }

        [Required(ErrorMessage = "Número é obrigatorio")]
        [StringLength(16, ErrorMessage ="O número não pode exceder 16 caracters")]
        [Column("Numero")]
        public int Numero { get; set; }
    }
}
