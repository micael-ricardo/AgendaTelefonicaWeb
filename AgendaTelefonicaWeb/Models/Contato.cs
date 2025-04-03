using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonicaWeb.Models
{
    public class Contato
    {
            [Column("Id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required(ErrorMessage ="É obrigatorio o preenchimento do campo Nome")]
            [StringLength(100, ErrorMessage ="O Campo Nome Não pode exceder 100 caracteres")]
            [Column("Nome")]
            public string Nome { get; set; }
        
            [Required(ErrorMessage = "É obrigatorio o preenchimento do Idade")]
            [Range(0,150, ErrorMessage ="O Campo idade deve estar entrar 0 e 150")]
            [Column("Idade")]
            public int Idade { get; set; }

            public virtual ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
        
    }
}
