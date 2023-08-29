using System;
using System.ComponentModel.DataAnnotations;
using ClienteMVC.Validations;

namespace ClienteMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campoobrigatório!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Esse campoobrigatório!")]
        [CpfValidation(ErrorMessage = "CPF inválido!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataExpecicao { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string OrgaoExpedicao { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string UfCli { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string EstadoCivil { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [CepValidation(ErrorMessage = "CEP inválido!")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        public string Uf { get; set; }
    }
}