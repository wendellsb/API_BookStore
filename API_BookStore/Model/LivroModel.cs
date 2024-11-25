namespace API_BookStore.Model
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorModel Autor { get; set; }
        public string Categoria { get; set; }
        public DateTime DataPublicacao { get; set; }
        public float Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
