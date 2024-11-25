using API_BookStore.DTO.Vinculo;

namespace API_BookStore.DTO.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public AutorVinculoDto Autor { get; set; }

        public string Categoria { get; set; }

        public DateTime DataPublicacao { get; set; }

        public float Preco { get; set; }

        public int QuantidadeEstoque { get; set; }
    }
}
