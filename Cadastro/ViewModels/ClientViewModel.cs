using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "SobreNome")]
        [Required(ErrorMessage = "O SobreNome é requerido.")]
        public string LastName { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é requerido.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "O email é requerido.")]
        public string Email { get; set; }

        [Display(Name = "Ativo")]
        public bool Ative { get; set; }
    }
}
