using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisystem.Teste.Domain
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string Tipo { get; set; }

        [Required]        
        public string CNPJ { get; set; }

        public string CEP{ get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Celular { get; set; }
                
        [Required]
        public string NomeAdministrador { get; set; }        

        public string CPFAdministrador { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
