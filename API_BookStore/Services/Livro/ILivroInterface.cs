using API_BookStore.DTO.Livro;
using API_BookStore.Model;

namespace API_BookStore.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livrosEdicaoDto);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
        Task<ResponseModel<LivroModel>> BuscarLivrosTitulo(string titulo);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroCategoria(string categoria);
        Task<ResponseModel<List<LivroModel>>> CompraLivros(int idLivro, int quantidade);
    }
}
