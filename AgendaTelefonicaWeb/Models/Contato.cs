using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonicaWeb.Models
{
    [Table("Contato")]
    public class Contato
    {
            [Key]
            [Column("ID")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ContatoId { get; set; }
            public string Nome { get; set; }

            [Column("IDADE")]
            public int Idade { get; set; }

            public virtual ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
        
    }
}
