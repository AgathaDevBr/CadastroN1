using System.ComponentModel.DataAnnotations;

namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "IdCliente")]
        [Required(ErrorMessage = "O cliente é requerido.")]
        public int IdClient { get; set; }

        [Display(Name = "Cliente")]
        public string NameClient { get; set; }

        [Display(Name = "IdCategoria")]
        [Required(ErrorMessage = "A categoria é requerido.")]
        public int IdCategory { get; set; }

        [Display(Name = "Categoria")]
        public string NameCategory { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é requerido.")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "O valor deve ser um número positivo.")]
        public decimal Value { get; set; }

        [Display(Name = "Ativo")]
        public bool Ative { get; set; }


    }
}
