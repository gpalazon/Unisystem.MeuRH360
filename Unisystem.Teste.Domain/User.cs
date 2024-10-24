using System;
using System.ComponentModel.DataAnnotations;

namespace Unisystem.Teste.Domain
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
