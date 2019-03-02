using Senai.Web.Api.Senatur.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Web.Api.Senatur.Domains {
    [Table("USUARIOS")]
    public class UsuariosDomain {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("UsuarioId")]
        public int ID { get; set;}

        [Required]
        [Column("Email", TypeName = "varchar(250)")]
        public string Email { get; set;}

        [Required]
        [Column("Senha", TypeName ="varchar(250)")]
        public string Senha { get; set;}

        [Required]
        [Column("TipoUsuario", TypeName="varchar(50)")]
        public En_TipoUsuario TipoUsuario { get; set;}
    }
}
