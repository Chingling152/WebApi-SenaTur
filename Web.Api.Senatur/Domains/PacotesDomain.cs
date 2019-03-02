using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Web.Api.Senatur.Domains {
    [Table("Pacotes")]
    public class PacotesDomain {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "PacoteId")]
        public int ID { get; set;}

        [Column(name: "PacoteNome", TypeName ="VARCHAR(250)")]
        [Required(ErrorMessage = "O Pacote de viagem precisa ter um nome")]
        [StringLength(maximumLength:250,MinimumLength = 2,ErrorMessage ="Quantidade de caracteres invalida")]
        public string Nome { get; set;}

        [Column(name:"Descricao",TypeName ="TEXT")]
        [Required(ErrorMessage = "O Pacote de viagem precisa de uma Descrição")]
        [StringLength(maximumLength: 1000, MinimumLength = 1, ErrorMessage = "Numero de caracteres excedido")]
        public string Descricao { get;set;}

        [Column(name: "DataIda", TypeName ="DATE")]
        [Required(ErrorMessage = "O Pacote de viagem precisa de uma Data de Ida")]
        [DataType(DataType.Date,ErrorMessage ="O Tipo de dados inserido não é uma data")]
        public DateTime DataIda { get;set;}

        [Column(name: "DataVolta", TypeName = "DATE")]
        [Required(ErrorMessage = "O Pacote de viagem precisa de uma Data de Volta")]
        [DataType(DataType.Date, ErrorMessage = "O Tipo de dados inserido não é uma data")]
        public DateTime DataVolta { get;set;}

        [Column(name: "NomeCidade",TypeName ="varchar(200)")]
        [Required(ErrorMessage = "O Pacote de viagem precisa de uma cidade de destino")]
        [StringLength(maximumLength: 250, MinimumLength = 2, ErrorMessage = "Nome da cidade muito pequeno ou excede a quantidade de caracteres")]
        public string Cidade { get;set;}

        [Column(name: "Valor", TypeName ="MONEY")]
        [Required(ErrorMessage = "O Pacote de viagem precisa ter um valor")]
        [DataType(DataType.Currency,ErrorMessage ="O Valor inserido não é um numero")]
        public decimal Valor { get;set;}
        
        [Column(name: "Ativo", TypeName = "BIT")]
        [DefaultValue(true)]
        public bool Ativo {get;set;}

    }
}
