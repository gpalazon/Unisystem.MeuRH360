using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisystem.Teste.Application.DTO
{

     public class CompanyDTO
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da Empresa é obrigatório")]
        [StringLength(200, ErrorMessage = "O nome não pode exceder 200 caracteres")]
        public string Nome { get; set; }

        public string Tipo { get; set; }

        [Required]
        public string CNPJ { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O nome do Administrador é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres")]
        public string NomeAdministrador { get; set; }

        public string CPFAdministrador { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
    }
}
