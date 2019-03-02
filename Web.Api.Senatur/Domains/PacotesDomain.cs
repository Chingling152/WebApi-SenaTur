using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Web.Api.Senatur.Domains {
    [Table("PACOTES")]
    public class PacotesDomain {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "PacoteId")]
        public int ID { get; set;}

        [Required]
        [Column(name: "PacoteNome", TypeName ="VARCHAR(250)")]
        public string Nome { get; set;}

        [Required]
        [Column(name:"Descricao",TypeName ="TEXT")]
        public string Descricao { get;set;}

        [Required]
        [DataType(DataType.Date)]
        [Column(name: "DataIda", TypeName ="DATE")]
        public DateTime DataIda { get;set;}

        [Required]
        [DataType(DataType.Date)]
        [Column(name: "DataVolta", TypeName = "DATE")]
        public DateTime DataVolta { get;set;}

        [Required]
        [Column(name: "NomeCidade",TypeName ="varchar(200)")]
        public string Cidade { get;set;}

        [Required]
        [Column(name: "Valor", TypeName ="MONEY")]
        [DataType(DataType.Currency)]
        public decimal Valor { get;set;}
        
        [Column(name: "Ativo", TypeName = "BIT")]
        public bool Ativo {get;set;}

    }
}
