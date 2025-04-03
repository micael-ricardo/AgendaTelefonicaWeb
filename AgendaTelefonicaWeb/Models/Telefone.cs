using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaTelefonicaWeb.Models
{
    [Table("Telefone")]
    public class Telefone
    {

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Contato")]
        [Column("IDCONTATO")]
        public int ContatoId { get; set; }


        public virtual Contato Contato { get; set; }

    }
}
