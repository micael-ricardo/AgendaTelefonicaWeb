using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonicaWeb.Models
{
    public class Contato
    {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required(ErrorMessage ="É obrigatorio o preenchimento do Nome")]
            [StringLength(100, ErrorMessage ="O  Nome não pode exceder 100 caracteres")]
            [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "O nome deve conter apenas letras e espaços.")]
             public string Nome { get; set; }
        
            [Required(ErrorMessage = "É obrigatorio o preenchimento da idade")]
            [Range(1,150, ErrorMessage ="A idade deve estar entre 1 e 150")]
            public int Idade { get; set; }
            [Required(ErrorMessage = "É obrigatorio o preenchimento do numero de Telefone")] 
             public virtual ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
        
    }
}
