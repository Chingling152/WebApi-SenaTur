using Senai.Web.Api.Senatur.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Web.Api.Senatur.Domains {
    [Table("Usuarios")]
    public class UsuariosDomain {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("UsuarioId")]
        public int ID { get; set;}

        [Column("Email", TypeName = "varchar(250)")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="O Campo Email é obrigatorio")]
        [StringLength(maximumLength:250,MinimumLength =5,ErrorMessage ="Quantidade de caracteres invalidos")]
        [DataType(DataType.EmailAddress,ErrorMessage ="O Valor inserido não é um Email valido")]
        public string Email { get; set;}

        [Column("Senha", TypeName ="varchar(250)")]
        [Required(ErrorMessage = "A Senha é obrigatória")]
        [StringLength(maximumLength: 250, MinimumLength = 5, ErrorMessage = "Quantidade de caracteres invalidos")]
        public string Senha { get; set;}

        [Column("TipoUsuario", TypeName="SMALLINT")]
        [Required(ErrorMessage = "O Tipo de Usuario é obrigatório")]
        public En_TipoUsuario TipoUsuario { get; set;}
    }
}
