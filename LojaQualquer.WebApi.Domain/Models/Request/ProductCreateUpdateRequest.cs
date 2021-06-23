using System.ComponentModel.DataAnnotations;

namespace LojaQualquer.WebApi.Domain.Models.Request
{
    public class ProductCreateUpdateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório informar o nome do produto.")]
        [MaxLength(128, ErrorMessage = "O nome do produto precisa conter até 128 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "É obrigatório inserir a categoria do produto.")]
        [Range(minimum: 0, maximum: 2, ErrorMessage = "A categoria do produto precisar estar entre 0 e 2")]
        public int Category { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o preço do produto.")]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "O preço informado é inválido.")]
        public decimal Price { get; set; }
    }
}