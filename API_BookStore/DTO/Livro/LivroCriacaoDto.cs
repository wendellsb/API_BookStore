using API_BookStore.DTO.Vinculo;
using System.ComponentModel.DataAnnotations;

namespace API_BookStore.DTO.Livro
{
    public class LivroCriacaoDto
    {
        [Required(ErrorMessage = "O campo titulo é obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
        public string Titulo { get; set; }

        public AutorVinculoDto Autor { get; set; }

        [Required(ErrorMessage = "O campo categoria é obrigatório!")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O campo data da publicação é obrigatório!")]
        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "O campo preço é obrigatório!")]
        public float Preco { get; set; }

        [Required(ErrorMessage = "O campo quantidade é obrigatório!")]
        public int QuantidadeEstoque { get; set; }
    }
}
