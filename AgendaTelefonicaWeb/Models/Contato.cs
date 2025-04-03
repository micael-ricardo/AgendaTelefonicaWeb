using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonicaWeb.Models
{
    public class Contato
    {
            [Column("Id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required(ErrorMessage ="É obrigatorio o preenchimento do Nome")]
            [StringLength(100, ErrorMessage ="O  Nome não pode exceder 100 caracteres")]
            [Column("Nome")]
            public string Nome { get; set; }
        
            [Required(ErrorMessage = "É obrigatorio o preenchimento da idade")]
            [Range(0,150, ErrorMessage ="A idade deve estar entrar 0 e 150")]
            [Column("Idade")]
            public int Idade { get; set; }

            public int TelefoneId { get; set; }

            public virtual ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
        
    }
}
